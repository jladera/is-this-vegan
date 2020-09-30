using Is_This_Vegan__Net_.Backend.Ingredient_List;
using Is_This_Vegan__Net_.Enums;
using Is_This_Vegan__Net_.Models;
using Is_This_Vegan_Test.Testing_Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;
using System.Linq;
using static Is_This_Vegan_Test.Testing_Helpers.IngredientListHelperCollection;

namespace Is_This_Vegan_Test.Backend.Ingredient_List
{
    [TestClass]
    public class IngredientListHelperTest
    {
        string mediaFolderPath;
        IngredientListBackend backend;
        IngredientListHelper helper;

        public IngredientListHelperTest()
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
            helper = new IngredientListHelper();
        }

        [TestMethod]
        public void Execute_Should_Pass()
        {
            // arrange
            var testingHelper = new Execute();

            // act
            foreach (TestingModel ingredientList in testingHelper.IngredientLists)
            {
                var input = ingredientList.Input;
                var result = helper.Execute(ref input, DataCleanEnum.ListPrimary, (float?)100.00); // assume all extraction confidences are 100%
                var expected = (PipelineResultModel)ingredientList.Expected;

                // assert
                Assert.AreEqual(result.isSuccessful, expected.isSuccessful);
                Assert.AreEqual(result.result, expected.result);
            }
        }
    }
}
