using Is_This_Vegan__Net_.Backend.Ingredient_List;
using Is_This_Vegan__Net_.Models;
using Newtonsoft.Json;
using System.Web.Http;

namespace Is_This_Vegan__Net_.Controllers
{
    public class IngredientListController : ApiController
    {
        public string tessdataPath { get; private set; }
        public string mediaPath { get; private set; }
        private IngredientListBackend backend;

        public IngredientListController()
        {
            //var controller = new HomeController();
            //tessdataPath = controller.GetTessdataPath();
            //mediaPath = controller.GetMediaPath();
            tessdataPath = System.Web.HttpContext.Current.Request.MapPath("~\\tessdata");
            mediaPath = System.Web.HttpContext.Current.Request.MapPath("~\\Media");
            backend = new IngredientListBackend(tessdataPath, mediaPath);
        }

        // GET api/values
        public ExtractionModel Get()
        { 
            var result = backend.ExtractFromImageTest();

            if (!result)
            {
                return new ExtractionModel("0", "Error Occurred. Could not parse photo.");
            }

            return backend.extraction;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        public IHttpActionResult Post([FromBody] IngredientListModel model)
        {
            if (model is null)
            {
                return BadRequest("Post body cannot be null. Please create an object of type IngredientListModel.");
            }

            if (string.IsNullOrEmpty(model.imageAsString) ||
                string.IsNullOrWhiteSpace(model.imageAsString))
            {
                return BadRequest("No image was provided. Please provide the string representation of an image within an IngredientListModel object.");
            }

            var result = backend.ExtractFromImage(model);

            if (!result)
            {
                return BadRequest(backend.exception.ToString());
            }

            return Ok(backend.list);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
