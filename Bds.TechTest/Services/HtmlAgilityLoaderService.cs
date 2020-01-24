using HtmlAgilityPack;
using System.Web;

namespace Bds.TechTest.Services
{
    public static class HtmlAgilityLoaderService
    {
       public static HtmlDocument ReturnHtmlDocument(this string searchEngineString) 
       { 
            var webpage = new HtmlWeb();
            return webpage.Load(searchEngineString);
       }

       public static string SearchPageTitle(this HtmlDocument htmldocument)
       {
            var titleNode = htmldocument.DocumentNode.SelectSingleNode("//title");
            return HttpUtility.HtmlDecode(titleNode.InnerText);
       }
    }
}