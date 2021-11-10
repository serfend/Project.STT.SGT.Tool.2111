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
        private void SyncUIContent()
        {
            config.Reload();
            this.TxtMediaSrc.Text = config.Data.History.MediaSrc;
            this.TxtModelSelect.Text = config.Data.History.ModelSrc;
        }
        private void CheckCanStartTask()
        {
            var fileMatch = File.Exists(this.TxtMediaSrc.Text);
            var modelMatch = Directory.Exists(this.TxtModelSelect.Text);
            var canStartTask = fileMatch && modelMatch && !v.IsRunning && v.Rec != null;
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
