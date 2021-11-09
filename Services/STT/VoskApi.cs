using NAudio.Wave;
using System;
using System.IO;
using System.Linq;
using Vosk;

namespace Project.STT.SGT.Tool._2111.Services.STT
{
    public class VoskApi
    {
        
        public event EventHandler<VoskResultEventArgs> OnFinnalResult;
        public event EventHandler<VoskResultEventArgs> OnResult;
        private Model model;

        public Model Model { get => model; set => model = value; }

        public void Test()
        {

            // You can set to -1 to disable logging messages
            Vosk.Vosk.SetLogLevel(0);

            Model = new Model("vosk-model-cn-0.1");
            StartTask("test.wav");
            //DemoFloats(model);
            //DemoSpeaker(model);
        }

        public void StartTask(string fullName)
        {
            using Stream source = File.OpenRead(fullName);
            using var wav = new WaveFileReader(source);

            using var rec = new VoskRecognizer(Model, (float)wav.WaveFormat.SampleRate);
            rec.SetMaxAlternatives(0);
            rec.SetWords(true);
            byte[] buffer = new byte[4096];
            int bytesRead;
            while ((bytesRead = wav.Read(buffer, 0, buffer.Length)) > 0)
            {
                if (rec.AcceptWaveform(buffer, bytesRead))
                {
                    OnResult?.Invoke(this, new VoskResultEventArgs(rec.Result(), false));
                }
                else
                {
                    OnResult?.Invoke(this, new VoskResultEventArgs(rec.PartialResult(), true));
                }
            }
            OnFinnalResult?.Invoke(this, new VoskResultEventArgs(rec.FinalResult(), false));
        }
        public void DemoFloats(Model model)
        {
            // Demo float array
            var rec = new VoskRecognizer(model, 16000.0f);
            using (Stream source = File.OpenRead("test.wav"))
            {
                byte[] buffer = new byte[4096];
                int bytesRead;
                while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                {
                    float[] fbuffer = new float[bytesRead / 2];
                    for (int i = 0, n = 0; i < fbuffer.Length; i++, n += 2)
                    {
                        fbuffer[i] = (short)(buffer[n] | buffer[n + 1] << 8);
                    }
                    if (rec.AcceptWaveform(fbuffer, fbuffer.Length))
                    {
                        OnResult?.Invoke(this, new VoskResultEventArgs(rec.Result(), false));
                    }
                    else
                    {
                        OnResult?.Invoke(this, new VoskResultEventArgs(rec.PartialResult(), true));
                    }
                }
            }
            OnResult?.Invoke(this, new VoskResultEventArgs(rec.FinalResult(), false));
        }

        public void DemoSpeaker(Model model)
        {
            // Output speakers
            var spkModel = new SpkModel("model-spk");
            var rec = new VoskRecognizer(model, 16000.0f);
            rec.SetSpkModel(spkModel);

            using (Stream source = File.OpenRead("test.wav"))
            {
                byte[] buffer = new byte[4096];
                int bytesRead;
                while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                {
                    if (rec.AcceptWaveform(buffer, bytesRead))
                    {
                        OnResult?.Invoke(this, new VoskResultEventArgs(rec.Result(), false));
                    }
                    else
                    {
                        OnResult?.Invoke(this, new VoskResultEventArgs(rec.PartialResult(), true));
                    }
                }
            }
            OnResult?.Invoke(this, new VoskResultEventArgs(rec.FinalResult(), false));
        }
    }
}
