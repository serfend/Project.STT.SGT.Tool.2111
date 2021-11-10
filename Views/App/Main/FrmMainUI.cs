using NLog;
using Project.STT.SGT.Tool._2111.Services.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.STT.SGT.Tool._2111
{

    /// <summary>
    /// UI
    /// </summary>
    public partial class FrmMain
    {
        private const string ConfigAppData = "app.default.";
        private void SyncUIContent()
        {
            config.Reload();
            this.TxtMediaSrc.Text = config[$"{ConfigAppData}MediaSrc"];
            this.TxtModelSelect.Text = config[$"{ConfigAppData}ModelSelect"];
        }
        private void CheckCanStartTask()
        {
            var fileMatch = File.Exists(this.TxtMediaSrc.Text);
            var modelMatch = Directory.Exists(this.TxtModelSelect.Text);
            var canStartTask = fileMatch && modelMatch;
            BtnStartTask.Enabled = canStartTask;
            BtnStartTask.Text = canStartTask ? TranslationStatusStart : TranslationNotAllowed;
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
        private CancellationToken translateTaskCancel;
        const string TranslationStatusStart = "开始语音转文字";
        const string TranslationStatusEnd = "停止语音转文字";
        const string TranslationNotAllowed = "请选择有效的模型和音频文件";
        private void BtnStartTask_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn.Text == TranslationStatusStart)
            {
                btn.Text = TranslationStatusEnd;
                translateTaskCancel = new CancellationToken();
                logger.ActionWithLabel((l, m) => l.Log<string>(LogLevel.Info, m), "开始转换");
                v.StartTask(translateTaskCancel).ContinueWith((d) =>
                {
                    Console.WriteLine("1");
                });
                return;
            }
            btn.Text = TranslationStatusStart;
            translateTaskCancel.ThrowIfCancellationRequested();
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
