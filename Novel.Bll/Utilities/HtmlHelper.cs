using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Bll.Utilities
{
    public class HtmlHelper
    {
        public string Url { get; set; }
        public HtmlHelper(Uri url)
        {
            this.Url = url.ToString();
        }

        public HtmlDocument GetHtmlDocument()
        {
            HtmlAgilityPack.HtmlWeb hw = new HtmlAgilityPack.HtmlWeb();
            return hw.Load(this.Url);
        }

        public HtmlNode GetDocmentNode()
        {
            return GetHtmlDocument().DocumentNode;
        }

        public string GetSingleInnerTextByXPath(string xpath)
        {
            var node =  GetDocmentNode().SelectSingleNode(xpath);

            return getInnerText(node);
        }
        public List<string> GetInnerTextsByXPath(string xpath)
        {
            return GetDocmentNode().SelectNodes(xpath)
                .Select(s => getInnerText(s))
                .ToList();
        }
        public List<string> GetHtmlsByXPath(string xpath)
        {
            return GetDocmentNode().SelectNodes(xpath)
                .Select(s => s.OuterHtml)
                .ToList();
        }
        public HtmlNodeCollection GetNodeCollectionByXPath(string xpath)
        {
            return GetDocmentNode().SelectNodes(xpath);
        }
        public List<string> GetAttributesByXPath(string xpath,string attribute)
        {
            return GetDocmentNode().SelectNodes(xpath)
                .Select(s => s.GetAttributeValue(attribute, ""))
                .ToList();
        }

        private string getInnerText(HtmlNode node)
        {
            var text = node.InnerHtml;

            text = text.Replace("&nbsp;", "");

            return text;
        }
    }
}
