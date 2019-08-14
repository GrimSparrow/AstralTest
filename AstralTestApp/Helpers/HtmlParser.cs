using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Models;

namespace AstralTestApp.Helpers
{
    public static class HtmlParser
    {
        private static string destUrl = "https://api.hh.ru/vacancies?per_page=50";
        public static void GetHtml()
        {
            WebClient web = new WebClient();
            string htmlStr = web.DownloadString(destUrl);
            HtmlDocument doc = new HtmlDocument();
            List<HtmlNode> nodes = new List<HtmlNode>();
            for (int i = 1; i <= 50; i++)
            {
                doc.LoadHtml(htmlStr+i);
                nodes.AddRange(doc.DocumentNode.SelectNodes("//a[@class='js-vacancy-item-title list-vacancies__title']").ToList());
                if (nodes.Count >= 50)
                {
                    break;
                }
            }
            List<Vacancy> result = new List<Vacancy>();
            foreach (HtmlNode item in nodes)
            {
                foreach (HtmlNode node in item.SelectNodes("//a[@class='js-vacancy-item-title list-vacancies__title']//span"))
                {
                    string value = node.InnerText;
                    // etc...
                }
                /*var name = child...SelectSingleNode("//a[@class='js-vacancy-item-title list-vacancies__title']").Attributes["title"];
                    var org = item.SelectSingleNode("//a[@class='list-vacancies__company-title']");
                    var salary = item.SelectSingleNode("//div[@class='list-vacancies__salary']");
                    var v = new Vacancy { Name = string.Join(" ", name.Value.Replace("\n", string.Empty).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)), Org = org.InnerText };
                    result.Add(v);*/
                
            }
            //HtmlNode[] nodes = doc.DocumentNode.SelectNodes("//a").Where(x => x.InnerHtml.Contains("div2")).ToArray();
            //var node = doc.DocumentNode.SelectNodes("//a[@class='js-vacancy-item-title list-vacancies__title']//span");
            var t = doc;
        }
    }
}
