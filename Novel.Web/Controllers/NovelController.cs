using Novel.Bll;
using Novel.Bll.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Novel.Web.Controllers
{
    public class NovelController : Controller
    {
        public ActionResult Index()
        {
            new NovelSourceManager().AddSource(new Bll.DB.tSource()
            {
                ID = 1,
                Name = "笔趣阁",
                ChapterDirectoryXPath = "//div[@id=\"list\"]/dl/dd/a",
                ChapterBodyXpath = "//*[@id=\"content\"]",
                NextChapterXpath = "",
                PrevChapterXpath = ""
            });
            new NovelManager().AddNovel(new tNovel()
            {
                ID = 1,
                ChapterDirectoryUrl = "http://www.xxbiquge.com/1_1385/",
                SourceID = 1,
                Title = "杀神",
            });
            var novels = new NovelManager().GetNovels();
            return View(novels);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var novel = new NovelManager().GetNovel(id);
            return View(novel);
        }
        public ActionResult Details(int id)
        {
            var novel = new NovelManager().GetNovel(id);
            return View(novel);
        }
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}