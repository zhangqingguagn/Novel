using Novel.Bll;
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
            new ChapterManager().DownloadChapters(1);

            Console.ReadKey();
        }
        static void AddNovel(string title,string chapters,string xpath)
        {
            new Novel.Bll.NovelManager().AddNovel(title, chapters, 1);
        }
    }
}
