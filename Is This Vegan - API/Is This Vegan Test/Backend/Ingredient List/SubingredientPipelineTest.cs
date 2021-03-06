﻿using Is_This_Vegan__Net_.Backend.Ingredient_List;
using Is_This_Vegan__Net_.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Is_This_Vegan_Test.Backend.Ingredient_List
{
    [TestClass]
    public class SubingredientPipelineTest
    {
        string mediaFolderPath;
        IngredientListBackend backend;
        SubingredientPipeline pipeline;

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
            pipeline = new SubingredientPipeline();
        }

        [TestMethod]
        public void Execute_Belvita_Vanilla_Cookie_Should_Pass()
        {
            // arrange
            var input = GetIngredientList("belvita_vanilla-cookie.jpg");
            var expectedCleanedList = " \n\nwpe erera paresis\n\nINGREDIENTS: WHOLE GRAIN WHEAT FLOUR, WHEAT FLOUR, NIACIN, REDUCED IRON, THIAMIN MONONITRATE\n(VITAMIN B1), RIBOFLAVIN (VITAMIN B2), FOLIC ACID, SUGAR, CANOLA\nOIL, WHOLE GRAIN ROLLED OATS, WHOLE GRAIN RYE FLOUR, BAKING\nSODA, DISODIUM PYROPHOSPHATE, SALT, SOY LECITHIN, DATEM,\nNATURAL FLAVOR, FERRIC ORTHOPHOSPHATE (IRON), NIACINAMIDE,\n__ PYRIDOXINE HYDROCHLORIDE (VITAMIN B6), RIBOFLAVIN (VITAMIN B2),\n| THIAMIN MONONITRATE (VITAMIN B1).\n\n   \n";

            // act
            var result = pipeline.Execute(ref input);

            // assert
            Assert.IsTrue(result);
            Assert.AreEqual(expectedCleanedList, pipeline.cleanedList);
        }

        [TestMethod]
        public void FindIngredientsWithSubingredients_Belvita_Vanilla_Cookie_Should_Pass()
        {
            // arrange
            var input = GetIngredientList("belvita_vanilla-cookie.jpg");
            var expected = "ENRICHED FLOUR\n[WHEAT FLOUR, NIACIN, REDUCED IRON, THIAMIN MONONITRATE\n(VITAMIN B1), RIBOFLAVIN (VITAMIN B2), FOLIC ACID}";

            // act
            var result = pipeline.Find(input)[0].Value;

            // assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void ExtractSubingredients_Belvita_Vanilla_Cookie_Should_Pass()
        {
            // arrange
            var input = GetIngredientList("belvita_vanilla-cookie.jpg");
            var expected = "WHEAT FLOUR, NIACIN, REDUCED IRON, THIAMIN MONONITRATE\n(VITAMIN B1), RIBOFLAVIN (VITAMIN B2), FOLIC ACID";

            // act
            var result = pipeline.ExtractSubingredients(input)[0].Value;

            //assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void Replace_Belvita_Vanilla_Cookie_Should_Pass()
        {
            // arrange
            var input = GetIngredientList("belvita_vanilla-cookie.jpg");
            var toReplace = pipeline.Find(input);
            var subingredients = pipeline.ExtractSubingredients(input);
            var expected = " \n\nwpe erera paresis\n\nINGREDIENTS: WHOLE GRAIN WHEAT FLOUR, WHEAT FLOUR, NIACIN, REDUCED IRON, THIAMIN MONONITRATE\n(VITAMIN B1), RIBOFLAVIN (VITAMIN B2), FOLIC ACID, SUGAR, CANOLA\nOIL, WHOLE GRAIN ROLLED OATS, WHOLE GRAIN RYE FLOUR, BAKING\nSODA, DISODIUM PYROPHOSPHATE, SALT, SOY LECITHIN, DATEM,\nNATURAL FLAVOR, FERRIC ORTHOPHOSPHATE (IRON), NIACINAMIDE,\n__ PYRIDOXINE HYDROCHLORIDE (VITAMIN B6), RIBOFLAVIN (VITAMIN B2),\n| THIAMIN MONONITRATE (VITAMIN B1).\n\n   \n";

            // act
            var result = pipeline.Replace(input, toReplace, subingredients);

            //assert
            Assert.AreEqual(result, expected);
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
