using NLog;
using Project.STT.SGT.Tool._2111.Extensions.FFMPEG;
using Project.STT.SGT.Tool._2111.Extensions.NAudio;
using Project.STT.SGT.Tool._2111.Services.STT;
using Project.STT.SGT.Tool._2111.Services.STT.VoskApiResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                m_SyncContext.Post(d =>
                {
                    this.TxtTemp.Text = d as string;
                }, e.Data.Partial);
                logger.ActionWithLabel((l, m) => l.Log<string>(LogLevel.Info, m), $"更新识别结果:{e.Data.Partial}");

            };
            v.OnFinnalResult += (sender, events) =>
            {
                logger.ActionWithLabel((l, m) => l.Log<string>(LogLevel.Info, m), "本句话完成");
                m_SyncContext.Post(obj =>
                {
                    var e = obj as VoskFinnalResultEventArgs;
                    var data = new string[] {
                        Math.Round(e.Start,3).ToString(),
                        Math.Round(e.End,3).ToString(),
                        e.TotalWords.ToString(),
                        Math.Round(e.Confidence,3).ToString(),
                        e.Content
                    };
                    this.LstTranslate.Items.Insert(0, new ListViewItem(data as string[]));
                }, events);
            };
            v.OnMediaLoaded += (sender, e) =>
            {
                logger.ActionWithLabel((l, m) => l.Log<string>(LogLevel.Info, m), $"音频已加载:{e.Wave?.AudioToSummary()}");
                m_SyncContext.Post(d =>
                {
                    CheckCanStartTask();
                }, null);
            };
        }

    }
}
