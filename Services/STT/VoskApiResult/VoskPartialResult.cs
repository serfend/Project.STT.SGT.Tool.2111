using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Project.STT.SGT.Tool._2111.Services.STT.VoskApiResult
{
    public class VoskPartialResult
    {
        /// <summary>
        /// 部分内容
        /// </summary>
        [JsonPropertyName("partial")]
        public string Partial { get; set; }
    }
}
