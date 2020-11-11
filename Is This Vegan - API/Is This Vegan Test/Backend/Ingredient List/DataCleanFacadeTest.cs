using Is_This_Vegan__Net_.Backend.Ingredient_List;
using Is_This_Vegan__Net_.Enums;
using Is_This_Vegan__Net_.Models;
using Is_This_Vegan_Test.Testing_Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using static Is_This_Vegan_Test.Testing_Helpers.IngredientListBackendCollection;

namespace Is_This_Vegan_Test.Backend.Ingredient_List
{
    [TestClass]
    public class DataCleanFacadeTest
    {
        string mediaPath;
        IngredientListBackend backend;

        public DataCleanFacadeTest()
        {
            // Set tessdata path
            var curentDirectoryPathArray = Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()).Split('\\');
            var tessdataArray = curentDirectoryPathArray.Take((int)curentDirectoryPathArray.Count() - 2).Append("Is This Vegan (Net)\\tessdata");
            var tessdataPath = string.Join("\\", tessdataArray);

            // Set Media directory path
            var temporaryGeneralTestImagePathArray = curentDirectoryPathArray.Take((int)curentDirectoryPathArray.Count() - 2).Append("Is This Vegan Test\\Media\\");
            mediaPath = string.Join("\\", temporaryGeneralTestImagePathArray);

            backend = new IngredientListBackend(tessdataPath);
        }

        [TestMethod]
        public void Constructor_Pipeline_Should_Be_Null_Should_Pass()
        {
            // arrange
            float? meanConfidence = 80.0f;

            // act
            var facade = new DataCleanFacade(null, meanConfidence);

            // assert
            Assert.IsNotNull(facade);
            Assert.IsNull(facade.pipeline);
        }

        [TestMethod]
        public void Constructor_Pipeline_Should_Be_PrimaryCleanPipeline_Should_Pass()
        {
            // arrange
            float? meanConfidence = 80.0f;

            // act 
            var facade = new DataCleanFacade(DataCleanEnum.ListPrimary, meanConfidence);

            // assert
            Assert.IsNotNull(facade);
            Assert.IsTrue(facade.pipeline is PrimaryCleanPipeline);
        }

        [TestMethod]
        public void Constructor_Pipeline_Should_Be_SecondaryCleanPipeline_Should_Pass()
        {
            // arrange
            float? meanConfidence = 80.0f;

            // act
            var facade = new DataCleanFacade(DataCleanEnum.ListSecondary, meanConfidence);

            // assert
            Assert.IsNotNull(facade);
            Assert.IsTrue(facade.pipeline is SecondaryCleanPipeline);
        }

        [TestMethod]
        public void Clean_PrimaryCleanPipeline_Should_Pass()
        {
            // arrange
            float? meanConfidence = 80.0f;
            var facade = new DataCleanFacade(DataCleanEnum.ListPrimary, meanConfidence);
            var testCases = new IngredientListHelperCollection.Execute();

            // act
            foreach (var testCase in testCases.IngredientLists)
            {
                var expected = (PipelineResultModel) testCase.Expected;
                PipelineResultModel result = facade.Clean(ref testCase.Input);

                // assert
                Assert.IsNotNull(result);
                Assert.AreEqual(result.isSuccessful, expected.isSuccessful);
                Assert.AreEqual(result.result, expected.result);
            }
        }

        public byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public void BackendReset()
        {
            backend.list = new IngredientListModel();
            backend.extraction = null;
            backend.exception = null;
        }
    }
}
