using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;

namespace HttpTest
{
    public class ParserManager<T> where T : class
    {
        private IParser<T> parser;
        private IParserSettings parserSettings;

        private bool isActive;

        public event Action<object, T> OnNewData;
        public event Action<object> OnCompleted; 

        public IParser<T> Parser {
            get => parser;
            set => parser = value;
        }

        public IParserSettings ParserSettings {
            get => parserSettings;
            set {
                parserSettings = value;
            }
        }

        public bool IsActive {
            get => isActive;
        }


        public ParserManager(IParser<T> parser)
        {
            this.parser = parser;
        }

        public ParserManager(IParser<T> parser,
            IParserSettings parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;

        }

        public void Start()
        {
            isActive = true;
            Manager();
        }

        public void Abort()
        {
            isActive = false;
        }

        private async void Manager()
        {
            //for (int i = parserSettings.StartPoint;
            //     i< parserSettings.EndPoint; i++)
            //{
            //    if (!isActive)
            //    {
            //        OnCompleted?.Invoke(this);
            //        return;
            //    }


            //    var domParser = new HtmlParser();
            //    var document = await domParser
            //        .ParseDocumentAsync(parserSettings.Url);

            //    var result = parser.Parse(document);

            //    OnNewData?.Invoke(this, result);
            //}

            //debug
            if (!isActive)
            {
                OnCompleted?.Invoke(this);
                return;
            }


            var domParser = new HtmlParser();
            var document = await domParser
                .ParseDocumentAsync(parserSettings.Url);

            var result = parser.Parse(document);

            OnNewData?.Invoke(this, result);


            OnCompleted?.Invoke(this);
            isActive = false;

        }
    }
}
