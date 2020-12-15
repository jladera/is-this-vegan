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
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// The result of text extraction from PostImageAsync
        /// </summary>
        public IngredientListModel result;

        public bool useTest { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public TextExtractor() { }

        public async System.Threading.Tasks.Task<bool> PostImageAsync(Byte[] image = null)
        {
            IRestResponse response; // Will hold response from call to web API

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
            try
            {
                response = client.Execute(request);

            } catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
            result = new IngredientListModel(response.Content);

            return true;

        }
    }
}
