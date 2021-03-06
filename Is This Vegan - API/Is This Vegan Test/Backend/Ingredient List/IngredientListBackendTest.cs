﻿using Is_This_Vegan__Net_.Backend.Ingredient_List;
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
    public class IngredientListBackendTest
    {
        string mediaPath;
        IngredientListBackend backend;

        public IngredientListBackendTest()
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
        public void ExtractFromImage_Should_Pass()
        {
            // arrange
            var testImage = Bitmap.FromFile(mediaPath + "belvita_vanilla-cookie.jpg");
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
            var testHelper = new ExtractFromImageTest();
            backend.list = new IngredientListModel();

            // act 
            foreach (TestingModel ingredientList in testHelper.IngredientLists)
            {
                var bitmap = new Bitmap(mediaPath + ingredientList.Filename);
                var result = backend.ExtractFromImageTest(bitmap);

                // assert
                Assert.IsTrue(result);
                Assert.AreEqual(backend.list.ingredientListRaw, ingredientList.Expected);

                // reset
                BackendReset();
            }
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
            backend.list = new IngredientListModel();
            backend.extraction = null;
            backend.exception = null;
        }
    }
}
