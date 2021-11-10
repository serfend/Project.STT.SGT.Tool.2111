using FFMpegCore;
using FFMpegCore.Enums;
using FFMpegCore.Pipes;
using NAudio.Wave;
using Project.STT.SGT.Tool._2111.Services.STT.VoskApiResult;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vosk;

namespace Project.STT.SGT.Tool._2111.Services.STT
{
    public class VoskApi
    {

        public event EventHandler<VoskFinnalResultEventArgs> OnFinnalResult;
        public event EventHandler<VoskResultEventArgs> OnResult;
        public event EventHandler<VoskMediaLoadedEventArgs> OnMediaLoaded;
        private Model model;
        static VoskApi()
        {
            GlobalFFOptions.Configure(d =>
            {

            });
        }
        public Model Model { get => model; set => model = value; }
        public void LoadModel(string path)
        {
            if (!Directory.Exists(path)) return;
            if (null != Model) Model.Dispose();
            Model = new Model(path);
        }
        public bool IsRunning { get; private set; }
        public IMediaAnalysis MediaMeta { get; set; }
        private MemoryStream waveStream = null;
        private const float MySampleRate = 16000;
        public void LoadAudio(string fileName)
        {
            if (!File.Exists(fileName)) return;
            MediaMeta = FFProbe.Analyse(fileName);
            IsRunning = true;
            waveStream = new MemoryStream();
            FFMpegArguments
                .FromFileInput(fileName)
                .OutputToPipe(new StreamPipeSink(waveStream), opt =>
                     opt
                     .WithAudioSamplingRate((int)MySampleRate)
                     .UsingMultithreading(true)
                     .WithCustomArgument("-ac 1")
                     .WithAudioCodec("pcm_s16le")
                     .ForceFormat("wav")
                )
                .NotifyOnProgress(c =>
                {
                    IsRunning = false;
                    Debug.Print(c.ToString());
                    var file = new FileInfo("temp_convert.wav");
                    if (file.Exists) { }
                    waveStream.Position = 0;
                    using var fs = file.Create();
                    waveStream.CopyTo(fs);
                    OnMediaLoaded?.Invoke(this, new VoskMediaLoadedEventArgs(MediaMeta));
                })
                .ProcessAsynchronously(false);

        }
        public Task StartTask() => StartTask(CancellationToken.None);
        private VoskResultEventArgs lastEvent;
        public Task StartTask(CancellationToken token)
        {
            if (MediaMeta == null) throw new ArgumentNullException(nameof(MediaMeta));
            if (IsRunning) return Task.CompletedTask;
            IsRunning = true;
            var task = new Task(() =>
            {
                byte[] buffer = new byte[4096];
                int bytesRead;
                using var rec = new VoskRecognizer(Model, MySampleRate);
                rec.SetMaxAlternatives(0);
                rec.SetWords(true);
                waveStream.Seek(0, SeekOrigin.Begin);
                while ((bytesRead = waveStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    if (token.IsCancellationRequested)
                    {
                        IsRunning = false;
                        return;
                    }
                    var accepted = rec.AcceptWaveform(buffer, bytesRead);
                    var e = new VoskResultEventArgs(rec.PartialResult(), !accepted);
                    if (accepted) OnFinnalResult?.Invoke(this, new VoskFinnalResultEventArgs(rec.FinalResult()));
                    if (lastEvent == null || e.Data.Partial != lastEvent.Data.Partial)
                    {
                        lastEvent = e;
                        OnResult?.Invoke(this, e);
                    }
                }

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
