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
        SubingredientPipeline pipeline;

        public IngredientListHelper()
        {
            pipeline = new SubingredientPipeline();
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

        /// <summary>
        /// Executes text cleaning pipeline to remove unnecessary words, punctuation, and invalid characters.
        /// </summary>
        /// <param name="input"> Raw ingredient list text from Tesseract extraction </param>
        /// <returns> True if executes without error, otherwise false</returns>
        public bool Execute<T>(ref T input)
        {
            // remove initial unnecessary text (ex. \n, \t, _, |, etc)
            var removalResult = Remove(input.ToString());

            // convert to lowecase
            var lowerResult = removalResult.ToLower();

            // replace ingredients that have sub-ingredients with their sub-ingredients
            var subingredientPipelineResult = pipeline.Execute(ref lowerResult);

            // split ingredients that have both a scientific and common name listed
            // get each ingredient
            return true;
        }

        /// <summary>
        /// Removes unnecessary characters, newlines, etc. from an ingredient list.
        /// </summary>
        /// <param name="rawList"> Raw ingredient list (done after text extraction) </param>
        /// <returns> The ingredient list without invalid characters </returns>
        public string Remove(string rawList)
        {
            // Key = text to remove
            // Value = replacement text
            var toRemoveList = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("\n", " "),
                new KeyValuePair<string, string>("\t", " "),
                new KeyValuePair<string, string>("_", ""),
                new KeyValuePair<string, string>("|", ""),
                new KeyValuePair<string, string>("(", ","),
                new KeyValuePair<string, string>(")", "")
            };

            foreach (var toRemove in toRemoveList)
            {
                rawList = rawList.Replace(toRemove.Key, toRemove.Value);
            }

            rawList = rawList.Trim();

            return rawList;
        }
    }
}