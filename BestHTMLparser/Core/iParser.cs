using AngleSharp.Dom.Html;

namespace BestHTMLparser.Core
{
    internal interface iParser<T> where T : class
    {
        T Parse(IHtmlDocument htmlDocument);
    }
}