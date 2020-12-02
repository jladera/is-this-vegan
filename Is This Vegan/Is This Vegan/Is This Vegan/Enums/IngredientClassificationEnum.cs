/*
 * Created by Jake Ladera
 * 
 * Intended Use:
 *      Represent classification of an ingredient
 */
using System.ComponentModel;

namespace Is_This_Vegan.Enums
{
    public enum IngredientClassificationEnum
    {
        /// <summary>
        /// Use Scenario: Ingredient does not exist in database
        /// </summary>
        [Description("Unclassified")]
        Unclassified = 0,

        /// <summary>
        /// Use Scenario: Ingredient exists in database and is classified as Vegan
        /// </summary>
        [Description("Vegan")]
        Vegan = 1,

        /// <summary>
        /// Use Scenario: Ingredient exists in database and is classified as NOT Vegan
        /// </summary>
        [Description("Not Vegan")]
        NotVegan = 2,

        /// <summary>
        /// Use Scenario: Ingredient exists in database and is classified as MAYBE Vegan due to there being both Vegan and Non-Vegan
        ///               sources from which the ingredient is derived
        /// </summary>
        [Description("Maybe Vegan")]
        MaybeVegan = 3
    }
}
