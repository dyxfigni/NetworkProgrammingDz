using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpTest
{
    internal class SettingsClass : IParserSettings
    {
        public SettingsClass(int start, int end, string url)
        {
            StartPoint = start;
            EndPoint = end;
            Url = url;
        }
        public string Url { get; set; } 
        public string Prefix { get; set; }
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}
