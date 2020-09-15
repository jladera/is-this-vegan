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
            var dataCleanFacade = new DataCleanFacade(type);
            var result = dataCleanFacade.Clean(ref input);
            return result;
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
                new KeyValuePair<string, string>("|", "")
            };

            foreach (var toRemove in toRemoveList)
            {
                rawList = rawList.Replace(toRemove.Key, toRemove.Value);
            }

            rawList = rawList.Trim();

            return rawList;
        }

        /// <summary>
        /// Converts a cleaned list string into a list of ingredients as strings
        /// </summary>
        /// <param name="cleanedList"> 
        ///     Ingredients list after removing invalid characters, breaking compound 
        ///     ingredients to base ingredients, and converting list to lowercase.
        /// </param>
        /// <returns> 
        ///     A list of ingredients. If there are no ingredients, then returns
        ///     an empty list.
        /// </returns>
        public List<string> ToList(string cleanedList)
        {
            var result = new List<string>();
            var matches = Regex.Matches(cleanedList, @"(?<=,)[^,]+|(?<=:)[^,]+(?=,)");

            foreach (Match match in matches)
            {
                var ingredient = match.Value.Trim();
                if (!result.Contains(ingredient))
                {
                    result.Add(match.Value.Trim());
                }
            }

            return result;
        }
    }
}