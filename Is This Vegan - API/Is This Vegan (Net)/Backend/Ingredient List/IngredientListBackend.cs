using Is_This_Vegan__Net_.Enums;
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
        public IngredientListModel list { get; set; }
        public IngredientListHelper helper { get; set; }
        public ExtractionModel extraction { get; set; }
        public Exception exception { get; set; }

        public IngredientListBackend(string tessdataPath)
        {
            this.tessdataPath = tessdataPath;
            helper = new IngredientListHelper();
        }

        public bool ExtractFromImage(IngredientListModel list)
        {
            this.list = list;

            var listImage = helper.StringToBitmap(list.imageAsString);

            var result = ExtractFromImageTest(listImage);

            return result;
        }

        public bool ExtractFromImageTest(Bitmap image = null)
        {
            string meanConfidence;
            try
            {
                using (var engine = new TesseractEngine(tessdataPath, "eng", EngineMode.Default))
                {

                    // have to load Pix via a bitmap since Pix doesn't support loading a stream.
                    using (var pix = PixConverter.ToPix(image))
                    {
                        using (var page = engine.Process(pix))
                        {
                            meanConfidence = String.Format("{0:P}", page.GetMeanConfidence()).Replace("%", "");
                            var resultText = page.GetText();
                            list.ingredientListRaw = resultText;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                exception = e;
                return false;
            }
            var input = list;
            var result = helper.Execute(ref input, DataCleanEnum.ListPrimary, double.Parse(meanConfidence));
            return true;
        }
    }
}