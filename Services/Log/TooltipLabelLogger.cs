using NLog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Project.STT.SGT.Tool._2111.Services.Log
{
    public class TooltipLabelLogger
    {
        public readonly static Action<Logger, string> InfoLog = (l, m) => l.Log<string>(LogLevel.Info, m);
        private readonly Logger logger;
        public void ActionWithLabel(Action<Logger, string> action, string message)
        {
            label.Text = message;
            action.Invoke(logger, message);
        }
        private readonly ToolStripStatusLabel label;

        public TooltipLabelLogger(ToolStripStatusLabel label)
        {
            this.label = label;
            logger = LogManager.GetCurrentClassLogger();
        }

    }
}
