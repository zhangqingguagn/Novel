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
            var chepters = new ChapterManager().GetChaptersByNovelId(novelId);

            return View(chepters);
        }
    }
}