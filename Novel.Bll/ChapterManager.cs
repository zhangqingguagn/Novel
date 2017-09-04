using Novel.Bll.Entities;
using Novel.Bll.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Bll
{
    public class ChapterManager
    {
        public List<ChapterEntity> GetChaptersFromNovelSource(int novelId)
        {
            var novel = new NovelManager().GetNovel(novelId);
            var source = new NovelSourceManager().GetSource(novel.SourceID);
            var url = new Uri(novel.ChapterDirectoryUrl);

            var chapterNodes = new HtmlHelper(url).GetNodeCollectionByXPath(source.ChapterDirectoryXPath);

            var host = "";
            var href = chapterNodes.FirstOrDefault().GetAttributeValue("href", "");
            if (href.Trim().StartsWith("http") == false)
            {
                host = url.Scheme + "://" + url.Authority;
            }

            int id = 0;
            return chapterNodes.Select(s => new ChapterEntity()
            {
                ID = id++,
                SourceUrl = host + s.GetAttributeValue("href", ""),
                Body = "",
                Title = s.InnerText
            }).ToList();
        }
    }
}
