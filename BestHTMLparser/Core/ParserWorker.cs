using AngleSharp.Parser.Html;
using System;
using System.Threading.Tasks;

namespace BestHTMLparser.Core
{
    class ParserWorker<T> where T : class
    {
        iParser<T> parser;
        iParserSettings parserSettings;
        HtmlLoader loader;

        #region ParserProperties

        // parse unit & parser ref
        public event Action<object, T> OnNewData;
        public event Action<object> OnComplete;

        public iParser<T> GetIParser
        {
            get
            {
                return parser;
            }
            set
            {
                parser = value;
            }
        }

        public iParserSettings GetParserSettings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }

        public bool IsActive { get; private set; }

        #endregion

        public ParserWorker(iParser<T> parser)
        {
            this.parser = parser;
        }

        public ParserWorker(iParser<T> parser, iParserSettings parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;
        }

        public void Start()
        {
            IsActive = true;
            Worker();
        }

        public void Abort()
        {
            IsActive = false;
        }

        // control parsing
        private async void Worker()
        {
            for (var i = parserSettings.StartPoint; i <= parserSettings.EndPoint; i++)
            {
                if (!IsActive)
                {
                    OnComplete?.Invoke(this);
                    return;
                }

                var source = await loader.GetSourceByPageId(i);
                var domParser = new HtmlParser();

                var document = await domParser.ParseAsync(source);

                var result = parser.Parse(document);

                OnNewData?.Invoke(this, result);
            }

            OnComplete?.Invoke(this);
            IsActive = false;
        }
    }
}
