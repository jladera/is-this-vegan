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

            var client = new RestClient("https://is-this-vegan.azurewebsites.net/ingredientlist");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\"imageAsString\":\"John Doe\", \"ingredientListRaw\":\"18\", \"ingredientListClean\":[\"United\", \"States\", \"of\", \"America\"]}", ParameterType.RequestBody);
            var response = client.Execute(request);
            var jsonObject = JsonConvert.DeserializeObject(response.Content);
            Console.WriteLine(response);

            return true;

        }
    }

    public class Ingredients
    {
        public string image { get; set; }
    }
}
