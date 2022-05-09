using AppCrawlerDemo.Data;
using AppCrawlerDemo.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AppCrawlerDemo.Controllers
{

    public class HomeController : Controller
    {
        private Context db = new Context();
        public ActionResult Index()
        {
            ViewBag.url = "https//www.3school.com";
            ViewBag.categories = db.Categories.ToList();
            return View();
        }

        public ActionResult linksDetail(string link, string selector)
        {
            var url = link;
            var web = new HtmlWeb();
            var doc = web.Load(url);
            HashSet<String> Links = new HashSet<string>();
            foreach (HtmlNode linkz in doc.DocumentNode.SelectNodes("//div[@class='" + selector + "']//a[@href]"))
            {
                Links.Add(linkz.GetAttributeValue("href", string.Empty));
            }
            return Json(Links);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool Create([Bind(Include = "SelectorSubUrl,Url,SelectorTitle,SelectorImage,SelectorDescrition,SelectorContent,CategoryId")] Source source)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    source.Id = Guid.NewGuid().ToString();
                    db.Sources.Add(source);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
        }
        public ActionResult ListArticle()
        {

            ViewBag.Message = "Your application description page.";

            return View(db.Article.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool Delete(string Id)
        {
            if (String.IsNullOrEmpty(Id))
            {
                return false;
            }
            Article article = db.Article.Where(x=>x.UrlSource == Id).First();
            if (article == null)
            {
                return false;
            }
            db.Article.Remove(article);
            db.SaveChanges();
            return true;
        }
    }
}