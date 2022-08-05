using Microsoft.EntityFrameworkCore;
using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Extensions
{
    public static class ModelBuilderExtension
    {

        public static void SeedData(this ModelBuilder builder)
        {
            builder.SeedGroceryCategories();
            builder.SeedGroceryItems();
            builder.SeedRecipeCategories();
            builder.SeedExampleRecipes();
        }

        // Data Seeding and linking between related data:

        private static int fruitAndVegetablesId = 1;
        private static int freshAndCooledId = 2;
        private static int frozenId = 3;
        private static int foodId = 4;
        private static int spiecesId = 5;
        private static int sweetAndSaltyId = 6;
        private static int coffeeTeaCocoaId = 7;
        private static int beveragesId = 8;
        private static int wineAndSpiritsId = 9;

        private static void SeedGroceryCategories(this ModelBuilder builder)
        {
            builder.Entity<GroceryCategory>().HasData(
                new { Id = fruitAndVegetablesId, Name = "Obst und Gemüse" },
                new { Id = freshAndCooledId, Name = "Frische und Kühlung" },
                new { Id = frozenId, Name = "Tiefkühl" },
                new { Id = foodId, Name = "Nahrungsmittel" },
                new { Id = spiecesId, Name = "Gewürze" },
                new { Id = sweetAndSaltyId, Name = "Süßes und Salziges" },
                new { Id = coffeeTeaCocoaId, Name = "Kaffee, Tee & Kakao" },
                new { Id = beveragesId, Name = "Getränke" },
                new { Id = wineAndSpiritsId, Name = "Wein & Spirituosen" }
            );
        }

        private static void SeedGroceryItems(this ModelBuilder builder)
        {
            builder.Entity<GroceryItem>().HasData(
                new { Id = 1, GroceryCategoryId = fruitAndVegetablesId, Name = "Ananas" },
                new { Id = 2, GroceryCategoryId = fruitAndVegetablesId, Name = "Apfel" },
                new { Id = 3, GroceryCategoryId = fruitAndVegetablesId, Name = "Apfelsine" },
                new { Id = 4, GroceryCategoryId = fruitAndVegetablesId, Name = "Aprikose" },
                new { Id = 5, GroceryCategoryId = fruitAndVegetablesId, Name = "Aubergine" },
                new { Id = 6, GroceryCategoryId = fruitAndVegetablesId, Name = "Banane" },
                new { Id = 7, GroceryCategoryId = fruitAndVegetablesId, Name = "Birne" },
                new { Id = 8, GroceryCategoryId = fruitAndVegetablesId, Name = "Blattsalat" },
                new { Id = 9, GroceryCategoryId = fruitAndVegetablesId, Name = "Blaubeeren" },
                new { Id = 10, GroceryCategoryId = fruitAndVegetablesId, Name = "Blumenkohl" },
                new { Id = 11, GroceryCategoryId = fruitAndVegetablesId, Name = "Brokkoli" },
                new { Id = 12, GroceryCategoryId = fruitAndVegetablesId, Name = "Brombeere" },
                new { Id = 13, GroceryCategoryId = fruitAndVegetablesId, Name = "Clementine" },
                new { Id = 14, GroceryCategoryId = fruitAndVegetablesId, Name = "Cranberries" },
                new { Id = 15, GroceryCategoryId = fruitAndVegetablesId, Name = "Dattel" },
                new { Id = 16, GroceryCategoryId = fruitAndVegetablesId, Name = "Drachenfrucht" },
                new { Id = 17, GroceryCategoryId = fruitAndVegetablesId, Name = "Eisbergsalat" },
                new { Id = 18, GroceryCategoryId = fruitAndVegetablesId, Name = "Erbse" },
                new { Id = 19, GroceryCategoryId = fruitAndVegetablesId, Name = "Erdbeere" },
                new { Id = 20, GroceryCategoryId = fruitAndVegetablesId, Name = "Feige" },
                new { Id = 21, GroceryCategoryId = fruitAndVegetablesId, Name = "Feldsalat" },
                new { Id = 22, GroceryCategoryId = fruitAndVegetablesId, Name = "Fenchel" },
                new { Id = 23, GroceryCategoryId = fruitAndVegetablesId, Name = "Granatapfel" },
                new { Id = 24, GroceryCategoryId = fruitAndVegetablesId, Name = "Grapefruit" },
                new { Id = 25, GroceryCategoryId = fruitAndVegetablesId, Name = "Grünkohl" },
                new { Id = 26, GroceryCategoryId = fruitAndVegetablesId, Name = "Guave" },
                new { Id = 27, GroceryCategoryId = fruitAndVegetablesId, Name = "Gurke" },
                new { Id = 28, GroceryCategoryId = fruitAndVegetablesId, Name = "Hagebutte" },
                new { Id = 29, GroceryCategoryId = fruitAndVegetablesId, Name = "Heidelbeere" },
                new { Id = 30, GroceryCategoryId = fruitAndVegetablesId, Name = "Himbeere" },
                new { Id = 31, GroceryCategoryId = fruitAndVegetablesId, Name = "Holunderbeere" },
                new { Id = 32, GroceryCategoryId = fruitAndVegetablesId, Name = "Honigmelone" },
                new { Id = 33, GroceryCategoryId = fruitAndVegetablesId, Name = "Ingwer" },
                new { Id = 34, GroceryCategoryId = fruitAndVegetablesId, Name = "Johannisbeere" },
                new { Id = 35, GroceryCategoryId = fruitAndVegetablesId, Name = "Kaki" },
                new { Id = 36, GroceryCategoryId = fruitAndVegetablesId, Name = "Kaktusfeige" },
                new { Id = 37, GroceryCategoryId = fruitAndVegetablesId, Name = "Kartoffeln" },
                new { Id = 38, GroceryCategoryId = fruitAndVegetablesId, Name = "Kirsche" },
                new { Id = 39, GroceryCategoryId = fruitAndVegetablesId, Name = "Kiwi" },
                new { Id = 40, GroceryCategoryId = fruitAndVegetablesId, Name = "Knoblauch" },
                new { Id = 41, GroceryCategoryId = fruitAndVegetablesId, Name = "Kohlrabi" },
                new { Id = 42, GroceryCategoryId = fruitAndVegetablesId, Name = "Kohlrübe" },
                new { Id = 43, GroceryCategoryId = fruitAndVegetablesId, Name = "Kokosnuss" },
                new { Id = 44, GroceryCategoryId = fruitAndVegetablesId, Name = "Kürbis" },
                new { Id = 45, GroceryCategoryId = fruitAndVegetablesId, Name = "Lauchzwiebeln" },
                new { Id = 46, GroceryCategoryId = fruitAndVegetablesId, Name = "Limette" },
                new { Id = 47, GroceryCategoryId = fruitAndVegetablesId, Name = "Linsen" },
                new { Id = 48, GroceryCategoryId = fruitAndVegetablesId, Name = "Litschi" },
                new { Id = 49, GroceryCategoryId = fruitAndVegetablesId, Name = "Mandarine" },
                new { Id = 50, GroceryCategoryId = fruitAndVegetablesId, Name = "Mango" },
                new { Id = 51, GroceryCategoryId = fruitAndVegetablesId, Name = "Maracuja" },
                new { Id = 52, GroceryCategoryId = fruitAndVegetablesId, Name = "Melonen" },
                new { Id = 53, GroceryCategoryId = fruitAndVegetablesId, Name = "Mirabelle" },
                new { Id = 54, GroceryCategoryId = fruitAndVegetablesId, Name = "Möhre" },
                new { Id = 55, GroceryCategoryId = fruitAndVegetablesId, Name = "Nektarine" },
                new { Id = 56, GroceryCategoryId = fruitAndVegetablesId, Name = "Orange" },
                new { Id = 57, GroceryCategoryId = fruitAndVegetablesId, Name = "Pampelmuse" },
                new { Id = 58, GroceryCategoryId = fruitAndVegetablesId, Name = "Papaya" },
                new { Id = 59, GroceryCategoryId = fruitAndVegetablesId, Name = "Paprika" },
                new { Id = 60, GroceryCategoryId = fruitAndVegetablesId, Name = "Passionsfrucht" },
                new { Id = 61, GroceryCategoryId = fruitAndVegetablesId, Name = "Pastinake" },
                new { Id = 62, GroceryCategoryId = fruitAndVegetablesId, Name = "Petersilie" },
                new { Id = 63, GroceryCategoryId = fruitAndVegetablesId, Name = "Pfirsich" },
                new { Id = 64, GroceryCategoryId = fruitAndVegetablesId, Name = "Pflaume" },
                new { Id = 65, GroceryCategoryId = fruitAndVegetablesId, Name = "Physalis" },
                new { Id = 66, GroceryCategoryId = fruitAndVegetablesId, Name = "Porree" },
                new { Id = 67, GroceryCategoryId = fruitAndVegetablesId, Name = "Preiselbeere" },
                new { Id = 68, GroceryCategoryId = fruitAndVegetablesId, Name = "Puffbohnen" },
                new { Id = 69, GroceryCategoryId = fruitAndVegetablesId, Name = "Quitte" },
                new { Id = 70, GroceryCategoryId = fruitAndVegetablesId, Name = "Radieschen" },
                new { Id = 71, GroceryCategoryId = fruitAndVegetablesId, Name = "Rettich" },
                new { Id = 72, GroceryCategoryId = fruitAndVegetablesId, Name = "Rhabarber" },
                new { Id = 73, GroceryCategoryId = fruitAndVegetablesId, Name = "Rote Rübe" },
                new { Id = 74, GroceryCategoryId = fruitAndVegetablesId, Name = "Rotkohl" },
                new { Id = 75, GroceryCategoryId = fruitAndVegetablesId, Name = "Salatgurke" },
                new { Id = 76, GroceryCategoryId = fruitAndVegetablesId, Name = "Sanddornbeere" },
                new { Id = 77, GroceryCategoryId = fruitAndVegetablesId, Name = "Sauerkirsche" },
                new { Id = 78, GroceryCategoryId = fruitAndVegetablesId, Name = "Schalotten" },
                new { Id = 79, GroceryCategoryId = fruitAndVegetablesId, Name = "Schnittlauch" },
                new { Id = 80, GroceryCategoryId = fruitAndVegetablesId, Name = "Sellerie" },
                new { Id = 81, GroceryCategoryId = fruitAndVegetablesId, Name = "Sojabohnen" },
                new { Id = 82, GroceryCategoryId = fruitAndVegetablesId, Name = "Spinat" },
                new { Id = 83, GroceryCategoryId = fruitAndVegetablesId, Name = "Stachelbeere" },
                new { Id = 84, GroceryCategoryId = fruitAndVegetablesId, Name = "Suppengrün" },
                new { Id = 85, GroceryCategoryId = fruitAndVegetablesId, Name = "Süßkartoffeln" },
                new { Id = 86, GroceryCategoryId = fruitAndVegetablesId, Name = "Süßkirsche" },
                new { Id = 87, GroceryCategoryId = fruitAndVegetablesId, Name = "Tomate" },
                new { Id = 88, GroceryCategoryId = fruitAndVegetablesId, Name = "Tomate (klein)" },
                new { Id = 89, GroceryCategoryId = fruitAndVegetablesId, Name = "Traube" },
                new { Id = 90, GroceryCategoryId = fruitAndVegetablesId, Name = "Wassermelone" },
                new { Id = 91, GroceryCategoryId = fruitAndVegetablesId, Name = "Weintraube" },
                new { Id = 92, GroceryCategoryId = fruitAndVegetablesId, Name = "Weißkohl" },
                new { Id = 93, GroceryCategoryId = fruitAndVegetablesId, Name = "Zitrone" },
                new { Id = 94, GroceryCategoryId = fruitAndVegetablesId, Name = "Zucchini" },
                new { Id = 95, GroceryCategoryId = fruitAndVegetablesId, Name = "Zuckermelone" },
                new { Id = 96, GroceryCategoryId = fruitAndVegetablesId, Name = "Zwetschge" },
                new { Id = 97, GroceryCategoryId = fruitAndVegetablesId, Name = "Zwiebel" },
                new { Id = 98, GroceryCategoryId = freshAndCooledId, Name = "Butter" },
                new { Id = 99, GroceryCategoryId = freshAndCooledId, Name = "Camembert" },
                new { Id = 100, GroceryCategoryId = freshAndCooledId, Name = "Creme Fraiche" },
                new { Id = 101, GroceryCategoryId = freshAndCooledId, Name = "Eier" },
                new { Id = 102, GroceryCategoryId = freshAndCooledId, Name = "Feta" },
                new { Id = 103, GroceryCategoryId = freshAndCooledId, Name = "Fettarmer Joghurt" },
                new { Id = 104, GroceryCategoryId = freshAndCooledId, Name = "Frischkäse" },
                new { Id = 105, GroceryCategoryId = freshAndCooledId, Name = "Gouda" },
                new { Id = 106, GroceryCategoryId = freshAndCooledId, Name = "Griechischer Joghurt" },
                new { Id = 107, GroceryCategoryId = freshAndCooledId, Name = "Gyros" },
                new { Id = 108, GroceryCategoryId = freshAndCooledId, Name = "Hackfleisch" },
                new { Id = 109, GroceryCategoryId = freshAndCooledId, Name = "Hänchenbrustfilet" },
                new { Id = 110, GroceryCategoryId = freshAndCooledId, Name = "Hänchenschenkel" },
                new { Id = 111, GroceryCategoryId = freshAndCooledId, Name = "Joghurt" },
                new { Id = 112, GroceryCategoryId = freshAndCooledId, Name = "Kefir" },
                new { Id = 113, GroceryCategoryId = freshAndCooledId, Name = "Kochschinken" },
                new { Id = 114, GroceryCategoryId = freshAndCooledId, Name = "Kräuterquark" },
                new { Id = 115, GroceryCategoryId = freshAndCooledId, Name = "Milch 1.5%" },
                new { Id = 116, GroceryCategoryId = freshAndCooledId, Name = "Milch 3.5%" },
                new { Id = 117, GroceryCategoryId = freshAndCooledId, Name = "Mozarelle" },
                new { Id = 118, GroceryCategoryId = freshAndCooledId, Name = "Mozzarella" },
                new { Id = 119, GroceryCategoryId = freshAndCooledId, Name = "Quark Halbfettstufe" },
                new { Id = 120, GroceryCategoryId = freshAndCooledId, Name = "Räucher-Lachs" },
                new { Id = 121, GroceryCategoryId = freshAndCooledId, Name = "Salami" },
                new { Id = 122, GroceryCategoryId = freshAndCooledId, Name = "Schinken" },
                new { Id = 123, GroceryCategoryId = freshAndCooledId, Name = "Schlagsahne" },
                new { Id = 124, GroceryCategoryId = freshAndCooledId, Name = "Schlagssahne" },
                new { Id = 125, GroceryCategoryId = freshAndCooledId, Name = "Schmand" },
                new { Id = 126, GroceryCategoryId = freshAndCooledId, Name = "Speisequark Magerstufe" },
                new { Id = 127, GroceryCategoryId = freshAndCooledId, Name = "Süßrahmbutter" },
                new { Id = 128, GroceryCategoryId = freshAndCooledId, Name = "Wiener Würstchen" },
                new { Id = 129, GroceryCategoryId = frozenId, Name = "Shrimps" },
                new { Id = 130, GroceryCategoryId = foodId, Name = "Backin" },
                new { Id = 131, GroceryCategoryId = foodId, Name = "Basmati Reis" },
                new { Id = 132, GroceryCategoryId = foodId, Name = "Bourbon-Vanillezucker" },
                new { Id = 133, GroceryCategoryId = foodId, Name = "Brauner Zucker" },
                new { Id = 134, GroceryCategoryId = foodId, Name = "Couscous" },
                new { Id = 135, GroceryCategoryId = foodId, Name = "Dinkelmehl Type 630" },
                new { Id = 136, GroceryCategoryId = foodId, Name = "Dinkel-Vollkornmehl" },
                new { Id = 137, GroceryCategoryId = foodId, Name = "Essig" },
                new { Id = 138, GroceryCategoryId = foodId, Name = "Fusilli" },
                new { Id = 139, GroceryCategoryId = foodId, Name = "Gemüsebrühe" },
                new { Id = 140, GroceryCategoryId = foodId, Name = "Gnocchi" },
                new { Id = 141, GroceryCategoryId = foodId, Name = "Grießbrei" },
                new { Id = 142, GroceryCategoryId = foodId, Name = "Haferflocken" },
                new { Id = 143, GroceryCategoryId = foodId, Name = "Hefe" },
                new { Id = 144, GroceryCategoryId = foodId, Name = "Hörnchennudeln" },
                new { Id = 145, GroceryCategoryId = foodId, Name = "Hühnerbrühe" },
                new { Id = 146, GroceryCategoryId = foodId, Name = "Ketchup" },
                new { Id = 147, GroceryCategoryId = foodId, Name = "Kicherebsen" },
                new { Id = 148, GroceryCategoryId = foodId, Name = "Kidney-Bohnen" },
                new { Id = 149, GroceryCategoryId = foodId, Name = "Kokosraspel" },
                new { Id = 150, GroceryCategoryId = foodId, Name = "Lasagne" },
                new { Id = 151, GroceryCategoryId = foodId, Name = "Mais" },
                new { Id = 152, GroceryCategoryId = foodId, Name = "Mandeln" },
                new { Id = 153, GroceryCategoryId = foodId, Name = "Milchreis" },
                new { Id = 154, GroceryCategoryId = foodId, Name = "Natron" },
                new { Id = 155, GroceryCategoryId = foodId, Name = "Olivenöl" },
                new { Id = 156, GroceryCategoryId = foodId, Name = "Penne Rigate" },
                new { Id = 157, GroceryCategoryId = foodId, Name = "Pesto alla Genovese" },
                new { Id = 158, GroceryCategoryId = foodId, Name = "Pesto Rosto" },
                new { Id = 159, GroceryCategoryId = foodId, Name = "Puderzucker" },
                new { Id = 160, GroceryCategoryId = foodId, Name = "Reis" },
                new { Id = 161, GroceryCategoryId = foodId, Name = "Rote Linsen" },
                new { Id = 162, GroceryCategoryId = foodId, Name = "Sahnesteif" },
                new { Id = 163, GroceryCategoryId = foodId, Name = "Salz" },
                new { Id = 164, GroceryCategoryId = foodId, Name = "Schokoladen-Kuverüte" },
                new { Id = 165, GroceryCategoryId = foodId, Name = "Senf" },
                new { Id = 166, GroceryCategoryId = foodId, Name = "Sonnenblumenöl" },
                new { Id = 167, GroceryCategoryId = foodId, Name = "Spaghetti" },
                new { Id = 168, GroceryCategoryId = foodId, Name = "Speisestärke" },
                new { Id = 169, GroceryCategoryId = foodId, Name = "Spitzen-Langkorn-Reis" },
                new { Id = 170, GroceryCategoryId = foodId, Name = "Suppennudeln" },
                new { Id = 171, GroceryCategoryId = foodId, Name = "Tomaten passiert" },
                new { Id = 172, GroceryCategoryId = foodId, Name = "Tomatenmark" },
                new { Id = 173, GroceryCategoryId = foodId, Name = "Tortenguss" },
                new { Id = 174, GroceryCategoryId = foodId, Name = "Vanilin" },
                new { Id = 175, GroceryCategoryId = foodId, Name = "Weißbroattoast" },
                new { Id = 176, GroceryCategoryId = foodId, Name = "Weizenmehl 405" },
                new { Id = 177, GroceryCategoryId = foodId, Name = "Zartbitter-Kuvetüre" },
                new { Id = 178, GroceryCategoryId = foodId, Name = "Zucker" },
                new { Id = 179, GroceryCategoryId = spiecesId, Name = "Basilikum gerebelt" },
                new { Id = 180, GroceryCategoryId = spiecesId, Name = "Bohnenkraut" },
                new { Id = 181, GroceryCategoryId = spiecesId, Name = "Chili" },
                new { Id = 182, GroceryCategoryId = spiecesId, Name = "Curry" },
                new { Id = 183, GroceryCategoryId = spiecesId, Name = "Curry gemahlen" },
                new { Id = 184, GroceryCategoryId = spiecesId, Name = "Dillspitzen" },
                new { Id = 185, GroceryCategoryId = spiecesId, Name = "Kardamon" },
                new { Id = 186, GroceryCategoryId = spiecesId, Name = "Knoblauch granuliert" },
                new { Id = 187, GroceryCategoryId = spiecesId, Name = "Koriander gemahlen" },
                new { Id = 188, GroceryCategoryId = spiecesId, Name = "Kreuzkümmel gemahlen" },
                new { Id = 189, GroceryCategoryId = spiecesId, Name = "Kurkuma gemahlen" },
                new { Id = 190, GroceryCategoryId = spiecesId, Name = "Loorbeerblätter" },
                new { Id = 191, GroceryCategoryId = spiecesId, Name = "Majoran gerebelt" },
                new { Id = 192, GroceryCategoryId = spiecesId, Name = "Muskatnuss" },
                new { Id = 193, GroceryCategoryId = spiecesId, Name = "Oregano gerebelt" },
                new { Id = 194, GroceryCategoryId = spiecesId, Name = "Paprika Edelsüß" },
                new { Id = 195, GroceryCategoryId = spiecesId, Name = "Paprika Rosenscharf" },
                new { Id = 196, GroceryCategoryId = spiecesId, Name = "Rosmarin" },
                new { Id = 197, GroceryCategoryId = spiecesId, Name = "Thymian gerebelt" },
                new { Id = 198, GroceryCategoryId = spiecesId, Name = "Zimt gemahlen" },
                new { Id = 199, GroceryCategoryId = spiecesId, Name = "Zimtstangen" },
                new { Id = 200, GroceryCategoryId = sweetAndSaltyId, Name = "Walnüsse" },
                new { Id = 201, GroceryCategoryId = sweetAndSaltyId, Name = "Cashewkerne" },
                new { Id = 202, GroceryCategoryId = sweetAndSaltyId, Name = "Pistazien" },
                new { Id = 203, GroceryCategoryId = sweetAndSaltyId, Name = "Paranusskerne" },
                new { Id = 204, GroceryCategoryId = sweetAndSaltyId, Name = "Maronen" },
                new { Id = 205, GroceryCategoryId = sweetAndSaltyId, Name = "Macadamia" },
                new { Id = 206, GroceryCategoryId = sweetAndSaltyId, Name = "Pekannusskerne" },
                new { Id = 207, GroceryCategoryId = coffeeTeaCocoaId, Name = "Kondensmilch" },
                new { Id = 208, GroceryCategoryId = coffeeTeaCocoaId, Name = "Kokosmilch" },
                new { Id = 209, GroceryCategoryId = coffeeTeaCocoaId, Name = "Grüner Tee" },
                new { Id = 210, GroceryCategoryId = beveragesId, Name = "Apfelsaft" },
                new { Id = 211, GroceryCategoryId = beveragesId, Name = "Kirschsaft" },
                new { Id = 212, GroceryCategoryId = wineAndSpiritsId, Name = "Rotwein" }
                );
        }

        private static void SeedRecipeCategories(this ModelBuilder builder)
        {
            builder.Entity<RecipeCategory>().HasData(
                new { Id = 1, Name = "Backwaren", Abbreviation = "B" },
                new { Id = 2, Name = "Frühstück", Abbreviation = "F" },
                new { Id = 3, Name = "Hauptgericht", Abbreviation = "H" },
                new { Id = 4, Name = "Salat", Abbreviation = "Sa" },
                new { Id = 5, Name = "Sauce", Abbreviation = "Su" },
                new { Id = 6, Name = "Suppen", Abbreviation = "Sp" },
                new { Id = 7, Name = "Vorspeisen & Antipasti", Abbreviation = "V" },
                new { Id = 8, Name = "Dessert", Abbreviation = "D" }
            );
        }

        private static void SeedExampleRecipes(this ModelBuilder builder)
        {
            int recipe1Id = 1;
            int recipe2Id = 2;

            Recipe recipe1 = new Recipe
            {
                Id = recipe1Id,
                Title = "Example recipe 1",
                RecipeCategoryId = 1,
                Amount = 2.0,
                PortionUnit = PortionUnit.Cake,
                Time = 120,
                Vegetarian = true,
                Source = "Book xyz",
                Comment = "Dont' add to much water"
            };
            Recipe recipe2 = new Recipe
            {
                Id = recipe2Id,
                Title = "Example recipe 2",
                RecipeCategoryId = 2,
                Amount = 4.0,
                PortionUnit = PortionUnit.Portion,
                Time = 30,
                Vegetarian = false,
                Source = "https://www.",
            };

            builder.Entity<Recipe>().HasData(recipe1, recipe2);

            builder.Entity<InstructionStep>().HasData(
                new { Id = 1, RecipeId = recipe1Id, Text = "step 1" },
                new { Id = 2, RecipeId = recipe1Id, Text = "step 2" },
                new { Id = 3, RecipeId = recipe1Id, Text = "step 3" },
                new { Id = 4, RecipeId = recipe2Id, Text = "step 1" }
                );

            builder.Entity<RecipeGroceryItem>().HasData(
                new
                {
                    RecipeId = recipe1Id,
                    GroceryItemId = 1,
                    Amount = 5.0,
                    Measurementunit = MeasurementUnit.Kg,
                },
                new
                {
                    RecipeId = recipe1Id,
                    GroceryItemId = 3,
                    Amount = 5.0,
                    Measurementunit = MeasurementUnit.L,
                }
                );
        }
    }
}
