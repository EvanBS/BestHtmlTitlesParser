using AngleSharp.Dom.Html;
using System.Linq;
using System.Collections.Generic;

namespace BestHTMLparser.Core.Habra
{
    class HabraParser : iParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();

            var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("post__title_link"));

            foreach (var item in items)
            {
                list.Add(item.TextContent); // reference text
            }

            return list.ToArray();
        }
    }
}
