using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.STT.SGT.Tool._2111.Views.App.Main
{
    public class FrmMainSetting
    {
        public ConfigSetting History { get; set; } = new ConfigSetting();
    }
    public class ConfigSetting
    {
        public string MediaSrc { get; set; }
        public string ModelSrc { get; set; }
    }
}
