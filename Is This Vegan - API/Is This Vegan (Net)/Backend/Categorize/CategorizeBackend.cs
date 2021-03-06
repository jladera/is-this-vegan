﻿using Is_This_Vegan__Net_.Backend.Ingredient;
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

        /// <summary>
        /// Driver to categorize a product as Vegan/NotVegan/MaybeVegan based on its ingredients
        /// </summary>
        /// <param name="ingredientsList"> Single string of the ingredients in a product </param>
        /// <returns> A ProductModel object representing the Product and its categorization </returns>
        public ProductModel CategorizeProduct(string ingredientsList)
        {
            var result = new ProductModel() { IsSuccessful = true };

            PipelineResultModel pipelineResult = Pipeline.Execute(ref ingredientsList, Enums.DataCleanEnum.ListSecondary, null);
            if (!pipelineResult.isSuccessful)
            {
                result.IsSuccessful = pipelineResult.isSuccessful;
                return result;
            }

            result = CheckIngredients(pipelineResult.result, result);

            return result;
        }

        /// <summary>
        /// Driver that checks each ingredient and its category
        /// </summary>
        /// <param name="pipelineResult"> The pipeline result object which contains a list of the extracted ingredients </param>
        /// <param name="result"> The ProductModel object which will represent the product and its category. </param>
        /// <returns>
        ///     The ProductModel object which will represent the product and its category. This will ultimately be sent
        ///     to the end-user 
        /// </returns>
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
                catch (Exception ex)
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