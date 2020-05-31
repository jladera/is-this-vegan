using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TextExtractionService.Backend.Tesseract;

namespace TextExtractionService.Controllers
{
    public class TextExtractorController : ApiController
    {
        public string tessdataPath { get; private set; }
        public string mediaPath { get; private set; }
        private TextExtractor engine;

        public TextExtractorController()
        {
            //var controller = new HomeController();
            //tessdataPath = controller.GetTessdataPath();
            //mediaPath = controller.GetMediaPath();
            tessdataPath = System.Web.Hosting.HostingEnvironment.MapPath("~/tessdata");
            mediaPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Media");
            engine = new TextExtractor(tessdataPath, mediaPath);
        }

        // GET api/textextractor
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/textextractor/test
        public IEnumerable<string> Get(string id)
        
        {
            // May not use parameterless get
            if (string.IsNullOrEmpty(id) ||
                string.IsNullOrWhiteSpace(id))
            {
                return new string[] { "Error", "Invalid route. Must provide parameters." };
            }

            // Must be a valid get option
            if (!id.Equals("test"))
            {
                return new string[] { "Error", "Invalid route. Parameter given is not valid." };
            }

            var result = engine.ExtractFromImageTest();

            // If error in text extraction process
            if (!result)
            {
                return new string[] { 
                    "Error", 
                    String.Format(
                        "{0}. Inner Exception: {1}.",
                        engine.exception.Message,
                        engine.exception.InnerException
                    )
                };
            }


            return new string[] { 
                engine.extraction.meanConfidenceLabel, 
                engine.extraction.resultText 
            };
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
