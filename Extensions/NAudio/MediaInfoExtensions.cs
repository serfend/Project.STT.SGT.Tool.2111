using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.STT.SGT.Tool._2111.Extensions.NAudio
{
    public static class MediaInfoExtensions
    {
        public static string ToSummary(this WaveFileReader wave)
        {
            var len = wave.TotalTime;
            var sample = wave.WaveFormat.SampleRate;
            var rate = wave.WaveFormat.AverageBytesPerSecond;
            var channel = wave.WaveFormat.Channels;
            var encoding = wave.WaveFormat.Encoding.ToString();
            return $"总时长:{len.ToString("g")};{sample/1e3}KHZ;{1e2*(int)(rate / 1e5)}KB/s;声道数:{channel};编码:{encoding}";
        }
    }
}
