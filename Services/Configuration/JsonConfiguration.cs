using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Project.STT.SGT.Tool._2111.Services.Configuration
{
    public class JsonConfiguration<T> where T:class
    {
        public T Data { get; private set; }
        public JsonConfiguration(string path, bool immediateLoad = false)
        {
            Path = path;
            if (!File.Exists(path)) File.CreateText(path).Dispose();
            if (immediateLoad) Reload();
        }
        public void Reload()
        {
            var content = File.ReadAllText(Path);
            Data = JsonSerializer.Deserialize<T>(content);
        }
        public void Save()
        {
            var content = JsonSerializer.Serialize(Data);
            File.WriteAllText(Path, content, Encoding.UTF8);
        }
        public string Path { get; }
    }

}
