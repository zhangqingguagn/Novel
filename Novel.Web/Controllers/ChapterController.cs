using Novel.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Novel.Web.Controllers
{
    public class ChapterController : Controller
    {
        // GET: Chapter
        public ActionResult Index(int novelId)
        {
            var chapters = new ChapterManager().GetChaptersByNovelId(novelId);

            return View(chapters);
        }
        public ActionResult Details(int chapterId)
        {
            var chapter = new ChapterManager().GetChapter(chapterId);
            return View(chapter);
        }
    }
}