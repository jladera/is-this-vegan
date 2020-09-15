/*
 * Author: Jake Ladera
 * Version: 1.0
 * 
 * Summary:
 *  This class has a list of ingredient lists. Each element in the list will
 *  contain another list of the ingredients .
 */
using Is_This_Vegan__Net_.Models;
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
        public List<string> successfulIngredientLists { get; set; }
        public List<string> unsuccessfulIngredientLists { get; set; }

        // Expected values from PrimaryCleanPipeline Execute
        public List<KeyValuePair<string, PipelineResultModel>> pcpExpected { get; set; }

        // Example user-validated ingredient lists (uvLists) serving as input for SecondaryCleanPipeline
        public List<KeyValuePair<string, string>> uvLists { get; set; }

        // Expected values from SecondaryCleanPipelineExecute
        public List<KeyValuePair<string, PipelineResultModel>> scpExpected { get; set; }

        public IngredientListCollection()
        {
            #region Successful Ingredient Lists
            successfulIngredientLists = new List<string>();

            // belvita_vanilla-cookie.jpg
            successfulIngredientLists.Add("belvita_vanilla-cookie.jpg");

            // jin_ramen.jpg
            successfulIngredientLists.Add("jin_ramen.jpg");

            // lightlife_smart-bacon.jpg
            successfulIngredientLists.Add("lightlife_smart-bacon.jpg");

            // omorovicza_thermal-cleansing-balm.png
            successfulIngredientLists.Add("omorovicza_thermal-cleansing-balm.png");

            // too-faced_better-than-sex-mascara.jpg
            successfulIngredientLists.Add("too-faced_better-than-sex-mascara.jpg");
            #endregion

            #region Unsuccessful Ingredient Lists
            unsuccessfulIngredientLists = new List<string>();

            // glam-glow_glow-lace-sheet-mask.jpg
            unsuccessfulIngredientLists.Add("glam-glow_glow-lace-sheet-mask.jpg");

            // kate-sommerville_uncomplikated-spf-50.jpg
            unsuccessfulIngredientLists.Add("kate-sommerville_uncomplikated-spf-50.jpg");

            // moroccanoil_blonde-perfecting-purple-shampoo.jpg
            unsuccessfulIngredientLists.Add("moroccanoil_blonde-perfecting-purple-shampoo.jpg");
            #endregion

            #region PrimaryCleanPipeline
            // PrimaryCleanPipeline list
            pcpExpected = new List<KeyValuePair<string, PipelineResultModel>>();

            #region Successful Ingredient List Extractions
            // belvita_vanilla-cookie.jpg
            pcpExpected.Add(new KeyValuePair<string, PipelineResultModel>(
                "belvita_vanilla-cookie.jpg",
                new PipelineResultModel()
                {
                    isSuccessful = true,
                    result = "wpe erera paresis  ingredients: whole grain wheat flour, enriched flour [wheat flour, niacin, reduced iron, thiamin mononitrate (vitamin b1), riboflavin (vitamin b2), folic acid}, sugar, canola oil, whole grain rolled oats, whole grain rye flour, baking soda, disodium pyrophosphate, salt, soy lecithin, datem, natural flavor, ferric orthophosphate (iron), niacinamide,  pyridoxine hydrochloride (vitamin b6), riboflavin (vitamin b2),  thiamin mononitrate (vitamin b1)."
                })
            );

            // jin_ramen.jpg
            pcpExpected.Add(new KeyValuePair<string, PipelineResultModel>(
                "jin_ramen.jpg",
                new PipelineResultModel()
                {
                    isSuccessful = true,
                    result = "vt gn prag ww we ~  ingredients : {)noodle: wheat flour, modified starch(potato, tapioca), palm oil, potato starch, wheat gluten, salt, yeast extract, acidity regulator(potassium carbonate, sodium  polyphosphate), riboflavin  2}powder soup: salt, sugar, soy sauce powder(soy bean, wheat, salt), garlic powder, spicesired pepper, garlic, onion, green onion, ginger), monosoidium glutamate, glucose, hydrolyzed vegetable protein(soy, wheat, corn), chilli extract, yeast  extract powder, black pepper, red pepper, kelp extract powder, disodium  inos dium guanylate, dextrin, malic acid sed vegetable mix: chinese cabbage, textured vegetable protein(soy,  wheat, carrot, green onion, mushroom, red pepper  eee ee ee eee ee nam feli ee eee"
                })
            );

            // lightlife_smart-bacon.jpg
            pcpExpected.Add(new KeyValuePair<string, PipelineResultModel>(
                "lightlife_smart-bacon.jpg",
                new PipelineResultModel()
                {
                    isSuccessful = true,
                    result = "vital wheat gluten, soybean oil, so¥ protein.   oo) 2.  ingredients: water, soy protein, isolate, concentrate, textured wheat gluten, less than 2% of: salt, sugar, carrageenan, natural. ” flavor, autolyzed yeast ext ract, natural smoke  ~ flavor, spices, fermented rice flour, oleoresin   paprika (color), potassium chloride."
                })
            );

            // omorovicza_thermal-cleansing-balm.png
            pcpExpected.Add(new KeyValuePair<string, PipelineResultModel>(
                "omorovicza_thermal-cleansing-balm.png",
                new PipelineResultModel()
                {
                    isSuccessful = true,
                    result = "et) t-mobile wi-fi & 1:05 pm @ 7 100% {)  k< q ingredients o ss  -hungarian moor mud: cleanses and detoxifies the skin. -sweet almond oil: replenishes the skin and leaves it soft and silky.  -orange blossom oil: lifts the spirits and the senses. -hydro mineral transference™: leaves skin firmer, more supple, and younger-looking.  cetearyl ethylhexanoate, prunus amygdalus dulcis (sweet almond) oil, glyceryl stearate, stearyl heptanoate, squalane, cera alba (beeswax), polysorbate 20, cetearyl alcohol, phenoxyethanol, benzyl! alcohol, limonene, fragrance, saccharomyces (hungarian thermal water) ferment extract, tocopherol, ethylhexylglycerin, hungarian thermal water, linalool, malpighia punicifolia (acerola) fruit extract, phospholipids.  a f& © ee  home shop claire stores inspire"
                })
            );

            // too-faced_better-than-sex-mascara.jpg
            pcpExpected.Add(new KeyValuePair<string, PipelineResultModel>(
                "too-faced_better-than-sex-mascara.jpg",
                new PipelineResultModel()
                {
                    isSuccessful = true,
                    result = "ingredients: aqua/water/eau, synthetic beeswax, paraffin, glyceryl  stearate, acacia senegal gum, butylene glycol, oryza sativa (rice) bran wax/oryza sativa  bran cera, stearic acid, palmitic acid, polybutene, vp/eicosene copolymer, copernicia cerifera (carnauba) wax/copernicia cerifera cera/cire de carnauba, aminomethyl propanol, glycerin, pvp, ethylhexylglycerin,  hydroxyethylcellulose, disodium  edta, polyester-11, cellulose,  trimethylpentanediol/adipic acid/glycerin crosspolymer, propylene glycol, disodium phosphate, polysorbate 60, acacia seyal gum extract, sodium phosphate, acetyl  hexapeptide-1, dextran, phenoxyethanol, potassium sorbate, iron oxides  (cl 77499), ultramarines (cl 77007), black 2 (cl 77266).  ] i  macxapa - rimel » ripsmetuss - rasenka - mascara para pestanas - rimel - blakstieny tusas « skropstu tusa - mascara » maskara  ¢ ouha cnupasia + tusz do rzes « )sulo  dist. by/distr. par too faced cosmetics, llc irvine, ca 92614 usa biorius, 7170 manage, belgium made in italy fabriqué en italie © 2018 too faced cosmetics, llc all rights reserved tous droits reserves"
                })
            );

            // glam-glow_glow-lace-sheet-mask.jpg
            pcpExpected.Add(new KeyValuePair<string, PipelineResultModel>(
                "glam-glow_glow-lace-sheet-mask.jpg",
                new PipelineResultModel()
                {
                    isSuccessful = true,
                    result = "ingredients: water\\aqua\\eau * butylene glycol » methylpropanediol + 1,2-hexanediol * sodium hyaluronate + camellia sinensis (green tea) leaf extract * caffeine « coffea arabica (coffee) seed extract + glycerin * trehalose + panthenol + fees et ar tasty mien acne hceaci mo) zant ee ae de gal co rol rae ee glycereth-26 « epigallocatechin gallate * tocophersolan * xanthan gum + decyl glucoside + trideceth-6 - carbomer - poloxamer 235 + poloxamer 338 * dipropylene glycol + pipe en ayy i etal beeeimap lb nonstop - allele ua es {hon dll tat varin tula ek og 2 na a ce cast nets                     cinnamal + disodium edta « phenoxyethanol <iln46462>"
                })
            );
            #endregion

            #region Unsuccessful Ingredient List Extractions
            // kate-sommerville_uncomplikated-spf-50.jpg
            pcpExpected.Add(new KeyValuePair<string, PipelineResultModel>(
                "kate-sommerville_uncomplikated-spf-50.jpg",
                new PipelineResultModel()
                {
                    isSuccessful = false,
                    result = ""
                })
            );

            // moroccanoil_blonde-perfecting-purple-shampoo.jpg
            pcpExpected.Add(new KeyValuePair<string, PipelineResultModel>(
                "moroccanoil_blonde-perfecting-purple-shampoo.jpg",
                new PipelineResultModel()
                {
                    isSuccessful = false,
                    result = ""
                })
            );
            #endregion

            #endregion

            #region User Validated Ingredient Lists
            // User Validated Lists
            uvLists = new List<KeyValuePair<string, string>>();

            #region Successful Ingredient List Extractions
            // belvita_vanilla-cookie.jpg
            uvLists.Add(new KeyValuePair<string, string>(
                "belvita_vanilla-cookie.jpg",
                "whole grain wheat flour, enriched flour [wheat flour, niacin, reduced iron, thiamin mononitrate (vitamin b1), riboflavin (vitamin b2), folic acid}, sugar, canola oil, whole grain rolled oats, whole grain rye flour, baking soda, disodium pyrophosphate, salt, soy lecithin, datem, natural flavor, ferric orthophosphate (iron), niacinamide,  pyridoxine hydrochloride (vitamin b6), riboflavin (vitamin b2),  thiamin mononitrate (vitamin b1)."
                )
            );

            // jin_ramen.jpg
            uvLists.Add(new KeyValuePair<string, string>(
                "jin_ramen.jpg",
                "wheat flour, modified starch(potato, tapioca), palm oil, potato starch, wheat gluten, salt, yeast extract, acidity regulator(potassium carbonate, sodium  polyphosphate), riboflavin, salt, sugar, soy sauce powder(soy bean, wheat, salt), garlic powder, spices (red pepper, garlic, onion, green onion, ginger), monosoidium glutamate, glucose, hydrolyzed vegetable protein(soy, wheat, corn), chilli extract, yeast  extract powder, black pepper, red pepper, kelp extract powder, disodium  inosinate, disodium guanylate, dextrin, malic acid seed, chinese cabbage, textured vegetable protein(soy,  wheat, carrot, green onion, mushroom, red pepper "
                )
            );

            // lightlife_smart-bacon.jpg
            uvLists.Add(new KeyValuePair<string, string>(
                "lightlife_smart-bacon.jpg",
                "vital wheat gluten, soybean oil, soy protein, water, soy protein, isolate, concentrate, textured wheat gluten, salt, sugar, carrageenan, natural flavor, autolyzed yeast extract, natural smoke flavor, spices, fermented rice flour, oleoresin paprika(color), potassium chloride."
                )
            );

            // omorovicza_thermal-cleansing-balm.png
            uvLists.Add(new KeyValuePair<string, string>(
                "omorovicza_thermal-cleansing-balm.png",
                "cetearyl ethylhexanoate, prunus amygdalus dulcis (sweet almond) oil, glyceryl stearate, stearyl heptanoate, squalane, cera alba (beeswax), polysorbate 20, cetearyl alcohol, phenoxyethanol, benzyl alcohol, limonene, fragrance, saccharomyces (hungarian thermal water) ferment extract, tocopherol, ethylhexylglycerin, hungarian thermal water, linalool, malpighia punicifolia (acerola) fruit extract, phospholipids"
                )
            );

            // too-faced_better-than-sex-mascara.jpg
            uvLists.Add(new KeyValuePair<string, string>(
                "too-faced_better-than-sex-mascara.jpg",
                "aqua/water/eau, synthetic beeswax, paraffin, glyceryl  stearate, acacia senegal gum, butylene glycol, oryza sativa (rice) bran wax/oryza sativa  bran cera, stearic acid, palmitic acid, polybutene, vp/eicosene copolymer, copernicia cerifera (carnauba) wax/copernicia cerifera cera/cire de carnauba, aminomethyl propanol, glycerin, pvp, ethylhexylglycerin,  hydroxyethylcellulose, disodium  edta, polyester-11, cellulose,  trimethylpentanediol/adipic acid/glycerin crosspolymer, propylene glycol, disodium phosphate, polysorbate 60, acacia seyal gum extract, sodium phosphate, acetyl  hexapeptide-1, dextran, phenoxyethanol, potassium sorbate, iron oxides  (cl 77499), ultramarines (cl 77007), black 2 (cl 77266)"
                )
            );
            #endregion

            #endregion

            #region SecondaryCleanPipeline
            // SecendaryCleanPipeline list
            scpExpected = new List<KeyValuePair<string, PipelineResultModel>>();

            #region Successful Ingredient List Extractions
            // belvita_vanilla-cookie.jpg
            scpExpected.Add(new KeyValuePair<string, PipelineResultModel>(
                "belvita_vanilla-cookie.jpg",
                new PipelineResultModel()
                {
                    isSuccessful = true,
                    result = "whole grain wheat flour, enriched flour [wheat flour, niacin, reduced iron, thiamin mononitrate (vitamin b1), riboflavin (vitamin b2), folic acid}, sugar, canola oil, whole grain rolled oats, whole grain rye flour, baking soda, disodium pyrophosphate, salt, soy lecithin, datem, natural flavor, ferric orthophosphate (iron), niacinamide,  pyridoxine hydrochloride (vitamin b6), riboflavin (vitamin b2),  thiamin mononitrate (vitamin b1)."
                })
            );

            // jin_ramen.jpg
            scpExpected.Add(new KeyValuePair<string, PipelineResultModel>(
                "jin_ramen.jpg",
                new PipelineResultModel()
                {
                    isSuccessful = true,
                    result = "wheat flour, modified starch(potato, tapioca), palm oil, potato starch, wheat gluten, salt, yeast extract, acidity regulator(potassium carbonate, sodium  polyphosphate), riboflavin, salt, sugar, soy sauce powder(soy bean, wheat, salt), garlic powder, spices (red pepper, garlic, onion, green onion, ginger), monosoidium glutamate, glucose, hydrolyzed vegetable protein(soy, wheat, corn), chilli extract, yeast  extract powder, black pepper, red pepper, kelp extract powder, disodium  inosinate, disodium guanylate, dextrin, malic acid seed, chinese cabbage, textured vegetable protein(soy,  wheat, carrot, green onion, mushroom, red pepper "
                })
            );

            // lightlife_smart-bacon.jpg
            scpExpected.Add(new KeyValuePair<string, PipelineResultModel>(
                "lightlife_smart-bacon.jpg",
                new PipelineResultModel()
                {
                    isSuccessful = true,
                    result = "vital wheat gluten, soybean oil, soy protein, water, soy protein, isolate, concentrate, textured wheat gluten, salt, sugar, carrageenan, natural flavor, autolyzed yeast extract, natural smoke flavor, spices, fermented rice flour, oleoresin paprika(color), potassium chloride."
                })
            );

            // omorovicza_thermal-cleansing-balm.png
            scpExpected.Add(new KeyValuePair<string, PipelineResultModel>(
                "omorovicza_thermal-cleansing-balm.png",
                new PipelineResultModel()
                {
                    isSuccessful = true,
                    result = "cetearyl ethylhexanoate, prunus amygdalus dulcis (sweet almond) oil, glyceryl stearate, stearyl heptanoate, squalane, cera alba (beeswax), polysorbate 20, cetearyl alcohol, phenoxyethanol, benzyl! alcohol, limonene, fragrance, saccharomyces (hungarian thermal water) ferment extract, tocopherol, ethylhexylglycerin, hungarian thermal water, linalool, malpighia punicifolia (acerola) fruit extract, phospholipids"
                })
            );

            // too-faced_better-than-sex-mascara.jpg
            scpExpected.Add(new KeyValuePair<string, PipelineResultModel>(
                "too-faced_better-than-sex-mascara.jpg",
                new PipelineResultModel()
                {
                    isSuccessful = true,
                    result = "aqua/water/eau, synthetic beeswax, paraffin, glyceryl  stearate, acacia senegal gum, butylene glycol, oryza sativa (rice) bran wax/oryza sativa  bran cera, stearic acid, palmitic acid, polybutene, vp/eicosene copolymer, copernicia cerifera (carnauba) wax/copernicia cerifera cera/cire de carnauba, aminomethyl propanol, glycerin, pvp, ethylhexylglycerin,  hydroxyethylcellulose, disodium  edta, polyester-11, cellulose,  trimethylpentanediol/adipic acid/glycerin crosspolymer, propylene glycol, disodium phosphate, polysorbate 60, acacia seyal gum extract, sodium phosphate, acetyl  hexapeptide-1, dextran, phenoxyethanol, potassium sorbate, iron oxides  (cl 77499), ultramarines (cl 77007), black 2 (cl 77266)"
                })
            );
            #endregion

            #endregion
        }

        public List<KeyValuePair<string, List<string>>> GetFindSubingredientsExpected()
        {
            List<KeyValuePair<string, List<string>>> ingredientLists = new List<KeyValuePair<string, List<string>>>();

            // belvita_vanilla-cookie.jpg
            ingredientLists.Add(new KeyValuePair<string, List<string>>(
                "belvita_vanilla-cookie.jpg",
                new List<string>()
                {
                    "enriched flour [wheat flour, niacin, reduced iron, thiamin mononitrate (vitamin b1), riboflavin (vitamin b2), folic acid}"
                }
            ));

            // jin_ramen.jpg
            ingredientLists.Add(new KeyValuePair<string, List<string>>(
                "jin_ramen.jpg",
                new List<string>()
            ));

            // lightlife_smart-bacon.jpg
            ingredientLists.Add(new KeyValuePair<string, List<string>>(
                "lightlife_smart-bacon.jpg",
                new List<string>()
            ));

            // omorovicza_thermal-cleansing-balm.png
            ingredientLists.Add(new KeyValuePair<string, List<string>>(
                "omorovicza_thermal-cleansing-balm.png",
                new List<string>()
            ));

            // too-faced_better-than-sex-mascara.jpg
            ingredientLists.Add(new KeyValuePair<string, List<string>>(
                "too-faced_better-than-sex-mascara.jpg",
                new List<string>()
            ));

            return ingredientLists;
        }
    }
}
