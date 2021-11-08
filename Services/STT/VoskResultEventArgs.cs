using System;
using System.Collections.Generic;
using System.Text;

namespace Project.STT.SGT.Tool._2111.Services.STT
{
    public  class VoskResultEventArgs : EventArgs
    {
        public string Message { get; private set; }
        public bool IsPartial { get; private set; }

        public VoskResultEventArgs(string message,bool isPartial)
        {
            this.Message = message;
            this.IsPartial = isPartial;
        }
    }
}
