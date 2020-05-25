using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Is_This_Vegan.Models.Image
{
    class ImageModel
    {
        public ImageSource Image { get; set; }

        private string testImage = "Is This Vegan.SharedMedia.test_ingredient_list_full.jpg";

        /// <summary>
        /// Creates an ImageModel. If resourceImagePath is null or empty, assume we are testing and so use
        /// pre-existing test image
        /// </summary>
        /// <param name="resourceImagePath"> Path to an EmbeddedResource image </param>
        public ImageModel(string resourceImagePath = null)
        {
            if (string.IsNullOrEmpty(resourceImagePath))
            {
                resourceImagePath = testImage;
            }

            Image = ImageSource.FromResource(resourceImagePath);
        }
    }
}
