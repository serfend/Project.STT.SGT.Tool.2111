using FFMpegCore;
using FFMpegCore.Enums;
using FFMpegCore.Pipes;
using NAudio.Wave;
using NLog;
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
        private Logger logger;

        public event EventHandler<VoskFinnalResultEventArgs> OnFinnalResult;
        public event EventHandler<VoskResultEventArgs> OnResult;
        public event EventHandler<VoskMediaLoadedEventArgs> OnMediaLoaded;
        public event EventHandler OnModelLoaded;


        private Model model;
        public VoskApi()
        {
            logger = LogManager.GetCurrentClassLogger();
        }
        static VoskApi()
        {
            GlobalFFOptions.Configure(d =>
            {

            });
        }
        private VoskRecognizer rec;
        public Model Model { get => model; set => model = value; }
        public void LoadModel(string path)
        {
            if (!Directory.Exists(path)) return;
            if (null != Model) Model.Dispose();
            Model = new Model(path);
            int tryTime = 0;
            while (tryTime++ < 10)
            {
                try
                {
                    Rec = new VoskRecognizer(Model, MySampleRate);
                }
                catch (Exception e)
                {
                    logger.Warn($"加载模型失败:{e.Message}");
                }
                if (Rec != null) break;
                Thread.Sleep((int)5e3);
            }
            if (tryTime > 10)
                logger.Error($"模型多次加载失败，已放弃。");
            OnModelLoaded?.Invoke(this, new EventArgs());
        }
        public bool IsRunning { get; private set; }
        public IMediaAnalysis MediaMeta { get; set; }
        public VoskRecognizer Rec { get => rec; set => rec = value; }

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
                Rec.SetMaxAlternatives(0);
                Rec.SetWords(true);
                waveStream.Seek(0, SeekOrigin.Begin);
                while ((bytesRead = waveStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    if (token.IsCancellationRequested)
                    {
                        IsRunning = false;
                        return;
                    }
                    var accepted = Rec.AcceptWaveform(buffer, bytesRead);
                    var e = new VoskResultEventArgs(Rec.PartialResult(), !accepted);
                    if (accepted) OnFinnalResult?.Invoke(this, new VoskFinnalResultEventArgs(Rec.FinalResult(), false));
                    if (lastEvent == null || e.Data.Partial != lastEvent.Data.Partial)
                    {
                        lastEvent = e;
                        OnResult?.Invoke(this, e);
                    }
                }
                OnFinnalResult?.Invoke(this, new VoskFinnalResultEventArgs(Rec.FinalResult(), true));
                IsRunning = false;
            }, token);
            task.Start();
            return task;
        }

    }
}
