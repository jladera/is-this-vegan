using Is_This_Vegan__Net_.Backend.Ingredient;
using Is_This_Vegan__Net_.Backend.Ingredient_List;
using Is_This_Vegan__Net_.Backend.Interfaces;
using Is_This_Vegan__Net_.Enums;
using Is_This_Vegan__Net_.Models;
using System;
using System.Collections.Generic;

namespace Is_This_Vegan__Net_.Backend.Categorize
{
    public class CategorizeBackend
    {
        public SecondaryCleanPipeline Pipeline;
        public IDataAccessRepository DataAccess;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediaPath"> Path to Media folder (for local data access) </param>
        #nullable enable
        public CategorizeBackend(string? mediaPath)
        {
            Pipeline = new SecondaryCleanPipeline();
            if (string.IsNullOrEmpty(mediaPath) ||
                string.IsNullOrWhiteSpace(mediaPath))
            {
                // create instance of DB data access
            } else
            {
                // otherwise use local ingredients files
                DataAccess = new IngredientLocalRepository(mediaPath);
            }
        }

        public ProductModel CheckIngredients(object pipelineResult, ProductModel result)
        {
            var ingredientModelList = new List<IngredientModel>();
            var ingredients = (List<string>)pipelineResult;

            ingredients.Sort();

            foreach (string ingredient in ingredients)
            {
                try
                {
                    IngredientModel im = DataAccess.Read(ingredient);
                    ingredientModelList.Add(im);
                    result = UpdateCategory(result, im.Classification);
                }
                catch (Exception)
                {
                    result.IsSuccessful = false;
                    return result;
                }
            }

            result.Ingredients = ingredientModelList;
            return result;
        }

        /// <summary>
        /// Updates the product category (Vegan/MaybeVegan/NotVegan) based on a given ingredient's category.
        /// </summary>
        /// <param name="product"> The model representation of a product </param>
        /// <param name="classification"> The category of a given ingredient </param>
        /// <returns></returns>
        public ProductModel UpdateCategory(ProductModel product, IngredientClassificationEnum classification)
        {
            if (classification.Equals(IngredientClassificationEnum.NotVegan))
            {
                product.ProductCategory = IngredientClassificationEnum.NotVegan;
            }
            else if (
                (classification.Equals(IngredientClassificationEnum.MaybeVegan) || classification.Equals(IngredientClassificationEnum.Unclassified)) &&
                !product.ProductCategory.Equals(IngredientClassificationEnum.NotVegan)
            )
            {
                product.ProductCategory = IngredientClassificationEnum.MaybeVegan;
            }

            return product;
        }
    }
}