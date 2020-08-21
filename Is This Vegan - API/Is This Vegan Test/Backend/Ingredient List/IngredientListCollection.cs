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
        public List<KeyValuePair<string, List<string>>> ingredientLists { get; set; }

        public IngredientListCollection()
        {
            ingredientLists = new List<KeyValuePair<string, List<string>>>();

            // belvita_vanilla-cookie.jpg
            ingredientLists.Add(
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
                        "niacinimide",
                        "pyridoxine hydrochloride (vitamin b6)"
                    }
                )   
            );

            // glam-glow_glow-lace-sheet-mask.jpg
            ingredientLists.Add(
                new KeyValuePair<string, List<string>>("glam-glow_glow-lace-sheet-mask.jpg",
                    new List<string>()
                    {
                        "water\\aqua\\eau",
                        "butylene glycol",
                        "methylpropanediol",
                        "1,2-hexanediol",
                        "sodium hyaluranate",
                        "camellia sinensis (green tea) leaf extract",
                        "caffeine",
                        "coffea arabica (coffee) seed extract",
                        "glycerin",
                        "trehalose",
                        "panthenol",
                        "arginine",
                        "dipotassium glycyrrhizate",
                        "ethylhexylglycerine",
                        "dimethicone",
                        "dimethicone/peg-10/15 crosspolymer",
                        "glycereth-26",
                        "epigallocatechin gallate",
                        "tocophersolan",
                        "xanthan gum",
                        "decyl clucoside",
                        "trideceth-6",
                        "carbomer",
                        "poloxamer 235",
                        "poloxamer 338",
                        "dipropylene glycol",
                        "propanediol",
                        "ethylhexyl stearate",
                        "sodium polyacrylate",
                        "ammonium acryloyldimethyltaurate/vp coopolymer",
                        "peg-40 hydrogenated castor oil",
                        "fragrance",
                        "parfum",
                        "hexyl cinnamal",
                        "disodium edta",
                        "phenoxyethanol <ILN46462>"
                    }
                )
            );

            // jin_ramen.jpg
            ingredientLists.Add(
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

            // kate-sommerville_uncomplikated-spf-50.jpg
            ingredientLists.Add(
                new KeyValuePair<string, List<string>>("kate-sommerville_uncomplikated-spf-50.jpg",
                    new List<string>()
                    {
                        "alocohol denat",
                        "isobutane",
                        "propane",
                        "isododecane",
                        "ethylhexyl methoxycrylene",
                        "pvp",
                        "methyl dihydroabietate",
                        "hydrolyzed hyaluronic acid",
                        "rhodiola rosea root extract",
                        "water/aqua/eau",
                        "lavandula angustifolia (lavender) oil",
                        "silica",
                        "silylate",
                        "pentylene glycol"
                    }
                )
            );

            // lightlife_smart-bacon.jpg
            ingredientLists.Add(
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

            // moroccanoil_blonde-perfecting-purple-shampoo.jpg
            ingredientLists.Add(
                new KeyValuePair<string, List<string>>("moroccanoil_blonde-perfecting-purple-shampoo.jpg",
                    new List<string>()
                    {
                        "aqua/water/eau",
                        "sodium c14-16 olefin sulfonate",
                        "cocamidopropyl betaine",
                        "cocamidopropylamine oxide",
                        "parfum/fragrance",
                        "guar hydroxypropyltrimonium chloride",
                        "argania spinosa (argan) kernel oil",
                        "peg-40 hydrogenated castor oil",
                        "acrylates copolymer",
                        "peg-150 distearate",
                        "glycol stearate",
                        "hydroxyacetophenone",
                        "algin",
                        "glycerin",
                        "chitosan",
                        "trideceth-9",
                        "c12-13 pareth-9",
                        "c11-15 pareth-7",
                        "c12-16 pareth-9",
                        "silica dimethyl silylate",
                        "isopropyl alcohol",
                        "trideceth-12",
                        "citric acid",
                        "coconut acid",
                        "cocamidopropyl dimethylamine",
                        "caprylyl glycol",
                        "cetrimonium chloride",
                        "sodium glycolate",
                        "ci 60730 (ext. violet no. 2)",
                        "trimethylsiloxyamodimethicone",
                        "caprylic/capric triglyceride",
                        "phenoxyethanol",
                        "chlorphenesin",
                        "potassium sorbate",
                        "sodium benzoate",
                        "alpha-isomethyl ionone",
                        "linalool. mopps02"
                    }
                )
            );

            // omorovicza_thermal-cleansing-balm.png
            ingredientLists.Add(
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
            ingredientLists.Add(
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
        }

    }
}
