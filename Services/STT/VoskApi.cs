using NAudio.Wave;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vosk;

namespace Project.STT.SGT.Tool._2111.Services.STT
{
    public class VoskApi
    {

        public event EventHandler<VoskResultEventArgs> OnFinnalResult;
        public event EventHandler<VoskResultEventArgs> OnResult;
        public event EventHandler<VoskMediaLoadedEventArgs> OnMediaLoaded;
        private Model model;

        public Model Model { get => model; set => model = value; }
        public void LoadModel(string path)
        {
            if (!Directory.Exists(path)) return;
            if (null != Model) Model.Dispose();
            Model = new Model(path);
        }
        public bool IsRunning { get; private set; }
        public WaveFileReader WaveFile { get => waveFile; private set => waveFile = value; }

        private WaveFileReader waveFile;
        private Stream source;
        public void LoadAudio(string fileName)
        {
            source = File.OpenRead(fileName);
            if (WaveFile != null)
            {
                WaveFile.Dispose();
            }
            WaveFile = new WaveFileReader(source);
            OnMediaLoaded?.Invoke(this, new VoskMediaLoadedEventArgs(WaveFile));
        }
        public Task StartTask() => StartTask(CancellationToken.None);
        public Task StartTask(CancellationToken token)
        {
            if (WaveFile == null) throw new ArgumentNullException(nameof(WaveFile));
            if (IsRunning) return Task.CompletedTask;
            IsRunning = true;
            var task = new Task(() =>
            {
                byte[] buffer = new byte[4096];
                int bytesRead;
                using var rec = new VoskRecognizer(Model, (float)WaveFile.WaveFormat.SampleRate);
                rec.SetMaxAlternatives(0);
                rec.SetWords(true);
                WaveFile.Seek(0, SeekOrigin.Begin);
                while ((bytesRead = WaveFile.Read(buffer, 0, buffer.Length)) > 0)
                {
                    if (token.IsCancellationRequested)
                    {
                        IsRunning = false;
                        return;
                    }
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
                IsRunning = false;
            }, token);
            task.Start();
            return task;
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
