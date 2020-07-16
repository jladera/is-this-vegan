using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Is_This_Vegan.Backend.Image;
using Is_This_Vegan.Models;
using Newtonsoft.Json;
using RestSharp;
using Windows.Security.Cryptography.Certificates;
using Windows.Web.Http.Filters;

namespace Is_This_Vegan.Backend.API
{
    class TextExtractor
    {
        public string response { get; private set; }

        public bool useTest { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public TextExtractor() { }

        public async System.Threading.Tasks.Task<bool> PostImageAsync(Byte[] image = null)
        {
            // Use test image
            if (image is null)
            {
                var stream = ImageHelper.GetTestImageAsStream();
                image = ImageHelper.GetImageStreamAsBytes(stream);
            }

            var imageAsString = Convert.ToBase64String(image);

            var ingredientListJson = JsonConvert.SerializeObject(new IngredientListModel() { imageAsString = imageAsString });

            var client = new RestClient("http://is-this-vegan.azurewebsites.net/api/ingredientlist");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "ARRAffinity=96267d732e65ca0d29c035444c65e39a9da9a9cd4ec07e02900087916e850fb3");
            request.AddParameter("application/json", ingredientListJson, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return true;

        }
    }

    public class Ingredients
    {
        public string image { get; set; }
    }
}
