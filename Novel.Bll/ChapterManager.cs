using Novel.Bll.Entities;
using Novel.Bll.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
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

            var chapterNodes = GetChaptersHtmlFromNovelSource(novelId);

            var id = 1;

            return chapterNodes.Select(s => new ChapterEntity()
            {
                ID = id++,
                SourceUrl = s.GetAttributeValue("href", ""),
                Body = "",
                Title = s.InnerText
            }).ToList();
        }
        /// <summary>
        /// 从小说服务器获取小说章节列表
        /// </summary>
        /// <param name="novelId"></param>
        /// <returns></returns>
        private HtmlAgilityPack.HtmlNodeCollection GetChaptersHtmlFromNovelSource(int novelId)
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

                foreach (var item in chapterNodes)
                {
                    item.SetAttributeValue("href", host + item.GetAttributeValue("href", ""));
                }
            }

            return chapterNodes;
        }
        /// <summary>
        /// 从小说服务器下载章节列表，保存到本地
        /// </summary>
        /// <param name="novelId"></param>
        /// <returns></returns>
        public void DownloadChapters(int novelId)
        {
            var novel = new NovelManager().GetNovel(novelId);

            var chapterNodes = GetChaptersHtmlFromNovelSource(novelId);

            var chapterHtmls = chapterNodes.Select(s => s.OuterHtml.ToString()).ToList();

            if (Directory.Exists(novel.NovelDirectory) ==false)
            {
                Directory.CreateDirectory(novel.NovelDirectory);
            }

            new FileHelper(novel.ChaptersPath).WriteAllLines(chapterHtmls.ToArray());
        }
    }
}
