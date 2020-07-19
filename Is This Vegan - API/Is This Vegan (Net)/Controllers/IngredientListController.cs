using Is_This_Vegan__Net_.Backend.Ingredient_List;
using Is_This_Vegan__Net_.Models;
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

        // POST: api/ingredientlist
        //[System.Web.Http.HttpPost]
        //public IngredientListModel PostIngredientList([FromBody] JToken postData, HttpRequestMessage request)
        //{
        //    var x = postData;
        //    var y = request;
        //    return new IngredientListModel();
        //}

        // POST api/values
        public IHttpActionResult Post([FromBody] IngredientListModel model)
        {
            return Ok();
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
