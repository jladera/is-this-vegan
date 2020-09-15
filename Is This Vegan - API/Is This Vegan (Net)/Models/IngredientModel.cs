using Is_This_Vegan__Net_.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Is_This_Vegan__Net_.Models
{
    //[Bind("imageAsString,ingredientListRaw,ingredientListClean")]
    public class IngredientModel
    {
        /// <summary>
        /// GUID as it exists in database
        /// </summary>
        public Guid Id { get; set; }

        /// <summary> id, name, vegan_status, is_core, last accessed, is debated
        /// Name of the ingredient
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Classification of the ingredient as Vegan, Not Vegan, Maybe Vegan, Not Recognized 
        /// </summary>
        public IngredientClassificationEnum Classification { get; set; }

        /// <summary>
        /// If ingredient is an ingredient used to load the database initially, it will not
        /// deleted even if it hasn't been accessed in a long time.
        /// </summary>
        public bool IsCore { get; set; }

        /// <summary>
        /// Date of the last read from the database
        /// </summary>
        public DateTime LastAccessed { get; set; }

        /// <summary>
        /// True if the classification of the ingredient is currently in debate,
        /// otherwise false.
        /// </summary>
        public bool IsDebated { get; set; }
    }
}

