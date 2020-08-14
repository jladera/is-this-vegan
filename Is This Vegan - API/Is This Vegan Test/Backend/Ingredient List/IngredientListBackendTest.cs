using Is_This_Vegan__Net_.Backend.Ingredient_List;
using Is_This_Vegan__Net_.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Is_This_Vegan_Test.Backend.Ingredient_List
{
    [TestClass]
    public class IngredientListBackendTest
    {
        string generalTestImagePath;
        IngredientListBackend backend;
        IngredientListHelper helper;

        public IngredientListBackendTest()
        {
            // Get path to current directory
            var curentDirectoryPathArray = Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()).Split('\\');
            
            // Remove last two directories (bin and this project) and add directories for API project and tessdata
            var tessdataArray = curentDirectoryPathArray.Take((int)curentDirectoryPathArray.Count() - 2).Append("Is This Vegan (Net)\\tessdata");
            
            // Join to form valid string path
            var tessdataPath = string.Join("\\", tessdataArray);

            // Set general test image path
            var temporaryGeneralTestImagePathArray = curentDirectoryPathArray.Take((int)curentDirectoryPathArray.Count() - 2).Append("Is This Vegan Test\\Media\\belvita_vanilla-cookie.jpg");
            generalTestImagePath = string.Join("\\", temporaryGeneralTestImagePathArray);


            backend = new IngredientListBackend(tessdataPath);
            helper = new IngredientListHelper();
        }

        [TestMethod]
        public void ExtractFromImage_Should_Pass()
        {
            // arrange
             var testImage = Bitmap.FromFile(generalTestImagePath);
            var byteArray = ImageToByte(testImage);
            var imageAsString = Convert.ToBase64String(byteArray);
            var ingredientListModel = new IngredientListModel() { imageAsString = imageAsString};

            // act
            var result = backend.ExtractFromImage(ingredientListModel);

            // assert
            Assert.IsTrue(result);

            // reset
            BackendReset();
        }

        [TestMethod]
        public void ExtractFromImageTest_Image_Not_Null_Should_Pass()
        {
            // arrange
            string expectedExtractedText = " \n\nwpe erera paresis\n\nINGREDIENTS: WHOLE GRAIN WHEAT FLOUR, ENRICHED FLOUR\n[WHEAT FLOUR, NIACIN, REDUCED IRON, THIAMIN MONONITRATE\n(VITAMIN B1), RIBOFLAVIN (VITAMIN B2), FOLIC ACID}, SUGAR, CANOLA\nOIL, WHOLE GRAIN ROLLED OATS, WHOLE GRAIN RYE FLOUR, BAKING\nSODA, DISODIUM PYROPHOSPHATE, SALT, SOY LECITHIN, DATEM,\nNATURAL FLAVOR, FERRIC ORTHOPHOSPHATE (IRON), NIACINAMIDE,\n__ PYRIDOXINE HYDROCHLORIDE (VITAMIN B6), RIBOFLAVIN (VITAMIN B2),\n| THIAMIN MONONITRATE (VITAMIN B1).\n\n   \n";
            backend.list = new IngredientListModel();
            var testImage = new Bitmap(generalTestImagePath);

            // act
            var result = backend.ExtractFromImageTest(testImage);

            // assert
            Assert.IsTrue(result);
            Assert.AreEqual(expectedExtractedText, backend.list.ingredientListRaw);

            // reset
            BackendReset();
        }

        [TestMethod]
        public void ExtractFromImageTest_Image_Null_Should_Not_Pass()
        {
            // arrange
            backend.list = new IngredientListModel();

            // act
            var result = backend.ExtractFromImageTest();

            // assert
            Assert.IsFalse(result);
            Assert.IsNotNull(backend.exception);

            // reset
            BackendReset();
        }

        public byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public void BackendReset()
        {
            backend.list = null;
            backend.extraction = null;
            backend.exception = null;
        }
    }
}
