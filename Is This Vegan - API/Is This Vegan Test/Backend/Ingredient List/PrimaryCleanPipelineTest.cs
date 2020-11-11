using Is_This_Vegan__Net_.Backend.Ingredient_List;
using Is_This_Vegan__Net_.Models;
using Is_This_Vegan_Test.Testing_Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Is_This_Vegan_Test.Backend.Ingredient_List
{
    [TestClass]
    public class PrimaryCleanPipelineTest
    {
        PrimaryCleanPipeline pipeline;

        public PrimaryCleanPipelineTest()
        {
            pipeline = new PrimaryCleanPipeline();
        }

        [TestMethod]
        public void Execute_Should_Pass()
        {
            // arrange
            var testingHelper = new IngredientListHelperCollection.Execute();

            // act
            foreach (TestingModel ingredientList in testingHelper.IngredientLists)
            {
                var input = ingredientList.Input;
                var result = pipeline.Execute(ref input, null, (float?)80.0); // assume all extraction confidences are 100%
                var expected = (PipelineResultModel)ingredientList.Expected;

                // assert
                Assert.AreEqual(result.isSuccessful, expected.isSuccessful);
                Assert.AreEqual(result.result, expected.result);
            }
        }

        [TestMethod]
        public void Remove_Should_Pass()
        {
            // arrange
            var testCases = new PrimaryCleanPipelineCollection.Remove();

            // act
            foreach (TestingModel testCase in testCases.IngredientLists)
            {
                var expected = (string)testCase.Expected;
                string result = pipeline.Remove( (string)testCase.Input );

                // Assert
                Assert.AreEqual(result, expected);
            }
        }

        [TestMethod]
        public void IsValid_Valid_List_And_Valid_Confidence_Should_Pass()
        {
            // arrange
            var testList = "this is my list 123, period.";
            float? testConfidence = 70.01f;

            // act
            PipelineResultModel result = pipeline.IsValid(testList, testConfidence);

            // assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result is PipelineResultModel);
            Assert.IsTrue(result.isSuccessful);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsValid_Valid_List_And_Invalid_Confidence_Is_Null_Should_Not_Pass()
        {
            // arrange
            var testList = "{}909  ..-_* this is another test string";
            float? testConfidence = null;

            // act
            PipelineResultModel result = pipeline.IsValid(testList, testConfidence);

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IsValid_Valid_List_And_Invalid_Confidence_Is_Not_Float_Should_Not_Pass()
        {
            // arrange
            var testList = "{}909  ..-_* this is another test string";
            float? testConfidence = 10;

            // act
            PipelineResultModel result = pipeline.IsValid(testList, testConfidence);

            // assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result is PipelineResultModel);
            Assert.IsFalse(result.isSuccessful);
        }

        [TestMethod]
        public void IsValid_Valid_List_And_Invalid_Confidence_Is_Too_Low_Should_Not_Pass()
        {
            // arrange
            var testList = "{}909  ..-_* this is another test string";
            float? testConfidence = 70.00f;

            // act
            PipelineResultModel result = pipeline.IsValid(testList, testConfidence);

            // assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result is PipelineResultModel);
            Assert.IsFalse(result.isSuccessful);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsValid_Invalid_List_Is_Empty_And_Valid_Confidence_Should_Not_Pass()
        {
            // arrange
            var testList = "";
            float? testConfidence = 70.1f;

            // act
            var result = pipeline.IsValid(testList, testConfidence);

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsValid_Invalid_List_Is_Whitespace_And_Valid_Confidence_Should_Not_Pass()
        {
            // arrange
            var testList = "  ";
            float? testConfidence = 70.1f;

            // act
            PipelineResultModel result = pipeline.IsValid(testList, testConfidence);

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IsValid_Invalid_List_Is_Too_Short_And_Valid_Confidence_Should_Not_Pass()
        {
            // arrange
            var testList = "a";
            float? testConfidence = 70.1f;

            // act
            PipelineResultModel result = pipeline.IsValid(testList, testConfidence);

            // assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result is PipelineResultModel);
            Assert.IsFalse(result.isSuccessful);
        }
    }
}
