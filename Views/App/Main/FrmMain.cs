
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

        private void BtnExportJsonText_Click(object sender, EventArgs e)
        {
            var title = (sender as Button).Text;
            DoExportResult(title, "json", () =>
             {
                 var list = new List<VoskSingleWordResult>();
                 foreach (var obj in this.LstTranslate.Items)
                 {
                     var item = obj as ListViewItem;
                     list.Add(new VoskSingleWordResult()
                     {
                         Confidence = double.Parse(item.SubItems[2].Text),
                         Content = item.SubItems[4].Text,
                         Start = double.Parse(item.SubItems[0].Text),
                         End = double.Parse(item.SubItems[1].Text),
                     });
                 }
                 var result = new { Meida = v.MediaMeta, Result = list, Export = new { Time = DateTime.Now } };
                 return JsonSerializer.Serialize(result);
             });
        }
        private void BtnExportPlainText_Click(object sender, EventArgs e)
        {
            var title = (sender as Button).Text;
            DoExportResult(title, "txt", () =>
             {
                 var content = new List<string>();
                 foreach (var obj in this.LstTranslate.Items)
                 {
                     var item = obj as ListViewItem;
                     content.Insert(0, item.SubItems[4].Text);
                 }
                 return string.Join('\n', content);
             });
        }


        private void BtnModelSelect_Click(object sender, EventArgs e)
        {

            var title = "选择语音识别模型（文件夹）";
            logger.ActionWithLabel(TooltipLabelLogger.InfoLog, title);
            var wavFileDialog = new FolderBrowserDialog() { RootFolder = Environment.SpecialFolder.History };
            var result = wavFileDialog.ShowDialog(this);
            if (result != DialogResult.OK && result != DialogResult.Yes) return;
            this.TxtModelSelect.Text = wavFileDialog.SelectedPath;

        }
        private CancellationTokenSource translateTaskCancel;
        const string TranslationStatusStart = "开始语音转文字";
        const string TranslationStatusEnd = "停止语音转文字";
        const string TranslationNotAllowed = "请选择有效的模型和音频文件";
        private void BtnStartTask_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn.Text == TranslationStatusStart)
            {
                LstTranslate.Items.Clear(); // 开始时清空上次结果
                btn.Text = TranslationStatusEnd;
                translateTaskCancel = new CancellationTokenSource();
                logger.ActionWithLabel((l, m) => l.Log<string>(LogLevel.Info, m), "开始转换");
                v.StartTask(translateTaskCancel.Token).ContinueWith((d) =>
                {
                    Console.WriteLine("1");
                });
                return;
            }
            translateTaskCancel.Cancel();
            btn.Text = TranslationStatusStart;
            logger.ActionWithLabel((l, m) => l.Log<string>(LogLevel.Info, m), "等待开始语音识别");
        }
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            var title = "选择需要语音识别的文件";
            logger.ActionWithLabel(TooltipLabelLogger.InfoLog, title);
            var wavFileDialog = new OpenFileDialog() { Title = title };
            var result = wavFileDialog.ShowDialog(this);
            if (result != DialogResult.OK && result != DialogResult.Yes) return;
            this.TxtMediaSrc.Text = wavFileDialog.FileName;
        }


        private void TextTemp_Click(object sender, EventArgs e)
        {
            // TODO 开始说话，接入语音输入
        }

    }
}