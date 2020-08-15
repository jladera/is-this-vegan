using Is_This_Vegan__Net_.Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Is_This_Vegan__Net_.Backend.Ingredient_List
{
    /// <summary>
    /// Replaces ingredients that have sub-ingredients with their sub-ingredients.
    /// </summary>
    public class SubingredientPipeline : IPipeline
    {
        /// <summary>
        /// Pipeline driver
        /// 
        /// example input:
        /// ENRICHED FLOUR [WHEAT FLOUR, NIACIN, REDUCED IRON, THIAMIN MONONITRATE (VITAMIN B1), RIBOFLAVIN (VITAMIN B2), FOLIC ACID]
        /// 
        /// example output:
        /// [WHEAT FLOUR, NIACIN, REDUCED IRON, THIAMIN MONONITRATE (VITAMIN B1), RIBOFLAVIN (VITAMIN B2), FOLIC ACID]
        /// </summary>
        /// <param name="input"> Raw ingredient list </param>
        /// <returns> True if executes without error, otherise false </returns>
        public bool Execute<T>(ref T input)
        {
            //var ingredientsWithSubingredients = FindIngredientsWithSubingredients(input);
            return true;
        }

        /// <summary>
        /// Finds all ingredients that have sub-ingredients
        /// </summary>
        /// <param name="input"> Raw ingredient list </param>
        /// <returns> Ingredients that have sub-ingredients </returns>
        public MatchCollection Find(string input)
        {
            var matches = Regex.Matches(input, @"(?<=\s)(\w|\s)*(\[|\{)(\w*|\s|\,|\(|\))*(\]|\})");
            return matches;
        }

        /// <summary>
        /// Finds and returns all lists of subingredients.
        /// 
        /// example:
        ///     extracts: WHEAT FLOUR, NIACIN, REDUCED IRON, THIAMIN MONONITRATE (VITAMIN B1), RIBOFLAVIN (VITAMIN B2), FOLIC ACID
        ///     from: ENRICHED FLOUR [WHEAT FLOUR, NIACIN, REDUCED IRON, THIAMIN MONONITRATE (VITAMIN B1), RIBOFLAVIN (VITAMIN B2), FOLIC ACID}
        /// </summary>
        /// <param name="input"> Raw ingredient list</param>
        /// <returns></returns>
        public MatchCollection ExtractSubingredients(string input)
        {
            var subingredients = Regex.Matches(input, @"(?<=\[|\{)(\w*|\s|\,|\(|\))*(?=\}|\])");
            return subingredients;
        }

        /// <summary>
        /// Replaces ingredients that contain subingredients with only the subingredients.
        /// 
        /// example:
        ///     replaces: ENRICHED FLOUR [WHEAT FLOUR, NIACIN, REDUCED IRON, THIAMIN MONONITRATE (VITAMIN B1), RIBOFLAVIN (VITAMIN B2), FOLIC ACID}
        ///     with: WHEAT FLOUR, NIACIN, REDUCED IRON, THIAMIN MONONITRATE (VITAMIN B1), RIBOFLAVIN (VITAMIN B2), FOLIC ACID
        /// </summary>
        /// <param name="rawList"> Raw ingredient list </param>
        /// <param name="toReplace"> List of ingredient sections to replace (return result from Find method) </param>
        /// <param name="subingredients"> List of subingredients (return result from ExtractSubingredientsMethod) </param>
        /// <returns> The full ingredient list where ingredients that contain subingredients have been replaced </returns>
        public string Replace(string rawList, MatchCollection toReplace, MatchCollection subingredients)
        {
            string result = rawList;

            foreach(var index in Enumerable.Range(0, toReplace.Count))
            {
                result = result.Replace(toReplace[index].Value, subingredients[index].Value);
            }

            return result;
        }
    }
}