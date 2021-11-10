using FFMpegCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project.STT.SGT.Tool._2111.Extensions.FFMPEG
{
    public static class MediaInfoExtensions
    {
        public static string AudioToSummary(this IMediaAnalysis d)
        {
            var a = d.PrimaryAudioStream;
            if (null == a) return "这是一个无音频的媒体流";
            return JsonSerializer.Serialize(a);
        }
    }
}
