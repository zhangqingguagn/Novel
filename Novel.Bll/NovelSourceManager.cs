using Novel.Bll.DB;
using Novel.Bll.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Bll
{
    public class NovelSourceManager
    {
        private static List<NovelSource> novelSources
        {
            get
            {
                return new List<NovelSource>() {
                    new NovelSource()
                    {
                        ID=1,
                        Name = "笔趣阁",
                        ChapterDirectoryXPath = "//div[@id=\"list\"]/dl/dd/a",
                        ChapterBodyXpath="//*[@id=\"content\"]",
                        NextChapterXpath="",
                        PrevChapterXpath=""
                    }
                };
            }
        }
        public tSource GetSource(int id)
        {
            using (var db = new NovelDbContext())
            {
                return db.tSources.Where(s => s.ID == id).FirstOrDefault();
            }
        }
        public void AddSource(tSource source)
        {
            using (var db = new NovelDbContext())
            {
                db.tSources.Add(source);
                db.SaveChanges();
            }
        }
    }
}
