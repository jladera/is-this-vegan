using System;
using Is_This_Vegan.Backend.Image;
using RestSharp;

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

            // Post to API
            var client = new RestClient("https://is-this-vegan.azurewebsites.net/api/textextractor/test");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", "ARRAffinity=71b93c87c96d66981ffadd5ddb8b4abd486df8e270e5aacfe623a6fb5887cbed");
            request.AddParameter("image", imageAsString);
            var response = client.Execute(request);

            // Save API response
            this.response = response.Content;

            return true;

        }
    }
}
