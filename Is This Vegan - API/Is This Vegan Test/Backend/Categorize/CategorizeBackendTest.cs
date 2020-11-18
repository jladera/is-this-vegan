using System;
using System.IO;
using System.Linq;
using Is_This_Vegan__Net_.Backend.Categorize;
using Is_This_Vegan__Net_.Backend.Ingredient;
using Is_This_Vegan__Net_.Enums;
using Is_This_Vegan__Net_.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Is_This_Vegan_Test.Backend.Categorize
{
    [TestClass]
    public class CategorizeBackendTest
    {
        CategorizeBackend backend;

        public CategorizeBackendTest()
        {
            // Get path to current directory
            var curentDirectoryPathArray = Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()).Split('\\');

            // Set Media directory path
            var temporaryGeneralTestImagePathArray = curentDirectoryPathArray.Take((int)curentDirectoryPathArray.Count() - 2).Append("Is This Vegan (Net)\\Media\\");
            var mediaPath = string.Join("\\", temporaryGeneralTestImagePathArray);

            backend = new CategorizeBackend(mediaPath);
        }

        [TestMethod]
        public void Constructor_Parameter_Not_Null_Should_Pass()
        {
            // arrange 
            var input = "test";

            // act
            var backend = new CategorizeBackend(input);
            var dataAccess = (IngredientLocalRepository)backend.DataAccess;

            // assert
            Assert.AreEqual(input, dataAccess.mediaPath);
        }

        [TestMethod]
        public void Constructor_Parameter_Null_Should_Pass()
        {
            // arrange 
            string input = null;

            // act
            var backend = new CategorizeBackend(input);

            // assert
            Assert.IsNotNull(backend);
            Assert.IsNull(backend.DataAccess);
        }

        [TestMethod]
        public void UpdateCategory_Change_From_Vegan_To_NotVegan_Should_Pass()
        {
            // arrange 
            var expected = new ProductModel()
            {
                IsSuccessful = true,
                ProductCategory = IngredientClassificationEnum.NotVegan,
            };

            var inputProduct = new ProductModel()
            {
                IsSuccessful = true,
                ProductCategory = IngredientClassificationEnum.Vegan
            };

            var inputCategory = IngredientClassificationEnum.NotVegan;

            // act
            var result = backend.UpdateCategory(inputProduct, inputCategory);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.IsSuccessful, result.IsSuccessful);
            Assert.AreEqual(expected.ProductCategory, result.ProductCategory);
        }

        [TestMethod]
        public void UpdateCategory_Change_From_Vegan_To_MaybeVegan_Should_Pass()
        {
            // arrange 
            var expected = new ProductModel()
            {
                IsSuccessful = true,
                ProductCategory = IngredientClassificationEnum.MaybeVegan,
            };

            var inputProduct = new ProductModel()
            {
                IsSuccessful = true,
                ProductCategory = IngredientClassificationEnum.Vegan
            };

            var inputCategory = IngredientClassificationEnum.MaybeVegan;

            // act
            var result = backend.UpdateCategory(inputProduct, inputCategory);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.IsSuccessful, result.IsSuccessful);
            Assert.AreEqual(expected.ProductCategory, result.ProductCategory);
        }

        [TestMethod]
        public void UpdateCategory_No_Change_From_Vegan_To_Vegan_Should_Pass()
        {
            // arrange 
            var expected = new ProductModel()
            {
                IsSuccessful = true,
                ProductCategory = IngredientClassificationEnum.Vegan,
            };

            var inputProduct = new ProductModel()
            {
                IsSuccessful = true,
                ProductCategory = IngredientClassificationEnum.Vegan
            };

            var inputCategory = IngredientClassificationEnum.Vegan;

            // act
            var result = backend.UpdateCategory(inputProduct, inputCategory);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.IsSuccessful, result.IsSuccessful);
            Assert.AreEqual(expected.ProductCategory, result.ProductCategory);
        }

        [TestMethod]
        public void UpdateCategory_Change_From_MaybeVegan_To_NotVegan_Should_Pass()
        {
            // arrange 
            var expected = new ProductModel()
            {
                IsSuccessful = true,
                ProductCategory = IngredientClassificationEnum.NotVegan,
            };

            var inputProduct = new ProductModel()
            {
                IsSuccessful = true,
                ProductCategory = IngredientClassificationEnum.MaybeVegan
            };

            var inputCategory = IngredientClassificationEnum.NotVegan;

            // act
            var result = backend.UpdateCategory(inputProduct, inputCategory);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.IsSuccessful, result.IsSuccessful);
            Assert.AreEqual(expected.ProductCategory, result.ProductCategory);
        }

        [TestMethod]
        public void UpdateCategory_No_Change_From_NotVegan_To_MaybeVegan_Should_Pass()
        {
            // arrange 
            var expected = new ProductModel()
            {
                IsSuccessful = true,
                ProductCategory = IngredientClassificationEnum.NotVegan,
            };

            var inputProduct = new ProductModel()
            {
                IsSuccessful = true,
                ProductCategory = IngredientClassificationEnum.NotVegan
            };

            var inputCategory = IngredientClassificationEnum.MaybeVegan;

            // act
            var result = backend.UpdateCategory(inputProduct, inputCategory);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.IsSuccessful, result.IsSuccessful);
            Assert.AreEqual(expected.ProductCategory, result.ProductCategory);
        }

        [TestMethod]
        public void UpdateCategory_No_Change_From_NotVegan_To_Vegan_Should_Pass()
        {
            // arrange 
            var expected = new ProductModel()
            {
                IsSuccessful = true,
                ProductCategory = IngredientClassificationEnum.NotVegan,
            };

            var inputProduct = new ProductModel()
            {
                IsSuccessful = true,
                ProductCategory = IngredientClassificationEnum.NotVegan
            };

            var inputCategory = IngredientClassificationEnum.Vegan;

            // act
            var result = backend.UpdateCategory(inputProduct, inputCategory);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.IsSuccessful, result.IsSuccessful);
            Assert.AreEqual(expected.ProductCategory, result.ProductCategory);
        }

        [TestMethod]
        public void UpdateCategory_No_Change_From_MaybeVegan_To_Vegan_Should_Pass()
        {
            // arrange 
            var expected = new ProductModel()
            {
                IsSuccessful = true,
                ProductCategory = IngredientClassificationEnum.MaybeVegan,
            };

            var inputProduct = new ProductModel()
            {
                IsSuccessful = true,
                ProductCategory = IngredientClassificationEnum.MaybeVegan
            };

            var inputCategory = IngredientClassificationEnum.Vegan;

            // act
            var result = backend.UpdateCategory(inputProduct, inputCategory);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.IsSuccessful, result.IsSuccessful);
            Assert.AreEqual(expected.ProductCategory, result.ProductCategory);
        }
    }
}
