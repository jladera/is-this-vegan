using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Is_This_Vegan.Models
{
    public class IngredientListModel
    {   
        /// <summary>
        /// Stringified image. Process to stringify image is as follows:
        /// 1) Convert SKBitmap to Bytes (use SKBitmap's Bytes property)
        /// 2)  Use Convert.ToBase64String({bytes from step 1}) to convert to string
        /// </summary>
        public string imageAsString { get; set; }

        /// <summary>
        /// Raw ingredient list blob. Becomes not-null when the webserver responds to mobile app's 
        /// text extraction request.
        /// </summary>
        [DisplayName("Ingredients")]
        public string ingredientListRaw { get; set; }

        /// <summary>
        /// Cleaned ingredients list. Becomes not-null after removing non-English words,
        /// commas, colons, periods, and 'Ingredients" text from Raw ingredient blob. The
        /// user will be shown these ingredients in a bulletted list to confirm/edit 
        /// text extracted from image. 
        /// </summary>
        [DisplayName("Ingredients")]
        public List<string> ingredientListClean { get; set; }

        public IngredientListModel() { }

        public IngredientListModel(string json = null)
        {
            if (!string.IsNullOrEmpty(json) && !string.IsNullOrWhiteSpace(json))
            {
                JObject jObjIngredientListModel = JObject.Parse(json);
                imageAsString = (string)jObjIngredientListModel["imageAsString"];
                ingredientListRaw = (string) jObjIngredientListModel["ingredientListRaw"];
                var cleanedList = ((string)jObjIngredientListModel["ingredientListClean"]);
                if (!string.IsNullOrWhiteSpace(cleanedList) && !string.IsNullOrEmpty(cleanedList))
                {
                    ingredientListClean = new List<string>();
                    ingredientListClean.AddRange(cleanedList.Split());
                }
            }
        }
    }
}
