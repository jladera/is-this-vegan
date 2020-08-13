/*
 * Created by Jake Ladera
 * 
 * Intended Use:
 *      Helper methods that manipulate Ingredient List data
 *      
 *      Examples:
 *      - Convert image of an Ingredient List (received as string from mobile client) to a Bitmap
 */

using System;
using System.Drawing;
using System.IO;

namespace Is_This_Vegan__Net_.Backend.Ingredient_List
{
    public class IngredientListHelper
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
    }
}