/*
 * Author: Jake Ladera
 * Version: 1.0
 * 
 * Summary:
 *  This class has a list of ingredient lists. Each element in the list will
 *  contain another list of the ingredients .
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Is_This_Vegan_Test.Backend.Ingredient_List
{
    public class IngredientListCollection
    {
        // The list of ingredient lists. Each KeyValuePair will be in the format:
        //  Key = test photo file name
        //  Value = a list of strings representing the ingredients for the product. 
        public List<KeyValuePair<string, List<string>>> validIngredientLists { get; set; }
        public List<string> invalidIngredientLists { get; set; }

        public IngredientListCollection()
        {
            // valid ingredients
            validIngredientLists = new List<KeyValuePair<string, List<string>>>();

            // belvita_vanilla-cookie.jpg
            validIngredientLists.Add(
                new KeyValuePair<string, List<string>>("belvita_vanilla-cookie.jpg",
                    new List<string>()
                    {
                        "whole grain wheat flour",
                        "wheat flour",
                        "niacin",
                        "reduced iron",
                        "thiamin mononitrate (vitamin b1)",
                        "riboflavin (vitamin b2)",
                        "folic acid",
                        "sugar",
                        "canola oil",
                        "whole grain rolled oats",
                        "whole grain rye flour",
                        "baking soda",
                        "disodium pyrophosphate",
                        "salt",
                        "soy lecithin",
                        "datem",
                        "natural flavor",
                        "ferric orthophosphate (iron)",
                        "niacinamide",
                        "pyridoxine hydrochloride (vitamin b6)"
                    }
                )   
            );

            // jin_ramen.jpg
            validIngredientLists.Add(
                new KeyValuePair<string, List<string>>("jin_ramen.jpg",
                    new List<string>()
                    {
                        "wheat flour",
                        "potato",
                        "tapioca",
                        "palm oil",
                        "potato starch",
                        "wheat gluten",
                        "salt",
                        "yeast extract",
                        "potassium carbonate",
                        "sodium polyphosphate",
                        "riboflavin",
                        "sugar",
                        "soy bean",
                        "wheat",
                        "garlic powder",
                        "red pepper",
                        "garlic",
                        "onion",
                        "green onion",
                        "ginger",
                        "monosodium glutamate",
                        "glucose",
                        "soy",
                        "corn",
                        "chilli extract",
                        "yeast extract powder",
                        "black pepper",
                        "kelp extract powder",
                        "disodium inosinate",
                        "disodium guanylate",
                        "dextrin",
                        "malic acid",
                        "chinese cabbage",
                        "carrot",
                        "mushroom"
                    }
                )
            );

            // lightlife_smart-bacon.jpg
            validIngredientLists.Add(
                new KeyValuePair<string, List<string>>("lightlife_smart-bacon.jpg",
                    new List<string>()
                    {
                        "water",
                        "soy protein",
                        "isolate",
                        "vital wheat gluten",
                        "soybean oil",
                        "soy protein concentrate",
                        "textured wheat gluten",
                        "salt",
                        "sugar",
                        "carrageenan",
                        "natural flavor",
                        "autolyzed yeast extract",
                        "natural smoke flavor",
                        "spices",
                        "fermented rice flour",
                        "paprika",
                        "color",
                        "potassium chloride"
                    }
                )
            );

            // omorovicza_thermal-cleansing-balm.png
            validIngredientLists.Add(
                new KeyValuePair<string, List<string>>("omorovicza_thermal-cleansing-balm.png",
                    new List<string>()
                    {
                        "prunus amygdalus dulcis (sweet almond) oil",
                        "cetearyl ethylhexanoate",
                        "glyceryl stearate",
                        "silt (hungarian mud)",
                        "cera alba (beeswax)",
                        "squalane",
                        "stearyl heptanoate",
                        "cetearyl alcohol",
                        "prunus domestica (plum) seed extract",
                        "prunus armeniaca (apricot) kernel oil",
                        "sodium cocoyl glutamate",
                        "phenoxyethanol",
                        "parfum (fragrance)",
                        "benzyl alcohol",
                        "ethylhexylglycerin",
                        "tocopherol",
                        "saccharomyces (hungarian thermal water) ferment extract",
                        "aqua (hungarian thermal water)",
                        "malpighia punicifolia (acerola) fruit extract",
                        "aqua",
                        "dehydroacetic acid",
                        "phospholipids",
                        "linalool",
                        "limonene"
                    }
                )
            );

            // too-faced_better-than-sex-mascara.jpg
            validIngredientLists.Add(
                new KeyValuePair<string, List<string>>("too-faced_better-than-sex-mascara.jpg",
                    new List<string>()
                    {
                        "aqua/water/eau",
                        "synthetic beeswax",
                        "paraffin",
                        "glyceryl stearate",
                        "acacia senegal gum",
                        "butylene glycol",
                        "oryza sativa (rice) bran wax/oryza sativa bran cera",
                        "stearic acid",
                        "palmitic acid",
                        "polybutene",
                        "vp/eicosene copolymer",
                        "copernicia cerifera (carnauba) wax/copernicia cerifera cera/cire de carnauba",
                        "aminomethyl propanol",
                        "glycerin",
                        "pvp",
                        "ethylhexylglycerin",
                        "hydroxyethylcellulose",
                        "disodium edta",
                        "polyester-11",
                        "cellulose",
                        "trimethylpentanediol/adipic acid/glycerin crosspolymer",
                        "propylene glycol",
                        "disodium phosphate",
                        "polysorbate 60",
                        "acacia seyal gum extract",
                        "sodium phosphate",
                        "acetyl hexapeptide-1",
                        "dextran",
                        "phenoxyethanol",
                        "potassium sorbate",
                        "iron oxides (ci 77499)",
                        "ultramarines (ci 77007)",
                        "black 2 (ci 77266)"
                    }
                )
            );


            // invalid ingredient lists
            invalidIngredientLists = new List<string>();

            // glam-glow_glow-lace-sheet-mask.jpg
            invalidIngredientLists.Add("glam-glow_glow-lace-sheet-mask.jpg");

            // kate-sommerville_uncomplikated-spf-50.jpg
            invalidIngredientLists.Add("kate-sommerville_uncomplikated-spf-50.jpg");

            // moroccanoil_blonde-perfecting-purple-shampoo.jpg
            invalidIngredientLists.Add("moroccanoil_blonde-perfecting-purple-shampoo.jpg");
            );
        }
    }
}
