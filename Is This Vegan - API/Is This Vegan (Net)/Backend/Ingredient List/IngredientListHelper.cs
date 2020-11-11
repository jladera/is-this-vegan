/*
 * Created by Jake Ladera
 * 
 * Intended Use:
 *      Helper methods that manipulate Ingredient List data
 *      
 *      Examples:
 *      - Convert image of an Ingredient List (received as string from mobile client) to a Bitmap
 */

using Is_This_Vegan__Net_.Backend.Interfaces;
using Is_This_Vegan__Net_.Enums;
using Is_This_Vegan__Net_.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Is_This_Vegan__Net_.Backend.Ingredient_List
{
    public class IngredientListHelper:IPipeline
    {
        // Pipeline object that cleans ingredients that have subingredients
        public SecondaryCleanPipeline pipeline;
        public List<string> cleanedList { get; set; }

        public IngredientListHelper()
        {
            pipeline = new SecondaryCleanPipeline();
            cleanedList = new List<string>();
        }

        /// <summary>
        /// Converts image received from mobile client (which is represented as a string) into a Bitmap
        /// </summary>
        /// <param name="image"> The Ingredient List image received from the mobile client </param>
        /// <returns> The Ingredient List image represeted as  Bitmap </returns>
        public Bitmap StringToBitmap(string image)
        {
            Byte[] bytes = Convert.FromBase64String(image);

            using (MemoryStream ms = new MemoryStream(bytes))
            {
                Bitmap bitmap = (Bitmap)Image.FromStream(ms);
                return bitmap;
            }
        }

        public PipelineResultModel Execute<T>(ref T input, DataCleanEnum? type, float? meanConfidence)
        {
            var dataCleanFacade = new DataCleanFacade(type, meanConfidence);
            var result = dataCleanFacade.Clean(ref input);
            return result;
        }
    }
}