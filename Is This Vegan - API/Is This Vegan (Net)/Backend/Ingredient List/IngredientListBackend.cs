using Is_This_Vegan__Net_.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using Tesseract;

namespace Is_This_Vegan__Net_.Backend.Ingredient_List
{
    public class IngredientListBackend
    {
        private string tessdataPath;
        private string mediaPath;
        public IngredientListModel list { get; private set; }
        public ExtractionModel extraction { get; private set; }
        public Exception exception { get; private set; }

        public IngredientListBackend(string tessdataPath, string mediaPath)
        {
            this.tessdataPath = tessdataPath;
            this.mediaPath = mediaPath;
        }

        public bool ExtractFromImage(IngredientListModel list)
        {
            this.list = list;

            var listImage = IngredientListHelper.StringToBitmap(list.imageAsString);

            var result = ExtractFromImageTest(listImage);

            return result;
        }

        public bool ExtractFromImageTest(Bitmap image = null)
        {
            try
            {
                using (var engine = new TesseractEngine(tessdataPath, "eng", EngineMode.Default))
                {

                    // Extract text from test image
                    if (image is null)
                    {
                        image = new Bitmap(Image.FromFile(mediaPath + "\\test_ingredient_list_cropped.jpg"));
                    }

                    // have to load Pix via a bitmap since Pix doesn't support loading a stream.
                    using (var pix = PixConverter.ToPix(image))
                    {
                        using (var page = engine.Process(pix))
                        {
                            var meanConfidenceLabel = String.Format("{0:P}", page.GetMeanConfidence());
                            var resultText = page.GetText();
                            list.ingredientListRaw = resultText;
                            return true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                exception = e;
                return false;
            }
        }
    }
}