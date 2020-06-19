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
    }
}
