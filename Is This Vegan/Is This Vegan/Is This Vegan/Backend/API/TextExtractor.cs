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

            //var client = new HttpClient()
            //{
            //    BaseAddress = new Uri("https://is-this-vegan.azurewebsites.net/")
            //};
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = await client.PostAsJsonAsync("api/textextractor/test", new Dictionary<string, string>() { { "image", "this"} });
            //response.EnsureSuccessStatusCode();

            //Post to API
            //var client = new RestClient("https://is-this-vegan.azurewebsites.net/api/textextractor/test");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            //request.AddHeader("Cookie", "ARRAffinity=71b93c87c96d66981ffadd5ddb8b4abd486df8e270e5aacfe623a6fb5887cbed");
            ////req.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody); maybe?
            //var ingredientList = new IngredientListModel() { imageAsString = imageAsString };
            //var serializedIngredientList = JsonConvert.SerializeObject(ingredientList);
            //request.AddParameter("application/x-www-form-urlencoded", JsonConvert.SerializeObject(ingredient), ParameterType.RequestBody);            //request.AddParameter("text/json", JsonConvert.SerializeObject(ingredient) , ParameterType.RequestBody);
            //var response = client.Execute(request);

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://is-this-vegan.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var uri = new Uri("https://is-this-vegan.azurewebsites.net/api/textextractor/test");
            var ingredientList = new IngredientListModel() { imageAsString = imageAsString };
            var serializedIngredientList = JsonConvert.SerializeObject(ingredientList);
            HttpContent contentPost = new StringContent(serializedIngredientList, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri, contentPost);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Here");
            }

            var are_equal = string.Equals(response.Content, imageAsString);

            //Save API response
            //this.response = response.Content;

            return true;

        }
    }

    public class Ingredients
    {
        public string image { get; set; }
    }
}
