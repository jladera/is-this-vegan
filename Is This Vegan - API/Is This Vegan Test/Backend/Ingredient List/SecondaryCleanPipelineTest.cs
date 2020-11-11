using Is_This_Vegan__Net_.Backend.Ingredient_List;
using Is_This_Vegan__Net_.Models;
using Is_This_Vegan_Test.Testing_Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        [TestMethod]
        public void ExtractDualNamedIngredients_Should_Pass()
        {
            // arrange
            var collection = new SecondaryCleanPipelineCollection.ExtractDualNamedIngredients();

            // act
            foreach (TestingModel testCase in collection.IngredientLists)
            {
                string result = pipeline.ExtractDualNamedIngredients((string)testCase.Input);
                var isNotNullOrEmpty = !string.IsNullOrEmpty(result);
                var isNotNullOrWhiteSpace = !string.IsNullOrWhiteSpace(result);

                // assert
                Assert.IsTrue(isNotNullOrEmpty && isNotNullOrWhiteSpace);
                Assert.AreEqual((string)testCase.Expected, result);
            }
        }


        [TestMethod]
        public void ReplaceSubingredients_Should_Pass()
        {
            // arrange
            var collection = new SecondaryCleanPipelineCollection.ReplaceSubingredients();

            // act
            foreach (TestingModel testCase in collection.IngredientLists)
            {
                string result = pipeline.ReplaceSubingredients((string)testCase.Input);
                var isNotNullOrEmpty = !string.IsNullOrEmpty(result);
                var isNotNullOrWhiteSpace = !string.IsNullOrWhiteSpace(result);

                // assert
                Assert.IsTrue(isNotNullOrEmpty && isNotNullOrWhiteSpace);
                Assert.AreEqual((string)testCase.Expected, result);
            }
        }

        [TestMethod]
        public void ExtractIntermediateCommaIngredients_Should_Pass()
        {
            // arrange
            var collection = new SecondaryCleanPipelineCollection.ExtractIntermediateCommaIngredients();

            // act
            foreach (TestingModel testCase in collection.IngredientLists)
            {
                string result = pipeline.ExtractIntermediateCommaIngredients((string)testCase.Input);
                var isNotNullOrEmpty = !string.IsNullOrEmpty(result);
                var isNotNullOrWhiteSpace = !string.IsNullOrWhiteSpace(result);

                // assert
                Assert.IsTrue(isNotNullOrEmpty && isNotNullOrWhiteSpace);
                Assert.AreEqual((string)testCase.Expected, result);
            }

            // reset
            PipelineReset();
        }

        [TestMethod]
        public void Execute_Should_Pass()
        {
            // arrange
            var collection = new SecondaryCleanPipelineCollection.Execute();

            // act
            foreach (TestingModel testCase in collection.IngredientLists)
            {
                var input = (string)testCase.Input;
                PipelineResultModel result = pipeline.Execute(ref input, null, null);
                List<string> expected = (List<string>)((PipelineResultModel)testCase.Expected).result;

                // assert
                Assert.IsNotNull(result);
                Assert.AreEqual(expected.Count, ((List<string>)result.result).Count);
                foreach (int i in Enumerable.Range(0, expected.Count)){
                    Assert.AreEqual(expected[i], ((List<string>)result.result)[i]);
                }
                PipelineReset();
            }
        }

        [TestMethod]
        public void Execute_Should_Not_Pass()
        {
            // arrange
            var input = "*";
            var expected = "List of ingredients must be longer than 1 character.";

            // act
            PipelineResultModel result = pipeline.Execute(ref input, null, null);

            // assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.isSuccessful);
            Assert.AreEqual(expected, result.result);

            // reset
            PipelineReset();
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
