using Novel.Bll.DB;
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

            var chapters = chapterNodes.Select(s => new tChapter()
            {
                Body = null,
                ID = 0,
                NovelID = novelId,
                NextChapterID = null,
                PrevChapterID = null,
                SourceUrl = s.GetAttributeValue("href", "#").ToString(),
                Title = s.InnerText,
                Sort = 0
            }).ToList();

            int? nextChapterId = 0;
            int? prevChapterId = 0;
            using (var db = new NovelDbContext())
            {
                db.tChapters.RemoveRange(db.tChapters.Where(s => s.NovelID == novelId));
                int pagesize = 30;
                int pageindex = 0;
                while (pagesize * pageindex < chapters.Count())
                {
                    var items = chapters.Skip(pageindex * pagesize).Take(pagesize).ToList();

                    db.tChapters.AddRange(items);
                    db.SaveChanges();

                    pageindex++;
                }

                for (int i = 0; i < chapters.Count(); i++)
                {
                    if (i != 0)
                    {
                        prevChapterId = chapters.ElementAt(i - 1).ID;
                    }
                    else
                    {
                        prevChapterId = null;
                    }
                    if (i != chapters.Count() - 1)
                    {
                        nextChapterId = chapters.ElementAt(i + 1).ID;
                    }
                    else
                    {
                        nextChapterId = null;
                    }
                    chapters.ElementAt(i).NextChapterID = nextChapterId;
                    chapters.ElementAt(i).PrevChapterID = prevChapterId;
                    if (i % pagesize == pagesize-1)
                    {
                        db.SaveChanges();
                    }
                }
                db.SaveChanges();

            }
        }

        public tChapter GetChapter(int id)
        {
            using (var db = new NovelDbContext())
            {
                var chapter = db.tChapters.Where(s => s.ID == id).FirstOrDefault();
                if (chapter == null)
                {
                    return null;
                }

                var novel = db.tNovels.FirstOrDefault(s => s.ID == chapter.NovelID);
                var source = db.tSources.FirstOrDefault(s => s.ID == novel.SourceID);

                if (string.IsNullOrEmpty(chapter.Body))
                {
                    // 从资源服务器获取小说内容
                    // 保存到数据库

                    var body = new HtmlHelper(new Uri(chapter.SourceUrl)).GetSingleInnerTextByXPath(source.ChapterBodyXpath);

                    chapter.Body = body;
                    db.SaveChanges();
                }

                return chapter;
            }
        }

        public List<tChapter> GetChaptersByNovelId(int novelId)
        {
            using (var db = new NovelDbContext())
            {
                return db.tChapters.Where(s=>s.NovelID == novelId).ToList();
            }
        }

    }
}
