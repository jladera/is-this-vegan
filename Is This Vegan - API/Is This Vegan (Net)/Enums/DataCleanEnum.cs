/*
 * Created by Jake Ladera
 * 
 * Intended Use:
 *      Represent types of data cleaning supported in DataCleanFacade
 */

using System.ComponentModel;

namespace Is_This_Vegan__Net_.Enums
{
    public enum DataCleanEnum
    {
        /// <summary>
        /// Use Scenario: Immediately after extracting data from text extraction
        /// </summary>
        [Description("Ingredient List Initial Clean")]
        ListPrimary = 0,

        /// <summary>
        /// Use Scenario: Mobile user has received result of primary cleaning
        /// (used in scenario above), removed any other unwanted characters,
        /// and submitted this newly validated list to the
        /// web api
        /// </summary>
        [Description("Ingredient List Secondary Clean")]
        ListSecondary = 1
    }
}