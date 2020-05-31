using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TextExtractionService.Backend.Tesseract;

namespace TextExtractionService.Controllers
{
    public class HomeController : Controller
    {
        public string tessdataPath { get; private set; }
        public string mediaPath { get; private set; }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            tessdataPath = Server.MapPath(@"tessdata");
            mediaPath = Server.MapPath(@"Media");

            var engine = new TextExtractor(tessdataPath, mediaPath);

            var result = engine.ExtractFromImageTest();

            if (!result)
            {
                return View();
            }

            return View(engine.extraction);
        }

        public string GetTessdataPath()
        {
            return Server.MapPath(@"tessdata");
        }

        public string GetMediaPath()
        {
            return Server.MapPath(@"Media");
        }
    }
}
