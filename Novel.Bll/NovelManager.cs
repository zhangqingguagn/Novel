using Novel.Bll.Entities;
using Novel.Bll.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Bll
{
    public class NovelManager
    {
        public static List<NovelEntity> novels
        {
            get
            {
                return new List<NovelEntity>()
                {
                    new NovelEntity()
                    {
                        ID=1,
                        ChapterDirectoryUrl="http://www.xxbiquge.com/1_1385/",
                        SourceID=1,
                        Title="杀神"
                    }
                };
            }
        }

        public object GetNovels()
        {
            return novels;
        }

        public NovelManager()
        {
        }
        public NovelEntity GetNovel(int id)
        {
            Model1 db = new Model1();
            db.MyEntities.Add(new MyEntity()
            {
                Id = 0,
                Name = "Entity Name"
            });
            db.SaveChanges();

            return novels.Where(s => s.ID == id).FirstOrDefault();
        }

        public void AddNovel(string title, string chapterUrl, int sourceID)
        {
            int id = novels.Any()? novels.Max(s => s.ID):0 + 1;
            novels.Add(new NovelEntity()
            {
                ID = id,
                ChapterDirectoryUrl = chapterUrl,
                SourceID = sourceID,
                Title = title
            });
        }
    }
}
