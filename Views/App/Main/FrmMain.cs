
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.STT.SGT.Tool._2111.Services.Log;
using NLog;
using System.Threading;
using System.Configuration;
using System.Collections.Specialized;
using Project.STT.SGT.Tool._2111.Services.Configuration;
using Project.STT.SGT.Tool._2111.Views.App.Main;
using System.IO;
using System.Text;
using Project.STT.SGT.Tool._2111.Services.STT.VoskApiResult;
using System.Collections.Generic;
using System.Text.Json;

namespace Project.STT.SGT.Tool._2111
{
    /// <summary>
    /// Form
    /// </summary>
    public partial class FrmMain : Form
    {
        SynchronizationContext m_SyncContext = null;
        public FrmMain()
        {
            m_SyncContext = SynchronizationContext.Current;
            InitializeComponent();
            this.logger = new TooltipLabelLogger(this.StatusMainLog);
            this.config = new("FrmMain.Setting.json");
            this.Load += FrmMain_Load;
        }
        private readonly TooltipLabelLogger logger;
        private JsonConfiguration<FrmMainSetting> config { get; set; }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            VoskCallBack();
            this.TxtModelSelect.TextChanged += (sender, e) =>
            {
                var src = (sender as TextBox).Text;
                new Task(() =>
                {
                    logger.ActionWithLabel((l, m) => l.Log<string>(LogLevel.Info, m), "加载模型");
                    v.LoadModel(src);
                }).Start();
                config.Data.History.ModelSrc = src;

                CheckCanStartTask();
            };
            this.TxtMediaSrc.TextChanged += (sender, e) =>
            {
                var src = (sender as TextBox).Text;
                v.LoadAudio(src);
                config.Data.History.MediaSrc = src;
                CheckCanStartTask();
            };

            SyncUIContent();
            this.FormClosing += (sender, e) => config.Save();
        }

        private void BtnExportText_Click(object sender, EventArgs e)
        {
            var title = (sender as Button).Text;
            DoExportResult(title, "json", () =>
             {
                 var list = new List<VoskSingleWordResult>();
                 foreach (var obj in this.LstTranslate.Items)
                 {
                     var item = obj as ListViewItem;
                     list.Add(new VoskSingleWordResult() { });
                 }
                 var result = new { Meida = v.MediaMeta, Result = list, Export = new { Time = DateTime.Now } };
                 return JsonSerializer.Serialize(result);
             });
        }
        private void DoExportResult(string title, string extension, Func<string> ResultGetter)
        {
            logger.ActionWithLabel((l, m) => l.Log<string>(LogLevel.Info, m), $"开始{title}");
            var dialog = new SaveFileDialog() { 
                Title = title, 
                RestoreDirectory = true, 
                DefaultExt = extension, 
                Filter = $"{extension}文件|*.{extension}" ,
                FileName = $"[{Path.GetFileName(TxtMediaSrc.Text)}].[${Path.GetFileName(TxtModelSelect.Text)}]output.{extension}"
            };
            var result = dialog.ShowDialog(this);
            if (result != DialogResult.OK && result != DialogResult.Yes) return;
            var content = ResultGetter();
            File.WriteAllText(dialog.FileName, content.ToString());
            logger.ActionWithLabel((l, m) => l.Log<string>(LogLevel.Info, m), $"完成{title}");
        }

        private void BtnExportText_Click_1(object sender, EventArgs e)
        {
            var title = (sender as Button).Text;
            DoExportResult(title, "txt", () =>
             {
                 var content = new StringBuilder();
                 foreach (var obj in this.LstTranslate.Items)
                 {
                     var item = obj as ListViewItem;
                     content.AppendLine(item.SubItems[4].Text);
                 }
                 return content.ToString();
             });
        }
    }
}