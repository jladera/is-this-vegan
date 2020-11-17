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
using System.Security.Policy;

namespace Is_This_Vegan_Test.Backend.Ingredient
{
    [TestClass]
    public class IngredientLocalRepositoryTest
    {
        IngredientLocalRepository IngredientLocalRepository;

        public IngredientLocalRepositoryTest()
        {
            // Get path to current directory
            var curentDirectoryPathArray = Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()).Split('\\');

            // Set Media directory path
            var temporaryGeneralTestImagePathArray = curentDirectoryPathArray.Take((int)curentDirectoryPathArray.Count() - 2).Append("Is This Vegan (Net)\\Media\\");
            var mediaPath = string.Join("\\", temporaryGeneralTestImagePathArray);

            IngredientLocalRepository = new IngredientLocalRepository(mediaPath);
        }

        [TestMethod]
        public void Read_Vegan_Ingredient_Should_Pass()
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

        [TestMethod]
        public void Read_NonVegan_Ingredient_Should_Pass()
        {
            // arrange
            var input = "carmine";
            IngredientModel expected = new IngredientModel() { Classification = IngredientClassificationEnum.NotVegan, Name = "carmine" };

            // act
            var result = IngredientLocalRepository.Read(input);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Classification, expected.Classification);
            Assert.AreEqual(expected.Name, result.Name);
        }

        [TestMethod]
        public void Read_MaybeVegan_Ingredient_Should_Pass()
        {
            // arrange
            var input = "propanediol";
            IngredientModel expected = new IngredientModel() { Classification = IngredientClassificationEnum.MaybeVegan, Name = "propanediol" };
            var resetContent = GetList("UnclassifiedIngredients.txt");

            // act
            var result = IngredientLocalRepository.Read(input);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Classification, expected.Classification);
            Assert.AreEqual(expected.Name, result.Name);
            Assert.IsTrue(GetList("UnclassifiedIngredients.txt").Contains(input));

            // reset
            ResetList("UnclassifiedIngredients.txt", resetContent);
        }

        [TestMethod]
        public void Read_Unclassified_Ingredient_Should_Pass()
        {
            // arrange
            var input = "propanediol";
            IngredientModel expected = new IngredientModel() { Classification = IngredientClassificationEnum.Unclassified, Name = "propanediol" };
            var resetContent = GetList("UnclassifiedIngredients.txt");
            IngredientLocalRepository.Read(input);

            // act
            var result = IngredientLocalRepository.Read(input);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Classification, expected.Classification);
            Assert.AreEqual(expected.Name, result.Name);

            // reset
            ResetList("UnclassifiedIngredients.txt", resetContent);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Update_Should_Not_Pass()
        {
            // arrange
            var input = new IngredientModel();

            // act
            IngredientLocalRepository.Update(input);
        }

        public string GetList(string filename)
        {
            return File.ReadAllText(IngredientLocalRepository.mediaPath + filename);
        }

        public void ResetList(string filename, string content)
        {
            File.WriteAllText(IngredientLocalRepository.mediaPath + filename, content);
        }
    }
}
