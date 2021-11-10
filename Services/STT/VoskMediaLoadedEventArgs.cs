using FFMpegCore;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.STT.SGT.Tool._2111.Services.STT
{
    public class VoskMediaLoadedEventArgs : EventArgs
    {
        public IMediaAnalysis Wave { get; private set; }

        public VoskMediaLoadedEventArgs(IMediaAnalysis wave)
        {
            this.Wave = wave;
        }
    }
}
