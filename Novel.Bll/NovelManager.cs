using Novel.Bll.DB;
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

        public List<tNovel> GetNovels()
        {
            using (var db = new NovelDbContext())
            {
                return db.tNovels.ToList();
            }
        }

        public NovelManager()
        {
        }
        public tNovel GetNovel(int id)
        {
            using (var db = new NovelDbContext())
            {
                return db.tNovels.Where(s=>s.ID == id).FirstOrDefault();
            }
        }

        public void AddNovel(tNovel novel)
        {
            using (var db = new NovelDbContext())
            {
                db.tNovels.Add(novel);
                db.SaveChanges();
            }
        }
    }
}
