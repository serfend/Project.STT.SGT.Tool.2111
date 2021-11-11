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

        private void DoExportResult(string title, string extension, Func<string> ResultGetter)
        {
            logger.ActionWithLabel((l, m) => l.Log<string>(LogLevel.Info, m), $"开始{title}");
            var dialog = new SaveFileDialog()
            {
                Title = title,
                RestoreDirectory = true,
                DefaultExt = extension,
                Filter = $"{extension}文件|*.{extension}",
                FileName = $"[{Path.GetFileName(TxtMediaSrc.Text)}].[${Path.GetFileName(TxtModelSelect.Text)}]output.{extension}"
            };
            var result = dialog.ShowDialog(this);
            if (result != DialogResult.OK && result != DialogResult.Yes) return;
            var content = ResultGetter();
            File.WriteAllText(dialog.FileName, content.ToString());
            logger.ActionWithLabel((l, m) => l.Log<string>(LogLevel.Info, m), $"完成{title}");
        }

        private void CheckCanStartTask()
        {
            var fileMatch = File.Exists(this.TxtMediaSrc.Text);
            var modelMatch = Directory.Exists(this.TxtModelSelect.Text);
            var canStartTask = fileMatch && modelMatch && !v.IsRunning && v.Rec != null;
            BtnStartTask.Enabled = canStartTask;
            BtnStartTask.Text = canStartTask ? TranslationStatusStart : TranslationNotAllowed;
        }

    }
}
