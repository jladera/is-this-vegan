/*
 * Created by Jake Ladera
 * 
 * Intended Use:
 *      Represent types of ingredients that will be saved and reinserted in the 
 *      last step of the SecondaryCleanPipeline.
 */

using System.ComponentModel;

namespace Is_This_Vegan__Net_.Enums
{
    public enum SecondaryCleanPipelineEnum
    {
        /// <summary>
        /// Ingredients with a common and scientific name listed
        /// 
        /// ex. Thiamin Mononitrate (Vitamin B1)
        /// ex. Vitamin B1 (Thiamin Mononitrate)
        /// </summary>
        TwoNameIngredient = 0,

        /// <summary>
        /// Ingredients with a comma within its name
        /// 
        /// ex. 1,2-Hexanediol
        /// </summary>
        IntermediateCommaIngredient = 1
    }
}