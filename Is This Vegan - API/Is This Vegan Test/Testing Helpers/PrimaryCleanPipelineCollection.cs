using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Is_This_Vegan_Test.Testing_Helpers
{
    public class PrimaryCleanPipelineCollection
    {
        public class Remove : TestCollection
        {
            public Remove()
            {
                IngredientLists = new List<TestingModel>();

                // belvita_vanilla-cookie.jpg
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "belvita_vanilla-cookie.jpg",
                    Input = " \n\nwpe erera paresis\n\nINGREDIENTS: WHOLE GRAIN WHEAT FLOUR, ENRICHED FLOUR\n[WHEAT FLOUR, NIACIN, REDUCED IRON, THIAMIN MONONITRATE\n(VITAMIN B1), RIBOFLAVIN (VITAMIN B2), FOLIC ACID}, SUGAR, CANOLA\nOIL, WHOLE GRAIN ROLLED OATS, WHOLE GRAIN RYE FLOUR, BAKING\nSODA, DISODIUM PYROPHOSPHATE, SALT, SOY LECITHIN, DATEM,\nNATURAL FLAVOR, FERRIC ORTHOPHOSPHATE (IRON), NIACINAMIDE,\n__ PYRIDOXINE HYDROCHLORIDE (VITAMIN B6), RIBOFLAVIN (VITAMIN B2),\n| THIAMIN MONONITRATE (VITAMIN B1).\n\n   \n",
                    Expected = "wpe erera paresis  INGREDIENTS: WHOLE GRAIN WHEAT FLOUR, ENRICHED FLOUR [WHEAT FLOUR, NIACIN, REDUCED IRON, THIAMIN MONONITRATE (VITAMIN B1), RIBOFLAVIN (VITAMIN B2), FOLIC ACID}, SUGAR, CANOLA OIL, WHOLE GRAIN ROLLED OATS, WHOLE GRAIN RYE FLOUR, BAKING SODA, DISODIUM PYROPHOSPHATE, SALT, SOY LECITHIN, DATEM, NATURAL FLAVOR, FERRIC ORTHOPHOSPHATE (IRON), NIACINAMIDE,  PYRIDOXINE HYDROCHLORIDE (VITAMIN B6), RIBOFLAVIN (VITAMIN B2),  THIAMIN MONONITRATE (VITAMIN B1)."
                });

                // glam-glow_glow-lace-sheet-mask.jpg
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "glam-glow_glow-lace-sheet-mask.jpg",
                    Input = "   \n\n  \n \n\nINGREDIENTS: WATER\\AQUA\\EAU * BUTYLENE GLYCOL » METHYLPROPANEDIOL + 1,2-HEXANEDIOL * SODIUM HYALURONATE + CAMELLIA\nSINENSIS (GREEN TEA) LEAF EXTRACT * CAFFEINE « COFFEA ARABICA (COFFEE) SEED EXTRACT + GLYCERIN * TREHALOSE + PANTHENOL +\nFees eT aR tasty Mien acne hceaci MO) Zant ee ae de gal Co rol Rae ee\nGLYCERETH-26 « EPIGALLOCATECHIN GALLATE * TOCOPHERSOLAN * XANTHAN GUM + DECYL GLUCOSIDE + TRIDECETH-6 - CARBOMER -\nPOLOXAMER 235 + POLOXAMER 338 * DIPROPYLENE GLYCOL + pipe en ayy i etal Beeeimap lb nonstop -\nallele ua es {hon dll tat VARIN TULA ek og 2 NA a ce CAST Nets\n\n       \n   \n   \n \n\nCINNAMAL + DISODIUM EDTA « PHENOXYETHANOL <ILN46462>\n\n    \n     \n",
                    Expected = "INGREDIENTS: WATER\\AQUA\\EAU * BUTYLENE GLYCOL » METHYLPROPANEDIOL + 1,2-HEXANEDIOL * SODIUM HYALURONATE + CAMELLIA SINENSIS (GREEN TEA) LEAF EXTRACT * CAFFEINE « COFFEA ARABICA (COFFEE) SEED EXTRACT + GLYCERIN * TREHALOSE + PANTHENOL + Fees eT aR tasty Mien acne hceaci MO) Zant ee ae de gal Co rol Rae ee GLYCERETH-26 « EPIGALLOCATECHIN GALLATE * TOCOPHERSOLAN * XANTHAN GUM + DECYL GLUCOSIDE + TRIDECETH-6 - CARBOMER - POLOXAMER 235 + POLOXAMER 338 * DIPROPYLENE GLYCOL + pipe en ayy i etal Beeeimap lb nonstop - allele ua es {hon dll tat VARIN TULA ek og 2 NA a ce CAST Nets                     CINNAMAL + DISODIUM EDTA « PHENOXYETHANOL <ILN46462>"
                });

                // jin_ramen.jpg
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "jin_ramen.jpg",
                    Input = "Vt GN PRAG ww we ~\n\nINGREDIENTS :\n{)NOODLE: WHEAT FLOUR, MODIFIED STARCH(POTATO, TAPIOCA), PALM OIL, POTATO STARCH,\nWHEAT GLUTEN, SALT, YEAST EXTRACT, ACIDITY REGULATOR(POTASSIUM CARBONATE, SODIUM\n\nPOLYPHOSPHATE), RIBOFLAVIN\n\n2}POWDER SOUP: SALT, SUGAR, SOY SAUCE POWDER(SOY BEAN, WHEAT, SALT), GARLIC POWDER,\nSPICESIRED PEPPER, GARLIC, ONION, GREEN ONION, GINGER), MONOSOIDIUM GLUTAMATE,\nGLUCOSE, HYDROLYZED VEGETABLE PROTEIN(SOY, WHEAT, CORN), CHILLI EXTRACT, YEAST\n\nEXTRACT POWDER, BLACK PEPPER, RED PEPPER, KELP EXTRACT POWDER, DISODIUM\n\nINOS| DIUM GUANYLATE, DEXTRIN, MALIC ACID\nSED VEGETABLE MIX: CHINESE CABBAGE, TEXTURED VEGETABLE PROTEIN(SOY,\n\nWHEAT, CARROT, GREEN ONION, MUSHROOM, RED PEPPER\n\neee ee ee eee ee nam FeLi\nee eee\n",
                    Expected = "Vt GN PRAG ww we ~  INGREDIENTS : {)NOODLE: WHEAT FLOUR, MODIFIED STARCH(POTATO, TAPIOCA), PALM OIL, POTATO STARCH, WHEAT GLUTEN, SALT, YEAST EXTRACT, ACIDITY REGULATOR(POTASSIUM CARBONATE, SODIUM  POLYPHOSPHATE), RIBOFLAVIN  2}POWDER SOUP: SALT, SUGAR, SOY SAUCE POWDER(SOY BEAN, WHEAT, SALT), GARLIC POWDER, SPICESIRED PEPPER, GARLIC, ONION, GREEN ONION, GINGER), MONOSOIDIUM GLUTAMATE, GLUCOSE, HYDROLYZED VEGETABLE PROTEIN(SOY, WHEAT, CORN), CHILLI EXTRACT, YEAST  EXTRACT POWDER, BLACK PEPPER, RED PEPPER, KELP EXTRACT POWDER, DISODIUM  INOS DIUM GUANYLATE, DEXTRIN, MALIC ACID SED VEGETABLE MIX: CHINESE CABBAGE, TEXTURED VEGETABLE PROTEIN(SOY,  WHEAT, CARROT, GREEN ONION, MUSHROOM, RED PEPPER  eee ee ee eee ee nam FeLi ee eee"
                });

                // kate-sommerville_uncomplikated-spf-50.jpg
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "kate-sommerville_uncomplikated-spf-50.jpg",
                    Input = "",
                    Expected = ""
                });

                // kettle_sea-salt-and-vinegar-potato-chips.png
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "kettle_sea-salt-and-vinegar-potato-chips.png",
                    Input = "Ingredients\n\nIngredients: Potatoes, Safflower and/or Sunflower and/or\nCanola Oil, Vinegar Powder (Maltodextrin, White Distilled\nVinegar), Sea Salt, Maltodextrin, Citric Acid\n\nAllergen Info\n",
                    Expected = "Ingredients  Ingredients: Potatoes, Safflower and/or Sunflower and/or Canola Oil, Vinegar Powder (Maltodextrin, White Distilled Vinegar), Sea Salt, Maltodextrin, Citric Acid  Allergen Info"
                });

                // kroger_classic-trail-mix-with-m&ms-cookie.png
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "kroger_classic-trail-mix-with-m&ms-cookie.png",
                    Input = "Ingredients\n\nPeanuts, Raisins (Raisins, Sunflower Oil), Milk Chocolate\nCandies (Milk Chocolate [Sugar, Chocolate, Skim Milk, Cocoa\nButter, Lactose, Milk Fat, Soy Lecithin, Salt, Artificial Flavors],\nSugar, Cornstarch, Contains Less Than 1% Of: Corn Syrup,\nDextrin, Coloring [Includes Blue 1 Lake, Yellow 6, Red 40,\nYellow 5, Blue 1, Red 40 Lake, Blue 2 Lake, Yellow 6 Lake,\nYellow 5 Lake, Blue 2], Gum Acacia), Almonds, Cashews,\nVegetable Oil (Peanut, cottonseed, soybean, and/or sunflower\noil), Sea Salt CONTAINS: PEANUTS, ALMONDS, CASHEWS,\n",
                    Expected = "Ingredients  Peanuts, Raisins (Raisins, Sunflower Oil), Milk Chocolate Candies (Milk Chocolate [Sugar, Chocolate, Skim Milk, Cocoa Butter, Lactose, Milk Fat, Soy Lecithin, Salt, Artificial Flavors], Sugar, Cornstarch, Contains Less Than 1% Of: Corn Syrup, Dextrin, Coloring [Includes Blue 1 Lake, Yellow 6, Red 40, Yellow 5, Blue 1, Red 40 Lake, Blue 2 Lake, Yellow 6 Lake, Yellow 5 Lake, Blue 2], Gum Acacia), Almonds, Cashews, Vegetable Oil (Peanut, cottonseed, soybean, and/or sunflower oil), Sea Salt CONTAINS: PEANUTS, ALMONDS, CASHEWS,"
                });

                // kroger_kaleidos-original-chocolate-sandwich-cookies.png
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "kroger_kaleidos-original-chocolate-sandwich-cookies.png",
                    Input = "Ingredients\n\nIngredients: Sugar, Enriched Bleached Wheat Flour (Flour,\nNiacin, Iron, Thiamin Mononitrate, Riboflavin, Folic Acid),\nVegetable Oil (Contains One or More of the Following: Palm,\nSoybean [With TBHQ For Freshness]), Cocoa (Processed With\nAlkali), Contains 2% or Less of: High Fructose Corn Syrup,\nCorn Starch, Leavening (Baking Soda, Calcium Phosphate),\nSalt, Soy Lecithin, Dextrose, Cocoa Powder, Natural and\nArtificial Flavor, Caramel Color, Gum Acacia\n",
                    Expected = "Ingredients  Ingredients: Sugar, Enriched Bleached Wheat Flour (Flour, Niacin, Iron, Thiamin Mononitrate, Riboflavin, Folic Acid), Vegetable Oil (Contains One or More of the Following: Palm, Soybean [With TBHQ For Freshness]), Cocoa (Processed With Alkali), Contains 2% or Less of: High Fructose Corn Syrup, Corn Starch, Leavening (Baking Soda, Calcium Phosphate), Salt, Soy Lecithin, Dextrose, Cocoa Powder, Natural and Artificial Flavor, Caramel Color, Gum Acacia"
                });

                // lightlife_smart-bacon.jpg
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "lightlife_smart-bacon.jpg",
                    Input = "__ VITAL WHEAT GLUTEN, SOYBEAN Oil, SO¥ PROTEIN. |\n\nOo) 2.\n\nINGREDIENTS: WATER, SOY PROTEIN, ISOLATE,\nCONCENTRATE, TEXTURED WHEAT GLUTEN, LESS\nTHAN 2% OF: SALT, SUGAR, CARRAGEENAN, NATURAL.\n” FLAVOR, AUTOLYZED YEAST EXT RACT, NATURAL SMOKE\n\n_~ FLAVOR, SPICES, FERMENTED RICE FLOUR, OLEORESIN |\n\nPAPRIKA (COLOR), POTASSIUM CHLORIDE.\n",
                    Expected = "VITAL WHEAT GLUTEN, SOYBEAN Oil, SO¥ PROTEIN.   Oo) 2.  INGREDIENTS: WATER, SOY PROTEIN, ISOLATE, CONCENTRATE, TEXTURED WHEAT GLUTEN, LESS THAN 2% OF: SALT, SUGAR, CARRAGEENAN, NATURAL. ” FLAVOR, AUTOLYZED YEAST EXT RACT, NATURAL SMOKE  ~ FLAVOR, SPICES, FERMENTED RICE FLOUR, OLEORESIN   PAPRIKA (COLOR), POTASSIUM CHLORIDE."
                });

                // moroccanoil_blonde-perfecting-purple-shampoo.jpg
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "moroccanoil_blonde-perfecting-purple-shampoo.jpg",
                    Input = " \n",
                    Expected = ""
                });

                // nutella-and-go_hazelnut-spread-and-breadsticks.png
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "nutella-and-go_hazelnut-spread-and-breadsticks.png",
                    Input = "Ingredients\n\nIngredients: Nutella: Sugar, Palm Oil, Hazelnuts, Skim Milk,\nCocoa, Soy Lecithin as Emulsifier, Vanillin: An Artificial Flavor.\nBreadsticks: Enriched Flour (Wheat Flour, Niacin, Iron,\nThiamine Mononitrate, Riboflavin, Folic Acid), Palm Oil, Salt,\nMalt Extract, Baker's Yeast\n",
                    Expected = "Ingredients  Ingredients: Nutella: Sugar, Palm Oil, Hazelnuts, Skim Milk, Cocoa, Soy Lecithin as Emulsifier, Vanillin: An Artificial Flavor. Breadsticks: Enriched Flour (Wheat Flour, Niacin, Iron, Thiamine Mononitrate, Riboflavin, Folic Acid), Palm Oil, Salt, Malt Extract, Baker's Yeast"
                });

                // omorovicza_thermal-cleansing-balm.png
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "omorovicza_thermal-cleansing-balm.png",
                    Input = "et) T-Mobile Wi-Fi & 1:05 PM @ 7 100% {)\n\nK< Q INGREDIENTS O Ss\n\n-Hungarian Moor Mud: Cleanses and detoxifies the skin.\n-Sweet Almond Oil: Replenishes the skin and leaves it soft\nand silky.\n\n-Orange Blossom Oil: Lifts the spirits and the senses.\n-Hydro Mineral Transference™: Leaves skin firmer, more\nsupple, and younger-looking.\n\nCetearyl Ethylhexanoate, Prunus Amygdalus Dulcis (Sweet\nAlmond) Oil, Glyceryl Stearate, Stearyl Heptanoate,\nSqualane, Cera Alba (Beeswax), Polysorbate 20, Cetearyl\nAlcohol, Phenoxyethanol, Benzyl! Alcohol, Limonene,\nFragrance, Saccharomyces (Hungarian Thermal Water)\nFerment Extract, Tocopherol, Ethylhexylglycerin,\nHungarian Thermal Water, Linalool, Malpighia Punicifolia\n(Acerola) Fruit Extract, Phospholipids.\n\nA f& © ee\n\nHome Shop Claire Stores Inspire\n\n \n\n \n\n \n\n \n\n \n",
                    Expected = "et) T-Mobile Wi-Fi & 1:05 PM @ 7 100% {)  K< Q INGREDIENTS O Ss  -Hungarian Moor Mud: Cleanses and detoxifies the skin. -Sweet Almond Oil: Replenishes the skin and leaves it soft and silky.  -Orange Blossom Oil: Lifts the spirits and the senses. -Hydro Mineral Transference™: Leaves skin firmer, more supple, and younger-looking.  Cetearyl Ethylhexanoate, Prunus Amygdalus Dulcis (Sweet Almond) Oil, Glyceryl Stearate, Stearyl Heptanoate, Squalane, Cera Alba (Beeswax), Polysorbate 20, Cetearyl Alcohol, Phenoxyethanol, Benzyl! Alcohol, Limonene, Fragrance, Saccharomyces (Hungarian Thermal Water) Ferment Extract, Tocopherol, Ethylhexylglycerin, Hungarian Thermal Water, Linalool, Malpighia Punicifolia (Acerola) Fruit Extract, Phospholipids.  A f& © ee  Home Shop Claire Stores Inspire"
                });

                // simple-truth-organic_wavy-cheddar-sour-cream-potato-chips.png
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "simple-truth-organic_wavy-cheddar-sour-cream-potato-chips.png",
                    Input = "Ingredients\n\nIngredients: Organic Potatoes, Organic Oil Blend (Sunflower\nOil, Safflower Oil and/or Red Palm Fruit Oil), Cheese Powder\n(Organic Cheddar Cheese [Organic Milk, Cultures, Salt,\nEnzymes], Disodium Phosphate), Organic Maltodextrin, Sea\nSalt, Organic Sour Cream Powder (Organic Sour Cream\n[Organic Cream, Cultures, Lactic Acid], Organic Nonfat Milk\nSolids, Citric Acid), Organic Buttermilk, Organic Whey, Organic\nOnion Powder, Natural Flavor, Organic Butter Powder (Organic\nButter [Organic Cream, Salt], Organic Nonfat Dry Milk), Yeast\nExtract, Organic Annatto Extract, Lactic Acid, Citric Acid,\nOrganic Garlic Powder, Organic Skim Milk\n",
                    Expected = "Ingredients  Ingredients: Organic Potatoes, Organic Oil Blend (Sunflower Oil, Safflower Oil and/or Red Palm Fruit Oil), Cheese Powder (Organic Cheddar Cheese [Organic Milk, Cultures, Salt, Enzymes], Disodium Phosphate), Organic Maltodextrin, Sea Salt, Organic Sour Cream Powder (Organic Sour Cream [Organic Cream, Cultures, Lactic Acid], Organic Nonfat Milk Solids, Citric Acid), Organic Buttermilk, Organic Whey, Organic Onion Powder, Natural Flavor, Organic Butter Powder (Organic Butter [Organic Cream, Salt], Organic Nonfat Dry Milk), Yeast Extract, Organic Annatto Extract, Lactic Acid, Citric Acid, Organic Garlic Powder, Organic Skim Milk"
                });

                // too-faced_better-than-sex-mascara.jpg
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "too-faced_better-than-sex-mascara.jpg",
                    Input = "INGREDIENTS:\nAqua/Water/Eau, Synthetic\nBeeswax, Paraffin, Glyceryl\n\nStearate, Acacia Senegal Gum,\nButylene Glycol, Oryza Sativa\n(Rice) Bran Wax/Oryza Sativa\n\nBran Cera, Stearic Acid,\nPalmitic Acid, Polybutene,\nVP/Eicosene Copolymer,\nCopernicia Cerifera (Carnauba)\nWax/Copernicia Cerifera\nCera/Cire De Carnauba,\nAminomethyl Propanol, Glycerin,\nPVP, Ethylhexylglycerin,\n\nHydroxyethylcellulose, Disodium\n\nEDTA, Polyester-11, Cellulose,\n\nTrimethylpentanediol/Adipic\nAcid/Glycerin Crosspolymer,\nPropylene Glycol, Disodium\nPhosphate, Polysorbate 60,\nAcacia Seyal Gum Extract,\nSodium Phosphate, Acetyl\n\nHexapeptide-1, Dextran,\nPhenoxyethanol, Potassium\nSorbate, Iron Oxides\n\n(Cl 77499), Ultramarines\n(Cl 77007), Black 2 (Cl 77266).\n\n]\ni\n\nMacxapa - Rimel\n» Ripsmetuss - Rasenka\n- Mascara para pestanas\n- Rimel - Blakstieny tusas\n« Skropstu tusa\n- Mascara » Maskara\n\n¢ OuHa cnupasia\n+ Tusz do rzes « |)Sulo\n\nDist. by/Distr. par\nToo Faced Cosmetics, LLC\nIrvine, CA 92614 USA\nBiorius, 7170\nManage, Belgium\nMade in Italy\nFabriqué en Italie\n© 2018 Too Faced\nCosmetics, LLC\nAll Rights Reserved\nTous droits reserves\n\n \n",
                    Expected = "INGREDIENTS: Aqua/Water/Eau, Synthetic Beeswax, Paraffin, Glyceryl  Stearate, Acacia Senegal Gum, Butylene Glycol, Oryza Sativa (Rice) Bran Wax/Oryza Sativa  Bran Cera, Stearic Acid, Palmitic Acid, Polybutene, VP/Eicosene Copolymer, Copernicia Cerifera (Carnauba) Wax/Copernicia Cerifera Cera/Cire De Carnauba, Aminomethyl Propanol, Glycerin, PVP, Ethylhexylglycerin,  Hydroxyethylcellulose, Disodium  EDTA, Polyester-11, Cellulose,  Trimethylpentanediol/Adipic Acid/Glycerin Crosspolymer, Propylene Glycol, Disodium Phosphate, Polysorbate 60, Acacia Seyal Gum Extract, Sodium Phosphate, Acetyl  Hexapeptide-1, Dextran, Phenoxyethanol, Potassium Sorbate, Iron Oxides  (Cl 77499), Ultramarines (Cl 77007), Black 2 (Cl 77266).  ] i  Macxapa - Rimel » Ripsmetuss - Rasenka - Mascara para pestanas - Rimel - Blakstieny tusas « Skropstu tusa - Mascara » Maskara  ¢ OuHa cnupasia + Tusz do rzes « )Sulo  Dist. by/Distr. par Too Faced Cosmetics, LLC Irvine, CA 92614 USA Biorius, 7170 Manage, Belgium Made in Italy Fabriqué en Italie © 2018 Too Faced Cosmetics, LLC All Rights Reserved Tous droits reserves"
                });
            }
        }
    }
}
