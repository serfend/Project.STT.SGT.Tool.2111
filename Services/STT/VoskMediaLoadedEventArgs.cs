using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.STT.SGT.Tool._2111.Services.STT
{
    public class VoskMediaLoadedEventArgs : EventArgs
    {
        public WaveFileReader Wave { get; private set; }

        public VoskMediaLoadedEventArgs(WaveFileReader wave)
        {
            this.Wave = wave;
        }
    }
}
