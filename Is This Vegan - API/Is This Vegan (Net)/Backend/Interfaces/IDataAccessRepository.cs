using Is_This_Vegan__Net_.Enums;
using Is_This_Vegan__Net_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Is_This_Vegan__Net_.Backend.Interfaces
{
    public interface IDataAccessRepository
    {
        /// <summary>
        /// Inserts ingredient
        /// </summary>
        /// <param name="ingredient"> Ingredient to insert </param>
        /// <returns> True if successful, false otherwise </returns>
        bool Create(IngredientModel ingredient);

        /// <summary>
        /// Fetches ingredient
        /// </summary>
        /// <param name="name"> Ingredient name to read </param>
        /// <returns> The ingredient with the matching name </returns>
        IngredientModel Read(string name);

        /// <summary>
        /// Updates ingredient data
        /// </summary>
        /// <param name="ingredient"> Ingredient with updated data </param>
        /// <returns> True if successful, false otherwise </returns>
        bool Update(IngredientModel ingredient);

        /// <summary>
        /// Removes ingredient if the ingredient isn't core
        /// </summary>
        /// <param name="ingredient"> The ingredient to delete </param>
        /// <returns> True if successful, false otherwise </returns>
        bool Delete(IngredientModel ingredient);
    }
}
