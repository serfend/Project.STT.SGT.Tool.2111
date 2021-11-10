
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
            this.config = new ("FrmMain.Setting.json");
            this.Load += FrmMain_Load;
        }
        private readonly TooltipLabelLogger logger;
        private JsonConfiguration<FrmMainSetting> config { get;  set; }

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

    }
}