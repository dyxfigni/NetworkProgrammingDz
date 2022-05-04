using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;

namespace HttpTest
{
    //все классы будут возвращать любые данные сылочного типа
    public interface IParser<T> where T : class
    {
         T Parse(IHtmlDocument document);
    }
}
