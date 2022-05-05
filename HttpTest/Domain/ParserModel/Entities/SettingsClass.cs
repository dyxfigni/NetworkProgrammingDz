using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpTest
{
    internal class SettingsClass : IParserSettings
    {
        public SettingsClass(int range, string url)
        {
            Range = range;
            Url = url;
        }

        public string Url { get; set; }
        public int Range { get; set; }
    }
}
