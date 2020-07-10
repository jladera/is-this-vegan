using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using Tesseract;
using TextExtractionService.Models;

namespace Is_This_Vegan___API.Backend.Tesseract
{
    public class TextExtractor
    {
        private string tessdataPath;
        private string testImagePath;
        public ExtractionModel extraction { get; private set; }
        public Exception exception { get; private set; }

        public string message;

        /// <summary>
        /// Constructor used for testing
        /// </summary>
        /// <param name="tessdataPath"> Path to </param>
        /// <param name="image"></param>
        public TextExtractor(string tessdataPath, string testImageBasePath) 
        {
            this.tessdataPath = tessdataPath;
            this.testImagePath = testImageBasePath + "\\test_ingredient_list_cropped.jpg";
        }

        public bool ExtractText(string imageAsString)
        {
            Stream stream;
            Bitmap bitmap;

            if (string.Equals(imageAsString, "test")) // Use test image
            {
                bitmap = new Bitmap(Image.FromFile(this.testImagePath));
            }
            else
            {
                // Convert image to an image stream
                var temp_stream = new MemoryStream();
                Image.FromFile(this.testImagePath).Save(temp_stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                var temp_bytes = GetImageStreamAsBytes(temp_stream);
                var temp_str = Convert.ToBase64String(temp_bytes);
                stream = ConvertFromStringToStream(imageAsString);
                bitmap = new Bitmap(stream);
                message = temp_str;
            }

            Extract(bitmap);

            return false;
            return true;
        }

        public Stream ConvertFromStringToStream(string imageAsString)
        { 
            var imageAsBytes = Convert.FromBase64String(imageAsString);
            MemoryStream stream = new MemoryStream();
            stream.Write(imageAsBytes, 0, imageAsBytes.Length);

            return stream;
        }

        public bool Extract(Bitmap image)
        {
            return true;
            //try
            //{
            //    using (var engine = new TesseractEngine(tessdataPath, "eng", EngineMode.Default))
            //    {
            //        // have to load Pix via a bitmap since Pix doesn't support loading a stream.
            //        using (var pix = PixConverter.ToPix(image))
            //        {
            //            using (var page = engine.Process(pix))
            //            {
            //                var meanConfidenceLabel = String.Format("{0:P}", page.GetMeanConfidence());
            //                var resultText = page.GetText();
            //                extraction = new ExtractionModel(meanConfidenceLabel, resultText);
            //                return true;
            //            }
            //        }
            //    }
            //}
            //catch (Exception e)
            //{
            //    exception = e;
            //    return false;
            //}
        }

        public byte[] GetImageStreamAsBytes(Stream input)
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
        public Stream GetTestImageAsStream()
        {
            //Image embeddedImage = new Image { Source = ImageSource.FromResource("Is This Vegan.SharedMedia.Final Icons_vegan.png") };
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("Is This Vegan.SharedMedia.test_ingredient_list_cropped.jpg");
            return myStream;
        }
    }
}