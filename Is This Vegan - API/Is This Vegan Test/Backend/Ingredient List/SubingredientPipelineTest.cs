using Is_This_Vegan__Net_.Backend.Ingredient_List;
using Is_This_Vegan__Net_.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Is_This_Vegan_Test.Backend.Ingredient_List
{
    [TestClass]
    public class SubingredientPipelineTest
    {
        string mediaFolderPath;
        IngredientListBackend backend;

        public SubingredientPipelineTest()
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
        }

        [TestMethod]
        public void FindIngredientsWithSubingredients_Belvita_Vanilla_Cookie_Should_Pass()
        {
            // arrange
            
            var subingredientPipeline = new SubingredientPipeline();
            var input = GetIngredientList("belvita_vanilla-cookie.jpg");
            var expected = new List<string>() {
                "ENRICHED FLOUR\n[WHEAT FLOUR, NIACIN, REDUCED IRON, THIAMIN MONONITRATE\n(VITAMIN B1), RIBOFLAVIN (VITAMIN B2), FOLIC ACID}"
            };

            // act
            var result = subingredientPipeline.FindIngredientsWithSubingredients(input);

            // assert
            foreach(int index in Enumerable.Range(0, result.Count))
            {
                var resultValue = result[index].Value;
                var expectedValue = expected[index];
                Assert.AreEqual(resultValue, expectedValue);
            }
        }

        /// <summary>
        /// Performs text extraction through the use of IngredientListBackend
        /// </summary>
        /// <param name="filename"> Test image filename in Media folder ex. "belvita_vanilla-cookie.jpg" </param>
        /// <returns> Extracted text from </returns>
        public string GetIngredientList(string filename)
        {
            // extract text
            backend.list = new IngredientListModel();
            backend.ExtractFromImageTest(new Bitmap(mediaFolderPath + filename));
            var result = backend.list.ingredientListRaw;

            BackendReset();

            return result;
        }

        /// <summary>
        /// Resets IngredientListBackend class properties that would be changed as a result of text extraction.
        /// </summary>
        public void BackendReset()
        {
            backend.list = null;
            backend.extraction = null;
            backend.exception = null;
        }
    }
}
