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
        public MatchCollection DualNamedIngredients { get; set; }
        public MatchCollection IntermediateCommaIngredients { get; set; }

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
        /// <param name="meanConfidence"> Confidence of text extraction. Is ignored in this pipeline </param>
        /// <returns> A fully defined PipelineResultModel object </returns>
        public PipelineResultModel Execute<T>(ref T input, DataCleanEnum? type, float? meanConfidence)
        {
            var list = input.ToString().ToLower();
            PipelineResultModel result;
            try
            {
                result = IsValid(list);

                list = ExtractIntermediateCommaIngredients(list);
                list = ExtractDualNamedIngredients(list);
                list = ReplaceSubingredients(list);

                result.result = RemoveDuplictes(list);
                result.isSuccessful = true;
                
            }
            catch (Exception e)
            {
                result = new PipelineResultModel();
                result.isSuccessful = false;
                result.result = e.ToString();
            }
            
            return result;
        }

        /// <summary>
        /// Driver that conducts cleaning protocol for ingredients (lets call these parent ingredients)
        /// that contain subingredients.
        /// Example Input: "chocolate milk [milk, cocoa powder]"
        ///     Step 1: Find ingredients that exhibit such a pattern
        ///     Step 2: Collect all subingredient lists from the ingredients that matched in step 1
        ///     Step 3: Replace matches found in step 1 with the output of step 2
        /// Example Output: "milk, cocoa powder"
        /// </summary>
        /// <param name="list"> Ingredient list received from user </param>
        /// <returns> Ingredient list with all parent ingredients replaced by their subingredients </returns>
        public string ReplaceSubingredients(string extractDualNamedIngredientResult)
        {
            Stack<string> sections = new Stack<string>();
            var finalIngredients = "";
            string section = "";
            foreach (char c in extractDualNamedIngredientResult)
            {
                if (Char.IsLetter(c) || Char.IsWhiteSpace(c))
                {
                    section += c;
                }
                else if (IsOpenParen(c))
                {
                    section += c;
                    sections.Push((section));
                    section = "";
                }
                else if (IsClosedParen(c))
                {
                    section = RemoveParentIngredient(sections.Pop()) + section;
                }
                else if (c.Equals(',') &&
                         sections.Count == 0)
                {
                    finalIngredients += section + c;
                    section = "";
                }
                else
                {
                    section += c;
                }
            }
            finalIngredients += finalIngredients + section;
            return finalIngredients;
        }

        /// <summary>
        /// Determines if a character is an open parenthesis/bracket
        /// </summary>
        /// <param name="c"> Character to check </param>
        /// <returns> True if c matches, false otherwise </returns>
        public bool IsOpenParen(char c)
        {
            return c.Equals('(') || c.Equals('[') || c.Equals('{');
        }

        /// <summary>
        /// Determines if a character is a closed parenthesis/bracket
        /// </summary>
        /// <param name="c"> Character to check </param>
        /// <returns> True if c matches, false otherwise </returns>
        public bool IsClosedParen(char c)
        {
            return c.Equals(')') || c.Equals(']') || c.Equals('}');
        }

        /// <summary>
        /// After a closed bracket is reached, remove the parent ingredient that the subingredients
        /// belong to
        /// </summary>
        /// <param name="poppedSection"> Ingredients that preceding subingredients </param>
        /// <returns> poppedSection without the last ingredient </returns>
        public string RemoveParentIngredient(string poppedSection)
        {
            var index = poppedSection.Length - 2;
            while (index >= 0 &&
                  (Char.IsLetterOrDigit(poppedSection[index]) || Char.IsWhiteSpace(poppedSection[index])))
            {
                index--;
            }

            var ret = poppedSection.Substring(0, index + 1);
            return ret;
        }

        /// <summary>
        ///     Determines if the initial ingredient list is valid. And ingredient list
        ///     is considered invalid if the ingredient list contains 0 or 1 characters after
        ///     removing invalid characters. It is assumed that if the SecondaryCleanPipeline
        ///     Execute method is invoked, the meanConfidence of Tesseract's text extraction
        ///     was greater than 70%.
        /// </summary>
        /// <param name="list"> Ingredient List in paragraph form</param>
        /// <param name="meanConfidence"> The mean confidence of Tesseract's text extraction </param>
        /// <returns> 
        ///     A PipelineResultModel object with its isSuccessful property set to true if valid,
        ///     false otherwise 
        /// </returns>
        public PipelineResultModel IsValid(string list)
        {
            return new PipelineResultModel() { isSuccessful = list.Length > 1 };
        }

        /// <summary>
        /// Finds all ingredients that have sub-ingredients
        /// </summary>
        /// <param name="input"> Raw ingredient list </param>
        /// <returns> Ingredients that have sub-ingredients </returns>
        public MatchCollection FindSubingredients(string input)
        {
            var matches = Regex.Matches(input, @"(?<=\s)(\w|\s)*(\[|\{|\()(\w*|\s|\,)*(\]|\}|\))(?=,)");
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
            var subingredients = Regex.Matches(input, @"(?<=\[|\{|\()(\w*|\s|\,)*(?=\}|\]|\))");
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
        public string ReplaceParentIngredient(string rawList, MatchCollection toReplace, MatchCollection subingredients)
        {
            string result = rawList;

            foreach(var index in Enumerable.Range(0, toReplace.Count))
            {
                result = result.Replace(toReplace[index].Value, subingredients[index].Value);
            }

            return result;
        }

        /// <summary>
        /// Finds all ingredients that have both a common and scientific name listed, removes them from the list,
        /// and saves the matches to the class variable: DualNamedIngredients
        /// Example Match: "Salt (Sodium Chloride)"
        /// </summary>
        /// <param name="replaceSubingredientsResult"> Ingredient list output from ReplaceSubingredients function </param>
        /// <returns> Ingredients list without dual named ingredients </returns>
        public string ExtractDualNamedIngredients(string initialList)
        {
            DualNamedIngredients = Regex.Matches(initialList, @"(\w|\s)*\(((\w+)|\.|(\s)|(\d,\d-\w+))+\)(?=\,|\.|$)");
            var result = Regex.Replace(initialList, @"(\w|\s)*\(((\w+)|\.|(\s)|(\d,\d-\w+))+\)(\,|\.|$)", "");

            return result;
        }

        /// <summary>
        /// Finds all ingredients that have an intermediate comma in its name, removes them from the ingredient list,
        /// and saves it to the class variable: IntermediateCommaIngredients.
        /// Example Match: "1,2-Hexanediol"
        /// </summary>
        /// <param name="extractDualNamedIngredientsResult"> Ingredient list output from ExtractDualNamedIngredients function </param>
        /// <returns> Ingredients list without intermediately comma'd ingredients </returns>
        public string ExtractIntermediateCommaIngredients(string extractDualNamedIngredientsResult)
        {
            IntermediateCommaIngredients = Regex.Matches(extractDualNamedIngredientsResult, @"(\w|\d|-)*(\d\,\d)(-|\w|\d)*");
            var result = Regex.Replace(extractDualNamedIngredientsResult, @"(\w|\d|-)*(\d\,\d)(-|\w|\d)*", "");

            return result;
        }

        /// <summary>
        /// Removes duplicate ingredients from the ingredient list.
        /// </summary>
        /// <param name="extractIntermediateCommaIngredientsResult"> 
        ///     Ingredient list output from ExtractIntermediateCommaIngredients function
        /// </param>
        /// <returns> A new list of ingredients where there is one and only one of each ingredient </returns>
        public List<string> RemoveDuplictes(string extractIntermediateCommaIngredientsResult)
        {
            List<string> result = new List<string>();
            string[] ingredients = extractIntermediateCommaIngredientsResult.Split(',');
            
            // Add all single name ingredients to final ingredients set without duplicates
            foreach(string ingredient in ingredients)
            {
                if (result.Contains(ingredient.Trim()) || IsInvalidString(ingredient))
                {
                    continue;
                }
                result.Add(ingredient.Trim());
            }

            // Add all dual name ingredients to final ingredients set without duplicates
            foreach (Match dualNamedIngredient in DualNamedIngredients)
            {
                if (result.Contains(dualNamedIngredient.Value.Trim()))
                {
                    continue;
                }
                result.Add(dualNamedIngredient.Value.Trim());
            }

            // Add all intermediately comma'd ingredients to final ingredients set without duplicates
            foreach (Match intermediateCommaIngredient in IntermediateCommaIngredients)
            {
                if (result.Contains(intermediateCommaIngredient.Value.Trim()))
                {
                    continue;
                }
                result.Add(intermediateCommaIngredient.Value.Trim());
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns></returns>
        public bool IsInvalidString(string ingredient)
        {
            return string.IsNullOrEmpty(ingredient) || string.IsNullOrWhiteSpace(ingredient) || string.IsNullOrEmpty(Regex.Match(ingredient, @"[A-Za-z]").Value);
        }
    }
}