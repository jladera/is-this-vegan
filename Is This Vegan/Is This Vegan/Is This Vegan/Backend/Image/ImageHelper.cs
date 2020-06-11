using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Is_This_Vegan.Backend.Image
{
    public static class ImageHelper
    {
        public static byte[] GetImageStreamAsBytes(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Reads an Embedded Resource Image
        /// </summary>
        /// <param name="fileName"> File name of the photo to read </param>
        /// <returns> The image requested as a Stream object </returns>
        public static Stream GetTestImageAsStream() 
        {
            //Image embeddedImage = new Image { Source = ImageSource.FromResource("Is This Vegan.SharedMedia.Final Icons_vegan.png") };
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("Is This Vegan.SharedMedia.test_ingredient_list_cropped.jpg");
            return myStream;
        }
    }
}
