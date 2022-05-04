using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpTest
{
    public interface IParserSettings
    {
        string BaseUrl { get; set; }

        int StartPoint { get; set; }
        int EndPoint { get; set; }

    }
}
