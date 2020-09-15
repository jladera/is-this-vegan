using Is_This_Vegan__Net_.Backend.Interfaces;
using Is_This_Vegan__Net_.Enums;
using Is_This_Vegan__Net_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Is_This_Vegan__Net_.Backend.Ingredient_List
{
    /// <summary>
    /// Replaces ingredients that have sub-ingredients with their sub-ingredients.
    /// </summary>
    public class SecondaryCleanPipeline : IPipeline
    {
        // Cleaned ingredient list. Populated upon Execute method's completion
        public string cleanedList { get; set; }

        /// <summary>
        /// Pipeline driver
        /// 
        /// example input:
        /// ENRICHED FLOUR [WHEAT FLOUR, NIACIN, REDUCED IRON, THIAMIN MONONITRATE (VITAMIN B1), RIBOFLAVIN (VITAMIN B2), FOLIC ACID]
        /// 
        /// example output:
        /// [WHEAT FLOUR, NIACIN, REDUCED IRON, THIAMIN MONONITRATE (VITAMIN B1), RIBOFLAVIN (VITAMIN B2), FOLIC ACID]
        /// </summary>
        /// <param name="input"> Ingredient list after being validated by user </param>
        /// <param name="type"> Type of data cleaning; Is ignored in pipeline </param>
        /// <returns> True if executes without error, otherise false </returns>
        public PipelineResultModel Execute<T>(ref T input, DataCleanEnum? type)
        {
            var list = input.ToString();
            var result = new PipelineResultModel();
            try
            {
                result = IsValid(list);
                var savedIngredients = ExtractAndSave(list);
                var toReplace = Find(list);
                var subingredients = ExtractSubingredients(list);
                cleanedList = Reinsert(
                                savedIngredients,
                                Replace(list, toReplace, subingredients)
                              );
            }
            catch (Exception e)
            {
                result.isSuccessful = false;
                result.result = e.ToString();
            }
            
            return result;
        }

        /// <summary>
        /// TODO:
        /// Determines if the initial ingredient list is valid. And ingredient list
        /// is considered invalid if the ingredient list contains 0 or 1 characters after
        /// removing invalid characters.
        /// </summary>
        /// <param name="list"> Ingredient List in paragraph form</param>
        /// <returns> True if valid, false otherwise </returns>
        public PipelineResultModel IsValid(string list)
        {
            return new PipelineResultModel() { isSuccessful = true, result = "Temp Value" };
        }

        /// <summary>
        /// Extracts igredients with common and scientific names to be reinserted
        /// after replacing base ingredients with their subingredients
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public MatchCollection ExtractAndSave(string list)
        {
            var matches = Regex.Matches(list, @"[A-Za-z\s]*\((\w|\s)*\)*");
            return matches;
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

        public string Reinsert(MatchCollection savedIngredients, string list)
        {
            var savedIngredientsList = new List<string>();
            foreach (Match match in savedIngredients)
            {
                savedIngredientsList.Append(match.Value);
            }
            var result = list + string.Join(", ", savedIngredientsList);
            result = result.TrimEnd('.');
            return result;
        }
    }
}