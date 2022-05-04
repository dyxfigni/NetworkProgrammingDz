using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace HttpTest
{
    internal class ParserClass : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();

            var items = document
                .QuerySelectorAll("a")
                .Where(item => item.ClassName != null
                               && item.ClassName
                                   .Contains("lhead"));


            foreach (IElement item in items)
            {
                list.Add(item.TextContent);
            }

            return list.ToArray();
        }
    }
}
