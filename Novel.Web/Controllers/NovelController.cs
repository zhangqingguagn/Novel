using Novel.Bll;
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