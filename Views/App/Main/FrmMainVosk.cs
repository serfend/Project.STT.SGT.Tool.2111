using NLog;
using Project.STT.SGT.Tool._2111.Extensions.NAudio;
using Project.STT.SGT.Tool._2111.Services.STT;
using Project.STT.SGT.Tool._2111.Services.STT.VoskApiResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project.STT.SGT.Tool._2111
{

    /// <summary>
    /// Vosk
    /// </summary>
    public partial class FrmMain
    {
        private VoskApi v;
        private void VoskCallBack()
        {
            v = new VoskApi();
            v.OnResult += (sender, e) =>
            {
                var partialResult = JsonSerializer.Deserialize<VoskPartialResult>(e.Message);
                m_SyncContext.Post(d =>
                {
                    this.TxtTemp.Text = d as string;
                }, partialResult.Partial);
                logger.ActionWithLabel((l, m) => l.Log<string>(LogLevel.Info, m), $"更新识别结果:{partialResult.Partial}");

                //var data = new string[] {
                //    DateTime.Now.ToString(),
                //    "",
                //    "",
                //    e.Message
                //};
                //m_SyncContext.Post((d) =>
                //{
                //    this.LstTranslate.Items.Insert(0, new ListViewItem(d as string[]));
                //}, data);
            };
            v.OnFinnalResult += (sender, e) =>
            {
                logger.ActionWithLabel((l, m) => l.Log<string>(LogLevel.Info, m), "完成任务");
                BtnStartTask.Text = TranslationStatusStart;
            };
            v.OnMediaLoaded += (sender, e) =>
            {
                logger.ActionWithLabel((l, m) => l.Log<string>(LogLevel.Info, m), $"音频已加载:{e.Wave.ToSummary()}");
            };
        }

    }
}
