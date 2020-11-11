
using Is_This_Vegan__Net_.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Is_This_Vegan_Test.Testing_Helpers
{
    public class IngredientListHelperCollection
    {
        public class Execute : TestCollection
        {
            public Execute()
            {
                IngredientLists = new List<TestingModel>();

                // belvita_vanilla-cookie.jpg
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "belvita_vanilla-cookie.jpg",
                    Input = " \n\nwpe erera paresis\n\nINGREDIENTS: WHOLE GRAIN WHEAT FLOUR, ENRICHED FLOUR\n[WHEAT FLOUR, NIACIN, REDUCED IRON, THIAMIN MONONITRATE\n(VITAMIN B1), RIBOFLAVIN (VITAMIN B2), FOLIC ACID}, SUGAR, CANOLA\nOIL, WHOLE GRAIN ROLLED OATS, WHOLE GRAIN RYE FLOUR, BAKING\nSODA, DISODIUM PYROPHOSPHATE, SALT, SOY LECITHIN, DATEM,\nNATURAL FLAVOR, FERRIC ORTHOPHOSPHATE (IRON), NIACINAMIDE,\n__ PYRIDOXINE HYDROCHLORIDE (VITAMIN B6), RIBOFLAVIN (VITAMIN B2),\n| THIAMIN MONONITRATE (VITAMIN B1).\n\n   \n",
                    Expected = new PipelineResultModel()
                    {
                        isSuccessful = true,
                        result = "wpe erera paresis  ingredients: whole grain wheat flour, enriched flour [wheat flour, niacin, reduced iron, thiamin mononitrate (vitamin b1), riboflavin (vitamin b2), folic acid}, sugar, canola oil, whole grain rolled oats, whole grain rye flour, baking soda, disodium pyrophosphate, salt, soy lecithin, datem, natural flavor, ferric orthophosphate (iron), niacinamide,  pyridoxine hydrochloride (vitamin b6), riboflavin (vitamin b2),  thiamin mononitrate (vitamin b1)."
                    }
                });

                // glam-glow_glow-lace-sheet-mask.jpg
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "glam-glow_glow-lace-sheet-mask.jpg",
                    Input = "   \n\n  \n \n\nINGREDIENTS: WATER\\AQUA\\EAU * BUTYLENE GLYCOL » METHYLPROPANEDIOL + 1,2-HEXANEDIOL * SODIUM HYALURONATE + CAMELLIA\nSINENSIS (GREEN TEA) LEAF EXTRACT * CAFFEINE « COFFEA ARABICA (COFFEE) SEED EXTRACT + GLYCERIN * TREHALOSE + PANTHENOL +\nFees eT aR tasty Mien acne hceaci MO) Zant ee ae de gal Co rol Rae ee\nGLYCERETH-26 « EPIGALLOCATECHIN GALLATE * TOCOPHERSOLAN * XANTHAN GUM + DECYL GLUCOSIDE + TRIDECETH-6 - CARBOMER -\nPOLOXAMER 235 + POLOXAMER 338 * DIPROPYLENE GLYCOL + pipe en ayy i etal Beeeimap lb nonstop -\nallele ua es {hon dll tat VARIN TULA ek og 2 NA a ce CAST Nets\n\n       \n   \n   \n \n\nCINNAMAL + DISODIUM EDTA « PHENOXYETHANOL <ILN46462>\n\n    \n     \n",
                    Expected = new PipelineResultModel()
                    {
                        isSuccessful = true,
                        result = "ingredients: water\\aqua\\eau * butylene glycol » methylpropanediol + 1,2-hexanediol * sodium hyaluronate + camellia sinensis (green tea) leaf extract * caffeine « coffea arabica (coffee) seed extract + glycerin * trehalose + panthenol + fees et ar tasty mien acne hceaci mo) zant ee ae de gal co rol rae ee glycereth-26 « epigallocatechin gallate * tocophersolan * xanthan gum + decyl glucoside + trideceth-6 - carbomer - poloxamer 235 + poloxamer 338 * dipropylene glycol + pipe en ayy i etal beeeimap lb nonstop - allele ua es {hon dll tat varin tula ek og 2 na a ce cast nets                     cinnamal + disodium edta « phenoxyethanol <iln46462>"
                    }
                });

                // jin_ramen.jpg
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "jin_ramen.jpg",
                    Input = "Vt GN PRAG ww we ~\n\nINGREDIENTS :\n{)NOODLE: WHEAT FLOUR, MODIFIED STARCH(POTATO, TAPIOCA), PALM OIL, POTATO STARCH,\nWHEAT GLUTEN, SALT, YEAST EXTRACT, ACIDITY REGULATOR(POTASSIUM CARBONATE, SODIUM\n\nPOLYPHOSPHATE), RIBOFLAVIN\n\n2}POWDER SOUP: SALT, SUGAR, SOY SAUCE POWDER(SOY BEAN, WHEAT, SALT), GARLIC POWDER,\nSPICESIRED PEPPER, GARLIC, ONION, GREEN ONION, GINGER), MONOSOIDIUM GLUTAMATE,\nGLUCOSE, HYDROLYZED VEGETABLE PROTEIN(SOY, WHEAT, CORN), CHILLI EXTRACT, YEAST\n\nEXTRACT POWDER, BLACK PEPPER, RED PEPPER, KELP EXTRACT POWDER, DISODIUM\n\nINOS| DIUM GUANYLATE, DEXTRIN, MALIC ACID\nSED VEGETABLE MIX: CHINESE CABBAGE, TEXTURED VEGETABLE PROTEIN(SOY,\n\nWHEAT, CARROT, GREEN ONION, MUSHROOM, RED PEPPER\n\neee ee ee eee ee nam FeLi\nee eee\n",
                    Expected = new PipelineResultModel()
                    {
                        isSuccessful = true,
                        result = "vt gn prag ww we ~  ingredients : {)noodle: wheat flour, modified starch(potato, tapioca), palm oil, potato starch, wheat gluten, salt, yeast extract, acidity regulator(potassium carbonate, sodium  polyphosphate), riboflavin  2}powder soup: salt, sugar, soy sauce powder(soy bean, wheat, salt), garlic powder, spicesired pepper, garlic, onion, green onion, ginger), monosoidium glutamate, glucose, hydrolyzed vegetable protein(soy, wheat, corn), chilli extract, yeast  extract powder, black pepper, red pepper, kelp extract powder, disodium  inos dium guanylate, dextrin, malic acid sed vegetable mix: chinese cabbage, textured vegetable protein(soy,  wheat, carrot, green onion, mushroom, red pepper  eee ee ee eee ee nam feli ee eee"
                    }
                });

                // kate-sommerville_uncomplikated-spf-50.jpg
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "kate-sommerville_uncomplikated-spf-50.jpg",
                    Input = "",
                    Expected = new PipelineResultModel()
                    {
                        isSuccessful = false,
                        result = "Ingredient list must be longer than 1 character and text extraction confidence must be over 70%."
                    }
                });

                // kettle_sea-salt-and-vinegar-potato-chips.png
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "kettle_sea-salt-and-vinegar-potato-chips.png",
                    Input = "Ingredients\n\nIngredients: Potatoes, Safflower and/or Sunflower and/or\nCanola Oil, Vinegar Powder (Maltodextrin, White Distilled\nVinegar), Sea Salt, Maltodextrin, Citric Acid\n\nAllergen Info\n",
                    Expected = new PipelineResultModel()
                    {
                        isSuccessful = true,
                        result = "ingredients  ingredients: potatoes, safflower and/or sunflower and/or canola oil, vinegar powder (maltodextrin, white distilled vinegar), sea salt, maltodextrin, citric acid  allergen info"
                    }
                }); 

                // kroger_classic-trail-mix-with-m&ms-cookie.png
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "kroger_classic-trail-mix-with-m&ms-cookie.png",
                    Input = "Ingredients\n\nPeanuts, Raisins (Raisins, Sunflower Oil), Milk Chocolate\nCandies (Milk Chocolate [Sugar, Chocolate, Skim Milk, Cocoa\nButter, Lactose, Milk Fat, Soy Lecithin, Salt, Artificial Flavors],\nSugar, Cornstarch, Contains Less Than 1% Of: Corn Syrup,\nDextrin, Coloring [Includes Blue 1 Lake, Yellow 6, Red 40,\nYellow 5, Blue 1, Red 40 Lake, Blue 2 Lake, Yellow 6 Lake,\nYellow 5 Lake, Blue 2], Gum Acacia), Almonds, Cashews,\nVegetable Oil (Peanut, cottonseed, soybean, and/or sunflower\noil), Sea Salt CONTAINS: PEANUTS, ALMONDS, CASHEWS,\n",
                    Expected = new PipelineResultModel()
                    {
                        isSuccessful = true,
                        result = "ingredients  peanuts, raisins (raisins, sunflower oil), milk chocolate candies (milk chocolate [sugar, chocolate, skim milk, cocoa butter, lactose, milk fat, soy lecithin, salt, artificial flavors], sugar, cornstarch, contains less than 1% of: corn syrup, dextrin, coloring [includes blue 1 lake, yellow 6, red 40, yellow 5, blue 1, red 40 lake, blue 2 lake, yellow 6 lake, yellow 5 lake, blue 2], gum acacia), almonds, cashews, vegetable oil (peanut, cottonseed, soybean, and/or sunflower oil), sea salt contains: peanuts, almonds, cashews,"
                    }
                });

                // kroger_kaleidos-original-chocolate-sandwich-cookies.png
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "kroger_kaleidos-original-chocolate-sandwich-cookies.png",
                    Input = "Ingredients\n\nIngredients: Sugar, Enriched Bleached Wheat Flour (Flour,\nNiacin, Iron, Thiamin Mononitrate, Riboflavin, Folic Acid),\nVegetable Oil (Contains One or More of the Following: Palm,\nSoybean [With TBHQ For Freshness]), Cocoa (Processed With\nAlkali), Contains 2% or Less of: High Fructose Corn Syrup,\nCorn Starch, Leavening (Baking Soda, Calcium Phosphate),\nSalt, Soy Lecithin, Dextrose, Cocoa Powder, Natural and\nArtificial Flavor, Caramel Color, Gum Acacia\n",
                    Expected = new PipelineResultModel()
                    {
                        isSuccessful = true,
                        result = "ingredients  ingredients: sugar, enriched bleached wheat flour (flour, niacin, iron, thiamin mononitrate, riboflavin, folic acid), vegetable oil (contains one or more of the following: palm, soybean [with tbhq for freshness]), cocoa (processed with alkali), contains 2% or less of: high fructose corn syrup, corn starch, leavening (baking soda, calcium phosphate), salt, soy lecithin, dextrose, cocoa powder, natural and artificial flavor, caramel color, gum acacia"
                    }
                });

                // lightlife_smart-bacon.jpg
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "lightlife_smart-bacon.jpg",
                    Input = "__ VITAL WHEAT GLUTEN, SOYBEAN Oil, SO¥ PROTEIN. |\n\nOo) 2.\n\nINGREDIENTS: WATER, SOY PROTEIN, ISOLATE,\nCONCENTRATE, TEXTURED WHEAT GLUTEN, LESS\nTHAN 2% OF: SALT, SUGAR, CARRAGEENAN, NATURAL.\n” FLAVOR, AUTOLYZED YEAST EXT RACT, NATURAL SMOKE\n\n_~ FLAVOR, SPICES, FERMENTED RICE FLOUR, OLEORESIN |\n\nPAPRIKA (COLOR), POTASSIUM CHLORIDE.\n",
                    Expected = new PipelineResultModel()
                    {
                        isSuccessful = true,
                        result = "vital wheat gluten, soybean oil, so¥ protein.   oo) 2.  ingredients: water, soy protein, isolate, concentrate, textured wheat gluten, less than 2% of: salt, sugar, carrageenan, natural. ” flavor, autolyzed yeast ext ract, natural smoke  ~ flavor, spices, fermented rice flour, oleoresin   paprika (color), potassium chloride."
                    }
                });

                // moroccanoil_blonde-perfecting-purple-shampoo.jpg
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "moroccanoil_blonde-perfecting-purple-shampoo.jpg",
                    Input = " \n",
                    Expected = new PipelineResultModel()
                    {
                        isSuccessful = false,
                        result = "Ingredient list must be longer than 1 character and text extraction confidence must be over 70%."
                    }

                });

                // nutella-and-go_hazelnut-spread-and-breadsticks.png
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "nutella-and-go_hazelnut-spread-and-breadsticks.png",
                    Input = "Ingredients\n\nIngredients: Nutella: Sugar, Palm Oil, Hazelnuts, Skim Milk,\nCocoa, Soy Lecithin as Emulsifier, Vanillin: An Artificial Flavor.\nBreadsticks: Enriched Flour (Wheat Flour, Niacin, Iron,\nThiamine Mononitrate, Riboflavin, Folic Acid), Palm Oil, Salt,\nMalt Extract, Baker's Yeast\n",
                    Expected = new PipelineResultModel()
                    {
                        isSuccessful = true,
                        result = "ingredients  ingredients: nutella: sugar, palm oil, hazelnuts, skim milk, cocoa, soy lecithin as emulsifier, vanillin: an artificial flavor. breadsticks: enriched flour (wheat flour, niacin, iron, thiamine mononitrate, riboflavin, folic acid), palm oil, salt, malt extract, baker's yeast"
                    }
                });

                // omorovicza_thermal-cleansing-balm.png
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "omorovicza_thermal-cleansing-balm.png",
                    Input = "et) T-Mobile Wi-Fi & 1:05 PM @ 7 100% {)\n\nK< Q INGREDIENTS O Ss\n\n-Hungarian Moor Mud: Cleanses and detoxifies the skin.\n-Sweet Almond Oil: Replenishes the skin and leaves it soft\nand silky.\n\n-Orange Blossom Oil: Lifts the spirits and the senses.\n-Hydro Mineral Transference™: Leaves skin firmer, more\nsupple, and younger-looking.\n\nCetearyl Ethylhexanoate, Prunus Amygdalus Dulcis (Sweet\nAlmond) Oil, Glyceryl Stearate, Stearyl Heptanoate,\nSqualane, Cera Alba (Beeswax), Polysorbate 20, Cetearyl\nAlcohol, Phenoxyethanol, Benzyl! Alcohol, Limonene,\nFragrance, Saccharomyces (Hungarian Thermal Water)\nFerment Extract, Tocopherol, Ethylhexylglycerin,\nHungarian Thermal Water, Linalool, Malpighia Punicifolia\n(Acerola) Fruit Extract, Phospholipids.\n\nA f& © ee\n\nHome Shop Claire Stores Inspire\n\n \n\n \n\n \n\n \n\n \n",
                    Expected = new PipelineResultModel()
                    {
                        isSuccessful = true,
                        result = "et) t-mobile wi-fi & 1:05 pm @ 7 100% {)  k< q ingredients o ss  -hungarian moor mud: cleanses and detoxifies the skin. -sweet almond oil: replenishes the skin and leaves it soft and silky.  -orange blossom oil: lifts the spirits and the senses. -hydro mineral transference™: leaves skin firmer, more supple, and younger-looking.  cetearyl ethylhexanoate, prunus amygdalus dulcis (sweet almond) oil, glyceryl stearate, stearyl heptanoate, squalane, cera alba (beeswax), polysorbate 20, cetearyl alcohol, phenoxyethanol, benzyl! alcohol, limonene, fragrance, saccharomyces (hungarian thermal water) ferment extract, tocopherol, ethylhexylglycerin, hungarian thermal water, linalool, malpighia punicifolia (acerola) fruit extract, phospholipids.  a f& © ee  home shop claire stores inspire"
                    }
                });

                // simple-truth-organic_wavy-cheddar-sour-cream-potato-chips.png
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "simple-truth-organic_wavy-cheddar-sour-cream-potato-chips.png",
                    Input = "Ingredients\n\nIngredients: Organic Potatoes, Organic Oil Blend (Sunflower\nOil, Safflower Oil and/or Red Palm Fruit Oil), Cheese Powder\n(Organic Cheddar Cheese [Organic Milk, Cultures, Salt,\nEnzymes], Disodium Phosphate), Organic Maltodextrin, Sea\nSalt, Organic Sour Cream Powder (Organic Sour Cream\n[Organic Cream, Cultures, Lactic Acid], Organic Nonfat Milk\nSolids, Citric Acid), Organic Buttermilk, Organic Whey, Organic\nOnion Powder, Natural Flavor, Organic Butter Powder (Organic\nButter [Organic Cream, Salt], Organic Nonfat Dry Milk), Yeast\nExtract, Organic Annatto Extract, Lactic Acid, Citric Acid,\nOrganic Garlic Powder, Organic Skim Milk\n",
                    Expected = new PipelineResultModel()
                    {
                        isSuccessful = true,
                        result = "ingredients  ingredients: organic potatoes, organic oil blend (sunflower oil, safflower oil and/or red palm fruit oil), cheese powder (organic cheddar cheese [organic milk, cultures, salt, enzymes], disodium phosphate), organic maltodextrin, sea salt, organic sour cream powder (organic sour cream [organic cream, cultures, lactic acid], organic nonfat milk solids, citric acid), organic buttermilk, organic whey, organic onion powder, natural flavor, organic butter powder (organic butter [organic cream, salt], organic nonfat dry milk), yeast extract, organic annatto extract, lactic acid, citric acid, organic garlic powder, organic skim milk"
                    }
                });

                // too-faced_better-than-sex-mascara.jpg
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "too-faced_better-than-sex-mascara.jpg",
                    Input = "INGREDIENTS:\nAqua/Water/Eau, Synthetic\nBeeswax, Paraffin, Glyceryl\n\nStearate, Acacia Senegal Gum,\nButylene Glycol, Oryza Sativa\n(Rice) Bran Wax/Oryza Sativa\n\nBran Cera, Stearic Acid,\nPalmitic Acid, Polybutene,\nVP/Eicosene Copolymer,\nCopernicia Cerifera (Carnauba)\nWax/Copernicia Cerifera\nCera/Cire De Carnauba,\nAminomethyl Propanol, Glycerin,\nPVP, Ethylhexylglycerin,\n\nHydroxyethylcellulose, Disodium\n\nEDTA, Polyester-11, Cellulose,\n\nTrimethylpentanediol/Adipic\nAcid/Glycerin Crosspolymer,\nPropylene Glycol, Disodium\nPhosphate, Polysorbate 60,\nAcacia Seyal Gum Extract,\nSodium Phosphate, Acetyl\n\nHexapeptide-1, Dextran,\nPhenoxyethanol, Potassium\nSorbate, Iron Oxides\n\n(Cl 77499), Ultramarines\n(Cl 77007), Black 2 (Cl 77266).\n\n]\ni\n\nMacxapa - Rimel\n» Ripsmetuss - Rasenka\n- Mascara para pestanas\n- Rimel - Blakstieny tusas\n« Skropstu tusa\n- Mascara » Maskara\n\n¢ OuHa cnupasia\n+ Tusz do rzes « |)Sulo\n\nDist. by/Distr. par\nToo Faced Cosmetics, LLC\nIrvine, CA 92614 USA\nBiorius, 7170\nManage, Belgium\nMade in Italy\nFabriqué en Italie\n© 2018 Too Faced\nCosmetics, LLC\nAll Rights Reserved\nTous droits reserves\n\n \n",
                    Expected = new PipelineResultModel()
                    {
                        isSuccessful = true,
                        result = "ingredients: aqua/water/eau, synthetic beeswax, paraffin, glyceryl  stearate, acacia senegal gum, butylene glycol, oryza sativa (rice) bran wax/oryza sativa  bran cera, stearic acid, palmitic acid, polybutene, vp/eicosene copolymer, copernicia cerifera (carnauba) wax/copernicia cerifera cera/cire de carnauba, aminomethyl propanol, glycerin, pvp, ethylhexylglycerin,  hydroxyethylcellulose, disodium  edta, polyester-11, cellulose,  trimethylpentanediol/adipic acid/glycerin crosspolymer, propylene glycol, disodium phosphate, polysorbate 60, acacia seyal gum extract, sodium phosphate, acetyl  hexapeptide-1, dextran, phenoxyethanol, potassium sorbate, iron oxides  (cl 77499), ultramarines (cl 77007), black 2 (cl 77266).  ] i  macxapa - rimel » ripsmetuss - rasenka - mascara para pestanas - rimel - blakstieny tusas « skropstu tusa - mascara » maskara  ¢ ouha cnupasia + tusz do rzes « )sulo  dist. by/distr. par too faced cosmetics, llc irvine, ca 92614 usa biorius, 7170 manage, belgium made in italy fabriqué en italie © 2018 too faced cosmetics, llc all rights reserved tous droits reserves"
                    }
                });
            }
        }
    }
}
