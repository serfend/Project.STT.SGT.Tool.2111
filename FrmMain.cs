using Vosk;

using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Project.STT.SGT.Tool._2111.Services.STT;
using System.Diagnostics;
using System.Text.Json.Serialization;
using Project.STT.SGT.Tool._2111.Services.Log;
using NLog;

namespace Project.STT.SGT.Tool._2111
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            logger = new TooltipLabelLogger(this.StatusMainLog);
            this.Load += FrmMain_Load;
        }
        private VoskApi v;
        private readonly TooltipLabelLogger logger;
        private void FrmMain_Load(object sender, EventArgs e)
        {
            v = new VoskApi();
            v.OnResult += V_OnResult;
            v.OnFinnalResult += V_OnFinnalResult;
        }

        private void V_OnFinnalResult(object sender, VoskResultEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            var title = "选择需要语音识别的文件";
            logger.ActionWithLabel(TooltipLabelLogger.InfoLog, title);
            var wavFileDialog = new OpenFileDialog() { Title = title };
            var result = wavFileDialog.ShowDialog(this);
            if (result != DialogResult.OK && result != DialogResult.Yes) return;
            this.TxtMediaSrc.Text = wavFileDialog.FileName;

            logger.ActionWithLabel((l, m) => l.Log<string>(LogLevel.Info, m), "执行完成");
        }

        private void V_OnResult(object sender, VoskResultEventArgs e)
        {
            var data = new string[] {
                DateTime.Now.ToString(),
                "",
                "",
                e.Message
            };

            this.LstTranslate.Items.Insert(0, new ListViewItem(data));
        }

        private void TextTemp_Click(object sender, EventArgs e)
        {
            // TODO 开始说话，接入语音输入
        }
    }
}