using Is_This_Vegan__Net_.Enums;
using System.ComponentModel;
using System.Collections.Generic;

namespace Is_This_Vegan__Net_.Models
{
    public class ProductModel
    {
        /// <summary>
        /// Indicates whether product categorization is successful
        /// </summary>
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// Indicate how vegan a product is
        /// </summary>
        [DisplayName("Category")]
        public IngredientClassificationEnum ProductCategory { get; set; }

        /// <summary>
        /// List of ingredients within the product sorted in alphabetical order
        /// </summary>
        [DisplayName("Ingredients")]
        public List<IngredientModel> Ingredients { get; set; }
    }
}