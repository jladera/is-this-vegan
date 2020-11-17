using Is_This_Vegan__Net_.Backend.Interfaces;
using Is_This_Vegan__Net_.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Razor.Generator;
using Is_This_Vegan__Net_.Enums;
using System.Xml;

namespace Is_This_Vegan__Net_.Backend.Ingredient
{
    public class IngredientLocalRepository : IDataAccessRepository
    {
        // Path to Media folder wherein lies the txt files representing
        // database tables
        public string mediaPath;

        public IngredientLocalRepository(string mediaPath)
        {
            this.mediaPath = mediaPath;
        }

        /// <summary>
        /// Inserts ingredient record
        /// </summary>
        /// <param name="ingredient"> New ingredient to insert </param>
        /// <returns> True if successful, false otherwise</returns>
        public bool Create(IngredientModel ingredient)
        {
            try
            {
                // Waits until file is not in use
                while (FileIsInUse(mediaPath + "UnclassifiedIngredients.txt")) { }

                File.AppendAllText(mediaPath + "UnclassifiedIngredients.txt", ingredient.Name + "\n");
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Deleting ingredients is not supported via API
        /// </summary>
        /// <param name="ingredient"> Ingredient to delete </param>
        /// <returns> Throws NotSupportedException </returns>
        public bool Delete(IngredientModel ingredient)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Reads ingredients from local text files.
        /// </summary>
        /// <param name="name"> Ingredient name </param>
        /// <returns> Ingredient with its classification </returns>
        public IngredientModel Read(string name)
        {
            IngredientModel result;
            if (IsNonVegan(name))
            {
                result = new IngredientModel() { Name = name, Classification = IngredientClassificationEnum.NotVegan };
            }
            else if (IsUnclassified(name))
            {
                result = new IngredientModel() { Name = name, Classification = IngredientClassificationEnum.Unclassified };
            }
            else if (Exists(name))
            {
                result = new IngredientModel() { Name = name, Classification = IngredientClassificationEnum.Vegan };
            }
            else
            {
                result = new IngredientModel() { Name = name, Classification = IngredientClassificationEnum.MaybeVegan };

                // Add to new ingredients
                Create(result);
            }

            return result;
        }

        /// <summary>
        /// Determines if ingredient is not vegan
        /// </summary>
        /// <param name="name"> Ingredient name </param>
        /// <returns> 
        ///     True if ingredient is found in NonVeganIngredients.txt file,
        ///     false otherwise.
        /// </returns>
        public bool IsNonVegan(string name)
        {
            var ingredients = File.ReadAllText(mediaPath + "NonVeganIngredients.txt");

             if (ingredients.Contains(name))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines if ingredient is part of our ingredient dictionary
        /// </summary>
        /// <param name="name"> Ingredient name </param>
        /// <returns>
        ///     True if ingredient is found in IngredientDictionary.txt file,
        ///     false otherwise.
        /// </returns>
        public bool Exists(string name)
        {
            var ingredients = File.ReadAllText(mediaPath + "IngredientDictionary.txt");

            if (ingredients.Contains(name))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines if ingredient is part of our unclassified ingredient list
        /// </summary>
        /// <param name="name"> Ingredient name </param>
        /// <returns>
        ///     True if ingredient is found in UnclassifiedIngredients.txt file,
        ///     false otherwise.
        /// </returns>
        public bool IsUnclassified(string name)
        {
            var ingredients = File.ReadAllText(mediaPath + "UnclassifiedIngredients.txt");

            if (ingredients.Contains(name))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if file is currently in use by another process
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool FileIsInUse(string filename)
        {
            bool locked = false;
            try
            {
                FileStream fs =
                    File.Open(filename, FileMode.OpenOrCreate,
                    FileAccess.ReadWrite, FileShare.None);
                fs.Close();
            }
            catch (IOException)
            {
                locked = true;
            }
            return locked;
        }

        /// <summary>
        /// Updating ingredients is not supported via API in first version
        /// </summary>
        /// <param name="ingredient"> Ingredient to update </param>
        /// <returns> Throws NotSupportedException </returns>
        public bool Update(IngredientModel ingredient)
        {
            throw new NotSupportedException();
        }
    }
}