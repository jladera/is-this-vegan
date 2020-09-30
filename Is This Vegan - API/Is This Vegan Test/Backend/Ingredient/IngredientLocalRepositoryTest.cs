using Is_This_Vegan__Net_.Backend.Ingredient;
using Is_This_Vegan__Net_.Backend.Ingredient_List;
using Is_This_Vegan__Net_.Enums;
using Is_This_Vegan__Net_.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Is_This_Vegan_Test.Backend.Ingredient
{
    [TestClass]
    public class IngredientLocalRepositoryTest
    {
        string generalTestImagePath;
        IngredientLocalRepository IngredientLocalRepository;

        public IngredientLocalRepositoryTest()
        {
            // Get path to current directory
            var curentDirectoryPathArray = Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()).Split('\\');
            
            // Remove last two directories (bin and this project) and add directories for API project and tessdata
            var tessdataArray = curentDirectoryPathArray.Take((int)curentDirectoryPathArray.Count() - 2).Append("Is This Vegan (Net)\\tessdata");
            
            // Join to form valid string path
            var tessdataPath = string.Join("\\", tessdataArray);

            // Set general test image path
            var mediaPathArray = curentDirectoryPathArray.Take((int)curentDirectoryPathArray.Count() - 2).Append("Is This Vegan (Net)\\Media\\");
            var mediaPath = string.Join("\\", mediaPathArray);

            IngredientLocalRepository = new IngredientLocalRepository(mediaPath);
        }

        [TestMethod]
        public void Read_Should_Pass()
        {
            // arrange
            var input = "niacin";
            IngredientModel expected = new IngredientModel() { Classification = IngredientClassificationEnum.Vegan, Name = "niacin" };

            // act
            var result = IngredientLocalRepository.Read(input);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Classification, expected.Classification);
            Assert.AreEqual(result.Name, expected.Name);
        }
    }
}
