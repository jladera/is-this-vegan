
using Is_This_Vegan__Net_.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Is_This_Vegan_Test.Testing_Helpers
{
    public class IngredientLocalRepositoryCollection
    {
        public class Read : TestCollection
        {
            public Read()
            {
                IngredientLists = new List<TestingModel>();

                // belvita_vanilla-cookie.jpg
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "belvita_vanilla-cookie.jpg",
                    Input = new List<string>()
                    {
                        "whole grain wheat flour",
                        "wheat flour",
                        "niacin",
                        "reduced iron",
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
                        "niacinamide",
                        "thiamin mononitrate (vitamin b1)",
                        "riboflavin (vitamin b2)",
                        "ferric orthophosphate (iron)",
                        "pyridoxine hydrochloride (vitamin b6)"
                    }
                });

                // glam-glow_glow-lace-sheet-mask.jpg
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "glam-glow_glow-lace-sheet-mask.jpg",
                    Input = "water\\aqua\\eau, butylene glycol, methypropanediol, 1,2-hexanediol, 1,2-hexanediol, sodium hyaluronate, camellia sinensis (green tea) leaf extract, caffeine, coffea arabica (coffee) seed extract, glycerin, trehalose, panthenol, arginine, dipotassium glycyrrhizate, ethylhexylglycerin, dimethicone, dimethicone/peg-10/15 crosspolymer, glycereth-26, epigallocatechin gallate, tocophersolan, xanthan gum, decyl glucoside, trideceth-6, carbomer poloxamer 235, ploxamer 338, dipropylene glycol, propanediol, ethylhexyl stearate, sodium polyacrylate, ammonium acryloydimethyltaurate/vp copolymer, peg-40 hydrogenated castor oil, fragrance (parfum), hexylcinnamal, disodium edta, phenoxyethanol <iln46462>",
                    Expected = new PipelineResultModel()
                    {
                        isSuccessful = true,
                        meanConfidence = 0,
                        result = new List<string>()
                        {
                            "water\\aqua\\eau", 
                            "butylene glycol", 
                            "methypropanediol", 
                            "sodium hyaluronate", 
                            "caffeine", 
                            "glycerin", 
                            "trehalose", 
                            "panthenol", 
                            "arginine", 
                            "dipotassium glycyrrhizate", 
                            "ethylhexylglycerin", 
                            "dimethicone", 
                            "dimethicone/peg-10/15 crosspolymer", 
                            "glycereth-26", 
                            "epigallocatechin gallate", 
                            "tocophersolan", 
                            "xanthan gum", 
                            "decyl glucoside", 
                            "trideceth-6", 
                            "carbomer poloxamer 235", 
                            "ploxamer 338", 
                            "dipropylene glycol", 
                            "propanediol", 
                            "ethylhexyl stearate", 
                            "sodium polyacrylate", 
                            "ammonium acryloydimethyltaurate/vp copolymer", 
                            "peg-40 hydrogenated castor oil", 
                            "hexylcinnamal", 
                            "disodium edta", 
                            "phenoxyethanol <iln46462>",
                            "camellia sinensis (green tea) leaf extract",
                            "coffea arabica (coffee) seed extract",
                            "fragrance (parfum)",
                            "1,2-hexanediol"
                        }
                    }
                }); 

              // jin_ramen.jpg
              IngredientLists.Add(new TestingModel()
                {
                    Filename = "jin_ramen.jpg",
                    Input = "wheat flour, modified starch (potato, tapioca), palm oil, potato starch, wheat gluten, salt, yeast extract, acidity regulator (potassium carbonate, sodium polyphosphate), riboflavin, sugar, soy sauce powder (soy bean, wheat, salt), garlic powder, spices (red pepper, garlic, onion, green onion, ginger), monosodium glutamate, glucose, hydrolyzed vegetable protein (soy, wheat, corn), chili extract, yeast extract powder, black pepper, red pepper, kelp extract powder, disodium inosinate, disodium guanylate, dextrin, malic acid, chinese cabbage, textured vegetable protein (soy, wheat), carrot, green onion, mushroom, red pepper",
                    Expected = new PipelineResultModel()
                    {
                        isSuccessful = true,
                        meanConfidence = 0,
                        result = new List<string>()
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
                            "chili extract", 
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
                    }
              });

                // kate-sommerville_uncomplikated-spf-50.jpg
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "kate-sommerville_uncomplikated-spf-50.jpg",
                    Input = "alcohol denat., isobutane, propane, isododecane, ethylhexyl methoxycrylene, pvp, methyl dihydroabietate, hydrolyzed hyaluronic acid, rhodiola rosea root extract, water/aqua/eau, lavandula angustifolia (lavender) oil, silica silylate, pentylene glycol",
                    Expected = new PipelineResultModel()
                    {
                        isSuccessful = true,
                        meanConfidence = 0,
                        result = new List<string>()
                        {
                            "alcohol denat.", 
                            "isobutane", 
                            "propane", 
                            "isododecane", 
                            "ethylhexyl methoxycrylene", 
                            "pvp", 
                            "methyl dihydroabietate", 
                            "hydrolyzed hyaluronic acid", 
                            "rhodiola rosea root extract", 
                            "water/aqua/eau", 
                            "silica silylate", 
                            "pentylene glycol",
                            "lavandula angustifolia (lavender) oil"
                        }
                    }
                });

                // kettle_sea-salt-and-vinegar-potato-chips.png
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "kettle_sea-salt-and-vinegar-potato-chips.png",
                    Input = "potatoes, safflower and/or sunflower and/or canola oil, vinegar powder (maltodextrin, white distilled vinegar), sea salt, maltodextrin, citric acid",
                    Expected = new PipelineResultModel()
                    {
                        isSuccessful = true,
                        meanConfidence = 0,
                        result = new List<string>()
                        {
                            "potatoes", 
                            "safflower and/or sunflower and/or canola oil",
                            "maltodextrin", 
                            "white distilled vinegar", 
                            "sea salt",
                            "citric acid"
                        }
                    }
                });

                // kroger_classic-trail-mix-with-m&ms-cookie.png
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "kroger_classic-trail-mix-with-m&ms-cookie.png",
                    Input = "peanuts, raisins (raisins, sunflower oil), milk chocolate candies (milk chocolate [sugar, chocolate, skim milk, cocoa butter, lactose, milk fat, soy lecithin, salt, artificial flavors], sugar, cornstarch, corn syrup, dextrin, coloring [includes blue 1 lake, yellow 6, red 40, yellow 5, blue 1, red 40 lake, blue 2 lake, yellow 6 lake, yellow 5 lake, blue 2], gum acacia), almonds, cashews, vegetable oil (peanut, cottonseed, soybean, and/or sunflower oil), sea salt",
                    Expected = new PipelineResultModel()
                    {
                        isSuccessful = true,
                        meanConfidence = 0,
                        result = new List<string>()
                        {
                            "peanuts",
                            "raisins", 
                            "sunflower oil", 
                            "sugar", 
                            "chocolate", 
                            "skim milk", 
                            "cocoa butter", 
                            "lactose", 
                            "milk fat", 
                            "soy lecithin", 
                            "salt", 
                            "artificial flavors", 
                            "cornstarch", 
                            "corn syrup", 
                            "dextrin", 
                            "includes blue 1 lake", 
                            "yellow 6", 
                            "red 40", 
                            "yellow 5", 
                            "blue 1", 
                            "red 40 lake", 
                            "blue 2 lake", 
                            "yellow 6 lake", 
                            "yellow 5 lake", 
                            "blue 2", 
                            "gum acacia", 
                            "almonds", 
                            "cashews", 
                            "peanut", 
                            "cottonseed", 
                            "soybean", 
                            "and/or sunflower oil", 
                            "sea salt"
                        }
                    }
                });

                // kroger_kaleidos-original-chocolate-sandwich-cookies.png
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "kroger_kaleidos-original-chocolate-sandwich-cookies.png",
                    Input = "sugar, enriched bleached wheat flour (flour, niacin, iron, thiamin mononitrrate, riboflavin, folic acid), vegetable oil (palm, soybean, tbhq), cocoa, alkali, high fructose corn syrup, corn starch, leavening (baking soda, calcium phosphate), salt, soy lecithin, dextrose, cocoa powder, natural and artificial flavor, caramel color, gum acacia",
                    Expected = new PipelineResultModel()
                    {
                        isSuccessful = true,
                        meanConfidence = 0,
                        result = new List<string>()
                        {
                            "sugar", 
                            "flour", 
                            "niacin", 
                            "iron", 
                            "thiamin mononitrrate", 
                            "riboflavin", 
                            "folic acid", 
                            "palm", 
                            "soybean", 
                            "tbhq", 
                            "cocoa", 
                            "alkali", 
                            "high fructose corn syrup", 
                            "corn starch", 
                            "baking soda", 
                            "calcium phosphate", 
                            "salt", 
                            "soy lecithin", 
                            "dextrose", 
                            "cocoa powder", 
                            "natural and artificial flavor", 
                            "caramel color", 
                            "gum acacia"
                        }
                    }
                });

                // lightlife_smart-bacon.jpg
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "lightlife_smart-bacon.jpg",
                    Input = "water, soy protein, isolate, vital wheat gluten, soybean oil, soy protein  concentrate, textured wheat gluten, salt, sugar carrageenan, natural flavor, autolyzed yeast extract, natural smoke flavor, spices, fermented rice flour, oleoresin paprika, potassium chloride",
                    Expected = new PipelineResultModel()
                    {
                        isSuccessful = true,
                        meanConfidence = 0,
                        result = new List<string>()
                        {
                            "water", 
                            "soy protein", 
                            "isolate", 
                            "vital wheat gluten", 
                            "soybean oil", 
                            "soy protein  concentrate", 
                            "textured wheat gluten", 
                            "salt", 
                            "sugar carrageenan", 
                            "natural flavor", 
                            "autolyzed yeast extract",
                            "natural smoke flavor", 
                            "spices", 
                            "fermented rice flour", 
                            "oleoresin paprika", 
                            "potassium chloride"
                        }
                    }
                });

                // moroccanoil_blonde-perfecting-purple-shampoo.jpg
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "moroccanoil_blonde-perfecting-purple-shampoo.jpg",
                    Input = "aqua/water/eau, sodium c14-16 olefin sulfonate, cocamidopropyl betaine, cocamidopropylamine oxide, parfum/fragrance, guar hydroxypropyltrimonium chloride, argania spinosa (argan) kernel oil, peg-40 hydrogenated castory oil, acrylates copolymer, peg-150 distearate, glycol stearate, hydroxyacetophenone, algin, glycerin, chitosan, trideceth-9, c12-13 pareth-9, c11-15 pareth-7, c12-16 pareth-9, silica dimethyl silylate, isopropyl alcohol, trideceth-12 citric acid, coconut acid, cocamidopropyl dimethylamine, caprylyl glycol, cetrimonium chloride, sodium glycolate, ci 60730 (ext. violet no.2), trimethylsiloxyamodimethicone, caprylicicapric j101, triglyceride, phenoxythanol, chlorphenesin, potassium sorbate, sodium benzoate, alpha-isomethyl ionone, linalool. mopps02",
                    Expected = new PipelineResultModel()
                    {
                        isSuccessful = true,
                        meanConfidence = 0,
                        result = new List<string>()
                        {
                            "aqua/water/eau", 
                            "sodium c14-16 olefin sulfonate", 
                            "cocamidopropyl betaine", 
                            "cocamidopropylamine oxide", 
                            "parfum/fragrance", 
                            "guar hydroxypropyltrimonium chloride", 
                            "peg-40 hydrogenated castory oil", 
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
                            "trideceth-12 citric acid", 
                            "coconut acid", 
                            "cocamidopropyl dimethylamine", 
                            "caprylyl glycol", 
                            "cetrimonium chloride", 
                            "sodium glycolate", 
                            "trimethylsiloxyamodimethicone", 
                            "caprylicicapric j101", 
                            "triglyceride", 
                            "phenoxythanol", 
                            "chlorphenesin", 
                            "potassium sorbate", 
                            "sodium benzoate", 
                            "alpha-isomethyl ionone", 
                            "linalool. mopps02",
                            "argania spinosa (argan) kernel oil",
                            "ci 60730 (ext. violet no.2)"
                        }
                    }
                });

                // nutella-and-go_hazelnut-spread-and-breadsticks.png
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "nutella-and-go_hazelnut-spread-and-breadsticks.png",
                    Input = "sugar, palm oil, hazelnuts, skim milk, cocoa, soy lecithin, vanillin, enriched flour (wheat flour, niacin, iron, thiamine mononitrate, riboflavin, folic acid), palm oil, salt, malt extract, baker's yeast",
                    Expected = new PipelineResultModel()
                    {
                        isSuccessful = true,
                        meanConfidence = 0,
                        result = new List<string>()
                        {
                            "sugar", 
                            "palm oil", 
                            "hazelnuts", 
                            "skim milk", 
                            "cocoa", 
                            "soy lecithin", 
                            "vanillin", 
                            "wheat flour", 
                            "niacin", 
                            "iron", 
                            "thiamine mononitrate", 
                            "riboflavin", 
                            "folic acid", 
                            "salt", 
                            "malt extract", 
                            "baker's yeast"
                        }
                    }
                });

                // omorovicza_thermal-cleansing-balm.png
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "omorovicza_thermal-cleansing-balm.png",
                    Input = "cetearyl ethylhexanoate, prunus amygdalus dulcis (sweet almond) oil, glyceryl stearate, stearyl heptanoate, squalane, cera alba (beeswax), polysorbate 20, cetearyl alcohol, phenoxyethanol, benzyl alcohol, limonene, fragrance, saccharomyces (hungarian thermal water) ferment extract, tocopherol, ethylhexylglycerin, hungarian thermal water, linalool, malpighia punicifolia (acerola) fruit extract, phospholipids",
                    Expected = new PipelineResultModel()
                    {
                        isSuccessful = true,
                        meanConfidence = 0,
                        result = new List<string>()
                        {
                            "cetearyl ethylhexanoate", 
                            "glyceryl stearate", 
                            "stearyl heptanoate", 
                            "squalane", 
                            "polysorbate 20", 
                            "cetearyl alcohol", 
                            "phenoxyethanol", 
                            "benzyl alcohol", 
                            "limonene", 
                            "fragrance", 
                            "tocopherol", 
                            "ethylhexylglycerin", 
                            "hungarian thermal water", 
                            "linalool", 
                            "phospholipids",
                            "prunus amygdalus dulcis (sweet almond) oil",
                            "cera alba (beeswax)",
                            "saccharomyces (hungarian thermal water) ferment extract",
                            "malpighia punicifolia (acerola) fruit extract"
                        }
                    }
                });

                // simple-truth-organic_wavy-cheddar-sour-cream-potato-chips.png
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "simple-truth-organic_wavy-cheddar-sour-cream-potato-chips.png",
                    Input = "organic potatoes, organic oil blend (sunflower oil, safflower oil, and/or red palm fruit oil), cheese powder (organic cheddar cheese [organic milk, cultures, salt, enzymes], disodium phosphate), organic maltodextrin, sea salt, organic sour cream powder (organic sour cream [organic cream, cultures, lactic acid], organic nonfat milk solids, citric acid), organic buttermilk, organic whey, organic onion powder, natural flavor, organic butter powder (organic butter [organic cream, salt], organic nonfat dry milk), yeast extract, organic annatto extract, lactic acid, citric acid, organic garlic powder, organic skim milk",
                    Expected = new PipelineResultModel()
                    {
                        isSuccessful = true,
                        meanConfidence = 0,
                        result = new List<string>()
                        {
                            "organic potatoes", 
                            "sunflower oil", 
                            "safflower oil", 
                            "and/or red palm fruit oil", 
                            "organic milk", 
                            "cultures", 
                            "salt", 
                            "enzymes", 
                            "disodium phosphate", 
                            "organic maltodextrin", 
                            "sea salt", 
                            "organic cream", 
                            "lactic acid", 
                            "organic nonfat milk solids", 
                            "citric acid", 
                            "organic buttermilk", 
                            "organic whey", 
                            "organic onion powder", 
                            "natural flavor", 
                            "organic nonfat dry milk", 
                            "yeast extract", 
                            "organic annatto extract", 
                            "organic garlic powder", 
                            "organic skim milk"
                        }
                    }
                });

                // too-faced_better-than-sex-mascara.jpg
                IngredientLists.Add(new TestingModel()
                {
                    Filename = "too-faced_better-than-sex-mascara.jpg",
                    Input = "aqua/water/eau, syntheic beeswax, paraffin, glyceryl stearate, acacia senegal gum, butylene glycol, oryza sativa (rice) bran wax/oryza sativa bran cera, stearic acid, palmitic acid, polybutene, vp/eicosene copolymer, copernicia cerifera (carnauba) wax/copernicia cerifera cera/cire de carnauba amimomethyl propanol, glycerin, pvp, ethylhexylglycerin, hydroxyethylcellulose, disodium edta, polyester-11, cellulose, trimethylpentanediol/adipic acid/glycerin crosspolymer, propylene glycol, disodium phosphate, polysorbate 60, acacia seyal gum extract, sodium phosphate acetyl hexapeptide-1, dextran, phenoxyethanol potassium sorbate, iron oxides (ci 77499), ultramarines (ci 77007), black 2 (ci 77266)",
                    Expected = new PipelineResultModel()
                    {
                        isSuccessful = true,
                        meanConfidence = 0,
                        result = new List<string>()
                        {
                            "aqua/water/eau", 
                            "syntheic beeswax", 
                            "paraffin", 
                            "glyceryl stearate", 
                            "acacia senegal gum", 
                            "butylene glycol", 
                            "stearic acid", 
                            "palmitic acid", 
                            "polybutene", 
                            "vp/eicosene copolymer", 
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
                            "sodium phosphate acetyl hexapeptide-1", 
                            "dextran", 
                            "phenoxyethanol potassium sorbate",
                            "oryza sativa (rice) bran wax/oryza sativa bran cera",
                            "copernicia cerifera (carnauba) wax/copernicia cerifera cera/cire de carnauba amimomethyl propanol",
                            "iron oxides (ci 77499)",
                            "ultramarines (ci 77007)",
                            "black 2 (ci 77266)"
                        }
                    }
                });
            }
        }
    }
}

