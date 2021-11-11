using Project.STT.SGT.Tool._2111.Services.STT.VoskApiResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Project.STT.SGT.Tool._2111.Services.STT
{
    public class VoskResultEventArgs : EventArgs
    {

        public VoskPartialResult Data { get; private set; }
        public bool IsPartial { get; private set; }

        public VoskResultEventArgs(string message, bool isPartial)
        {
            Data = JsonSerializer.Deserialize<VoskPartialResult>(message);
            Data.Partial = Regex.Replace(Data.Partial, @"\[.*\]", string.Empty);
            this.IsPartial = isPartial;
        }
    }
    public class VoskFinnalResultEventArgs : EventArgs, IVoskSingleWordResult
    {
        public VoskFinnalResultEventArgs(string message, bool isCompleted)
        {
            this.IsCompleted = isCompleted;
            Data = JsonSerializer.Deserialize<VoskSingleLineResult>(message);
            Content = Regex.Replace(Data.Text, @"\[.*\]", string.Empty);
            Caculate();
        }
        private void Caculate()
        {
            if (Data.Result == null) return;
            foreach (var r in Data.Result)
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
        public string Content { get; set; }
        public double Confidence { get; set; }
        public double Start { get; set; }
        public double End { get; set; }
        /// <summary>
        /// 是否已完成
        /// </summary>
        public bool IsCompleted { get; set; }
    }
}
