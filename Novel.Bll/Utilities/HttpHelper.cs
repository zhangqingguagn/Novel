using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Bll.Utilities
{
    public class HttpHelper
    {
        public string GetHtml(string url)
        {
            var response = new HttpClient().GetStringAsync(url);
            return response.Result;
        }
    }
}
