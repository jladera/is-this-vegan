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
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

namespace Is_This_Vegan__Net_.Backend.Ingredient_List
{
    public class IngredientListHelper:IPipeline
    {

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
            // replace ingredients that have sub-ingredients with their sub-ingredients
            // remove initial unnecessary text (ex. 'Ingredients: ')
            // split ingredients that have both a scientific and common name listed
            // get each ingredient
            return true;
        }
    }
}