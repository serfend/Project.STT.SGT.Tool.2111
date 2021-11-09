using NLog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Project.STT.SGT.Tool._2111.Services.Log
{
    public class TooltipLabelLogger : NLog.Logger
    {
        public readonly static Action<Logger, string> InfoLog = (l, m) => l.Log<string>(LogLevel.Info, m);
        public void ActionWithLabel(Action<Logger, string> action, string message)
        {
            label.Text = message;
            action.Invoke(this, message);
        }
        private readonly ToolStripStatusLabel label;

        public TooltipLabelLogger(ToolStripStatusLabel label)
        {
            this.label = label;
            this.LoggerReconfigured += TooltipLabelLogger_LoggerReconfigured;
        }

        private void TooltipLabelLogger_LoggerReconfigured(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
