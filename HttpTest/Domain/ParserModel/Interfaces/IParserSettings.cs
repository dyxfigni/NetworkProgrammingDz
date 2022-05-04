using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpTest
{
    public interface IParserSettings
    {
        string Url { get; set; }
        int Range { get; set; }
    }
}
