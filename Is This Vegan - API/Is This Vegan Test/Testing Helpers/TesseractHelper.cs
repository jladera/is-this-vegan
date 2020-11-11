using Is_This_Vegan__Net_.Backend.Ingredient_List;
using Is_This_Vegan__Net_.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Is_This_Vegan_Test.Testing_Helpers
{
    public class TesseractHelper
    {
        public string TessdataPath;
        public string MediaPath;
        public IngredientListBackend Backend;

        public TesseractHelper(string tessdataPath, string mediaPath)
        {
            TessdataPath = tessdataPath;
            MediaPath = mediaPath;
            Backend = new IngredientListBackend(TessdataPath);
            Backend.list = new IngredientListModel();
        }

        /// <summary>
        /// Performs text extraction through the use of IngredientListBackend
        /// </summary>
        /// <param name="filename"> Test image filename in Media folder ex. "belvita_vanilla-cookie.jpg" </param>
        /// <returns> Extracted text from </returns>
        public string GetIngredientList(string filename)
        {
            Backend.ExtractFromImageTest(new Bitmap(MediaPath + filename));
            var result = Backend.list.ingredientListRaw;

            //BackendReset();

            return result;
        }

        /// <summary>
        /// Resets IngredientListBackend class properties that would be changed as a result of text extraction.
        /// </summary>
        public void BackendReset(IngredientListBackend backend)
        {
            backend.list = null;
            backend.extraction = null;
            backend.exception = null;
        }
    }
}
