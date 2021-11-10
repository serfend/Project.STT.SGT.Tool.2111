using Project.STT.SGT.Tool._2111.Services.STT.VoskApiResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Project.STT.SGT.Tool._2111.Services.STT
{
    public class VoskResultEventArgs : EventArgs
    {

        public VoskPartialResult Data { get; private set; }
        public bool IsPartial { get; private set; }

        public VoskResultEventArgs(string message, bool isPartial)
        {
            Data = JsonSerializer.Deserialize<VoskPartialResult>(message);
            this.IsPartial = isPartial;
        }
    }
    public class VoskFinnalResultEventArgs : EventArgs, IVoskSingleWordResult
    {
        public VoskFinnalResultEventArgs(string message)
        {
            Data = JsonSerializer.Deserialize<VoskSingleLineResult>(message);
            Content = Data.Text;
            Caculate();
        }
        private void Caculate() {
            foreach(var r in Data.Result)
            {
                TotalWords++;
                Confidence += r.Confidence;
            }
            if (TotalWords > 0) Confidence /= TotalWords;
            Start = Data.Result.FirstOrDefault()?.Start ?? 0;
            End = Data.Result.LastOrDefault()?.Start ?? 0;
        }
        /// <summary>
        /// 词总数
        /// </summary>
        public int TotalWords { get; set; }
        public VoskSingleLineResult Data { get; set; }
        public string Content { get ;set; }
        public double Confidence { get ;set; }
        public double Start { get; set; }
        public double End { get ;set; }
    }
}
