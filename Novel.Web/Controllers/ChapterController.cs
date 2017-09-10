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
        public ActionResult Index(int novelId)
        {
            var chapters = new ChapterManager().GetChaptersByNovelId(novelId);

            return View(chapters);
        }
        public ActionResult Details(int chapterId)
        {
            var chapter = new ChapterManager().GetChapter(chapterId);
            if (chapter == null)
            {
                return Content("章节错误，请返回章节目录！");
            }
            return View(chapter);
        }

        [HttpGet]
        public ActionResult GetChapter(int chapterId)
        {
            var novel = new ChapterManager().GetChapter(chapterId);
            if (novel == null)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = true, data = novel }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Download(int novelId)
        {
            new ChapterManager().DownloadChapters(novelId);
            return Content("下载成功！");
        }
    }
}