namespace BestHTMLparser.Core
{
    internal interface iParserSettings
    {
        string BaseUrl { get; set; }

        string Prefix { get; set; }

        // page indexes

        int StartPoint { get; set; }

        int EndPoint { get; set; }
    }
}