using Novel.Bll.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Novel.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = new Uri("http://www.xxbiquge.com/1_1385/1108010.html");
            var xpath = "//*[@id=\"content\"]";
           
                 var html = new HtmlHelper(url).GetSingleInnerTextByXPath(xpath);

            Console.Write(html);

            url = new Uri("http://www.xxbiquge.com/1_1385/");
            xpath = "//div[@id=\"list\"]/dl/dd/a";

            var htmls = new HtmlHelper(url).GetHtmlsByXPath(xpath);
            if (htmls[0].Trim().StartsWith("html")==false)
            {
                var host = url.Scheme + "://" + url.Authority;

                htmls = htmls.Select(s => s.Replace("href=\"", "href=\"" + host)).ToList();
            }

            Console.ReadKey();
        }
        static void AddNovel(string title,string chapters,string xpath)
        {
            new Novel.Bll.NovelManager().AddNovel(title, chapters, xpath);
        }
    }
}
