using Is_This_Vegan__Net_.Backend.Ingredient_List;
using Is_This_Vegan__Net_.Models;
using Is_This_Vegan_Test.Testing_Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Is_This_Vegan_Test.Backend.Ingredient_List
{
    [TestClass]
    public class SecondaryCleanPipelineTest
    {
        string mediaFolderPath;
        IngredientListBackend backend;
        SecondaryCleanPipeline pipeline;
        IngredientListCollection IngredientListCollection;

        public SecondaryCleanPipelineTest()
        {
            // Get path to current directory
            var curentDirectoryPathArray = Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()).Split('\\');

            // Remove last two directories (bin and this project) and add directories for API project and tessdata
            var tessdataArray = curentDirectoryPathArray.Take((int)curentDirectoryPathArray.Count() - 2).Append("Is This Vegan (Net)\\tessdata");

            // Join to form valid string path
            var tessdataPath = string.Join("\\", tessdataArray);

            // Set general test image path
            var temporaryGeneralMediaFolderPathArray = curentDirectoryPathArray.Take((int)curentDirectoryPathArray.Count() - 2).Append("Is This Vegan Test\\Media\\");
            mediaFolderPath = string.Join("\\", temporaryGeneralMediaFolderPathArray);


            backend = new IngredientListBackend(tessdataPath);
            pipeline = new SecondaryCleanPipeline();
            IngredientListCollection = new IngredientListCollection();
        }

        [TestMethod]
        public void IsValid_Should_Pass()
        {
            // Arrange
            List<string> uvLists = IngredientListCollection.uvLists.Select(list => list.Value).ToList();
            List<PipelineResultModel> results = new List<PipelineResultModel>();

            // Act
            foreach (string uvList in uvLists)
            {
                results.Add(pipeline.IsValid(uvList));
            }

            // Assert
            Assert.IsTrue(results.Count == 5);
            foreach (PipelineResultModel result in results)
            {
                Assert.IsNotNull(result);
                Assert.IsTrue(result.isSuccessful);
            }
        }

        // TODO
        // Add more test photos that will have ingredients with subingredients
        [TestMethod]
        public void ExtractDualNamedIngredients_Should_Pass()
        {
            // arrange
            var collection = new SecondaryCleanPipelineCollection.ExtractDualNamedIngredients();
            TestingModel testCase = collection.IngredientLists.First(product => product.Filename.Equals("too-faced_better-than-sex-mascara.jpg"));

            // act
            string result = pipeline.ExtractDualNamedIngredients((string)testCase.Input);
            var isNotNullOrEmpty = !string.IsNullOrEmpty(result);
            var isNotNullOrWhiteSpace = !string.IsNullOrWhiteSpace(result);

            // assert
            Assert.IsTrue(isNotNullOrEmpty && isNotNullOrWhiteSpace);
            Assert.AreEqual((string)testCase.Expected, result);
        }

        // TODO
        // Add more test photos that will have ingredients with subingredients
        [TestMethod]
        public void FindSubingredients_Should_Pass()
        {
            // arrange
            var collection = new SecondaryCleanPipelineCollection.ReplaceSubingredients();
            TestingModel testCase = collection.IngredientLists.First(product => product.Filename.Equals("belvita_vanilla-cookie.jpg"));

            // act
            string result = pipeline.ReplaceSubingredients((string)testCase.Input);
            var isNotNullOrEmpty = !string.IsNullOrEmpty(result);
            var isNotNullOrWhiteSpace = !string.IsNullOrWhiteSpace(result);

            // assert
            Assert.IsTrue(isNotNullOrEmpty && isNotNullOrWhiteSpace);
            Assert.AreEqual((string)testCase.Expected, result);
        }

        // TODO
        // Add more test photos that will have ingredients with subingredients
        [TestMethod]
        public void ExtractSubingredients_Should_Pass()
        {
            // Arrange
            var expected = "wheat flour, niacin, reduced iron, thiamin mononitrate (vitamin b1), riboflavin (vitamin b2), folic acid";
            var uvList = IngredientListCollection.uvLists.First(product => product.Key.Equals("belvita_vanilla-cookie.jpg")).Value;

            // Act
            var results = pipeline.ExtractSubingredients(uvList);

            // Assert
            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results[0].ToString(), expected);
        }

        // TODO
        // Add more test photos that will have ingredients with subingredients
        [TestMethod]
        public void ReplaceParentIngredient_Should_Pass()
        {
            // Arrange
            string uvList = IngredientListCollection.uvLists.First(product => product.Key.Equals("belvita_vanilla-cookie.jpg")).Value;
            MatchCollection toReplace = pipeline.FindSubingredients(uvList);
            MatchCollection subingredients = pipeline.ExtractSubingredients(uvList);
            string expected = "whole grain wheat flour, wheat flour, niacin, reduced iron, thiamin mononitrate (vitamin b1), riboflavin (vitamin b2), folic acid, sugar, canola oil, whole grain rolled oats, whole grain rye flour, baking soda, disodium pyrophosphate, salt, soy lecithin, datem, natural flavor, ferric orthophosphate (iron), niacinamide,  pyridoxine hydrochloride (vitamin b6), riboflavin (vitamin b2),  thiamin mononitrate (vitamin b1).";

            // Act
            string result = pipeline.ReplaceParentIngredient(uvList, toReplace, subingredients);

            // Assert
            Assert.AreEqual(result, expected);

            // These bracket types indicate a subingredient set in ingredient list standardized formatting
            Assert.IsFalse(result.Contains("["));
            Assert.IsFalse(result.Contains("]"));
            Assert.IsFalse(result.Contains("{"));
            Assert.IsFalse(result.Contains("}"));
        }

        // TODO
        // Add more test photos that will have ingredients with subingredients
        [TestMethod]
        public void ReplaceSubingredients_Should_Pass()
        {
            // Arrange
            string input = IngredientListCollection.uvLists.First(photo => photo.Key.Equals("belvita_vanilla-cookie.jpg")).Value;
            string expected = "whole grain wheat flour, wheat flour, niacin, reduced iron, thiamin mononitrate (vitamin b1), riboflavin (vitamin b2), folic acid, sugar, canola oil, whole grain rolled oats, whole grain rye flour, baking soda, disodium pyrophosphate, salt, soy lecithin, datem, natural flavor, ferric orthophosphate (iron), niacinamide,  pyridoxine hydrochloride (vitamin b6), riboflavin (vitamin b2),  thiamin mononitrate (vitamin b1).";
            // Act
            var result = pipeline.ReplaceSubingredients(input);

            // Assert
            Assert.AreEqual(result, expected);
        }

        // TODO
        // Add more test photos that will have ingredients with intermediate commas
        [TestMethod]
        public void ExtractIntermediateCommaIngredients_Should_Pass()
        {
            // Arrange
            string input = pipeline.ExtractDualNamedIngredients(
                                pipeline.ReplaceSubingredients(
                                    IngredientListCollection.uvLists
                                    .First(photo => photo.Key.Equals("belvita_vanilla-cookie.jpg"))
                                    .Value
                           ));

            List<string> expectedIntermediateCommaIngredients = new List<string>();
            string expectedList = "whole grain wheat flour, wheat flour, niacin, reduced iron,,, folic acid, sugar, canola oil, whole grain rolled oats, whole grain rye flour, baking soda, disodium pyrophosphate, salt, soy lecithin, datem, natural flavor,, niacinamide,,,.";
            // Act
            var result = pipeline.ExtractIntermediateCommaIngredients(input);

            // Assert
            Assert.AreEqual(pipeline.IntermediateCommaIngredients.Count, expectedIntermediateCommaIngredients.Count);
            Assert.AreEqual(result, expectedList);

            // Reset
            PipelineReset();
        }

        // TODO
        // Add more test photos that will have ingredients with intermediate commas
        [TestMethod]
        public void RemoveDuplictes_Should_Pass()
        {
            // Arrange 
            // Performs operations in the same order as in SecondaryCleanPipeline Execute function
            string input = pipeline.ExtractIntermediateCommaIngredients(
                                pipeline.ExtractDualNamedIngredients(
                                    pipeline.ReplaceSubingredients(
                                        IngredientListCollection.uvLists
                                        .First(photo => photo.Key.Equals("belvita_vanilla-cookie.jpg"))
                                        .Value
                                    )
                                )
                            );

            List<string> expectedIngredientList = new List<string>()
                                                  {
                                                    "whole grain wheat flour",
                                                    "wheat flour",
                                                    "niacin",
                                                    "reduced iron",
                                                    "folic acid",
                                                    "sugar",
                                                    "canola oil",
                                                    "whole grain rolled oats",
                                                    "whole grain rye flour",
                                                    "baking soda",
                                                    "disodium pyrophosphate",
                                                    "salt",
                                                    "soy lecithin",
                                                    "datem",
                                                    "natural flavor",
                                                    "niacinamide",
                                                    "thiamin mononitrate (vitamin b1)",
                                                    "riboflavin (vitamin b2)",
                                                    "ferric orthophosphate (iron)",
                                                    "pyridoxine hydrochloride (vitamin b6)"
                                                  };
            
            // Act
            var result = pipeline.RemoveDuplictes(input);

            // Assert
            Assert.AreEqual(result.Count, expectedIngredientList.Count);
            foreach (var ingredient in result)
            {
                Assert.IsTrue(expectedIngredientList.Contains(ingredient));
            }
        }

        /// <summary>
        /// Resets SecondaryCleanPipeline class properties that would be changed due to completion of pipeline steps
        /// </summary>
        public void PipelineReset()
        {
            pipeline.DualNamedIngredients = null;
            pipeline.IntermediateCommaIngredients = null;
        }
    }
}
