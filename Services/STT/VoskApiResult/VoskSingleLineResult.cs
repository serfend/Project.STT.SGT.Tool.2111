using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Project.STT.SGT.Tool._2111.Services.STT.VoskApiResult
{
    public class VoskSingleLineResult
    {
        /// <summary>
        /// 词语识别结果
        /// </summary>
        [JsonPropertyName("result")]
        public IEnumerable<VoskSingleWordResult> Result { get; set; }
        /// <summary>
        /// 识别完成的文本
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
    public interface IVoskSingleWordResult
    {

        /// <summary>
        /// 识别完成的文本
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 置信度
        /// </summary>
        public double Confidence { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public double Start { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public double End { get; set; }

    }
    public class VoskSingleWordResult : IVoskSingleWordResult
    {
        [JsonPropertyName("word")]
        public string Content { get; set; }
        [JsonPropertyName("conf")]
        public double Confidence { get; set; }
        [JsonPropertyName("start")]
        public double Start { get; set; }
        [JsonPropertyName("end")]
        public double End { get; set; }
        /*
                 * {
              "conf" : 1.000000,
              "end" : 4.200000,
              "start" : 3.780000,
              "word" : "语音"
            }
         */
    }
}
