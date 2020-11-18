using Is_This_Vegan__Net_.Backend.Categorize;
using Is_This_Vegan__Net_.Models;
using System.Web.Http;

namespace Is_This_Vegan__Net_.Controllers
{
    public class CategorizeController : ApiController
    {
        public string mediaPath { get; private set; }
        private CategorizeBackend backend;

        public CategorizeController()
        {
            mediaPath = System.Web.HttpContext.Current.Request.MapPath("~\\Media");
            backend = new CategorizeBackend(mediaPath);
        }

        public IHttpActionResult Post([FromBody] string ingredientsList)
        {
            if (string.IsNullOrEmpty(ingredientsList) ||
                string.IsNullOrWhiteSpace(ingredientsList))
            {
                return BadRequest("Post body cannot be null. Please include an ingredients list as a string and try again.");
            }

            ProductModel result = backend.CategorizeProduct(ingredientsList);

            if (result is null)
            {
                return BadRequest();
            }

            if (result.IsSuccessful is false)
            {
                return InternalServerError();
            }

            return Ok(result);
        }
    }
}
