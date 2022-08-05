using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeManagerWeb.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GroceryCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Obst und Gemüse" });

            migrationBuilder.InsertData(
                table: "GroceryCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Frische und Kühlung" });

            migrationBuilder.InsertData(
                table: "GroceryCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Tiefkühl" });

            migrationBuilder.InsertData(
                table: "GroceryCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Nahrungsmittel" });

            migrationBuilder.InsertData(
                table: "GroceryCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Gewürze" });

            migrationBuilder.InsertData(
                table: "GroceryCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Süßes und Salziges" });

            migrationBuilder.InsertData(
                table: "GroceryCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "Kaffee, Tee & Kakao" });

            migrationBuilder.InsertData(
                table: "GroceryCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "Getränke" });

            migrationBuilder.InsertData(
                table: "GroceryCategories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, "Wein & Spirituosen" });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[] { 1, "B", "Backwaren" });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[] { 2, "F", "Frühstück" });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[] { 3, "H", "Hauptgericht" });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[] { 4, "Sa", "Salat" });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[] { 5, "Su", "Sauce" });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[] { 6, "Sp", "Suppen" });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[] { 7, "V", "Vorspeisen & Antipasti" });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[] { 8, "D", "Dessert" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 1, 1, "Ananas" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 2, 1, "Apfel" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 3, 1, "Apfelsine" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 4, 1, "Aprikose" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 5, 1, "Aubergine" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 6, 1, "Banane" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 7, 1, "Birne" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 8, 1, "Blattsalat" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 9, 1, "Blaubeeren" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 10, 1, "Blumenkohl" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 11, 1, "Brokkoli" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 12, 1, "Brombeere" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 13, 1, "Clementine" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 14, 1, "Cranberries" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 15, 1, "Dattel" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 16, 1, "Drachenfrucht" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 17, 1, "Eisbergsalat" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 18, 1, "Erbse" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 19, 1, "Erdbeere" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 20, 1, "Feige" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 21, 1, "Feldsalat" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 22, 1, "Fenchel" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 23, 1, "Granatapfel" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 24, 1, "Grapefruit" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 25, 1, "Grünkohl" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 26, 1, "Guave" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 27, 1, "Gurke" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 28, 1, "Hagebutte" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 29, 1, "Heidelbeere" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 30, 1, "Himbeere" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 31, 1, "Holunderbeere" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 32, 1, "Honigmelone" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 33, 1, "Ingwer" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 34, 1, "Johannisbeere" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 35, 1, "Kaki" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 36, 1, "Kaktusfeige" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 37, 1, "Kartoffeln" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 38, 1, "Kirsche" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 39, 1, "Kiwi" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 40, 1, "Knoblauch" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 41, 1, "Kohlrabi" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 42, 1, "Kohlrübe" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 43, 1, "Kokosnuss" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 44, 1, "Kürbis" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 45, 1, "Lauchzwiebeln" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 46, 1, "Limette" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 47, 1, "Linsen" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 48, 1, "Litschi" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 49, 1, "Mandarine" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 50, 1, "Mango" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 51, 1, "Maracuja" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 52, 1, "Melonen" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 53, 1, "Mirabelle" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 54, 1, "Möhre" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 55, 1, "Nektarine" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 56, 1, "Orange" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 57, 1, "Pampelmuse" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 58, 1, "Papaya" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 59, 1, "Paprika" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 60, 1, "Passionsfrucht" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 61, 1, "Pastinake" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 62, 1, "Petersilie" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 63, 1, "Pfirsich" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 64, 1, "Pflaume" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 65, 1, "Physalis" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 66, 1, "Porree" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 67, 1, "Preiselbeere" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 68, 1, "Puffbohnen" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 69, 1, "Quitte" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 70, 1, "Radieschen" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 71, 1, "Rettich" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 72, 1, "Rhabarber" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 73, 1, "Rote Rübe" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 74, 1, "Rotkohl" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 75, 1, "Salatgurke" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 76, 1, "Sanddornbeere" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 77, 1, "Sauerkirsche" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 78, 1, "Schalotten" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 79, 1, "Schnittlauch" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 80, 1, "Sellerie" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 81, 1, "Sojabohnen" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 82, 1, "Spinat" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 83, 1, "Stachelbeere" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 84, 1, "Suppengrün" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 85, 1, "Süßkartoffeln" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 86, 1, "Süßkirsche" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 87, 1, "Tomate" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 88, 1, "Tomate (klein)" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 89, 1, "Traube" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 90, 1, "Wassermelone" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 91, 1, "Weintraube" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 92, 1, "Weißkohl" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 93, 1, "Zitrone" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 94, 1, "Zucchini" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 95, 1, "Zuckermelone" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 96, 1, "Zwetschge" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 97, 1, "Zwiebel" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 98, 2, "Butter" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 99, 2, "Camembert" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 100, 2, "Creme Fraiche" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 101, 2, "Eier" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 102, 2, "Feta" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 103, 2, "Fettarmer Joghurt" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 104, 2, "Frischkäse" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 105, 2, "Gouda" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 106, 2, "Griechischer Joghurt" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 107, 2, "Gyros" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 108, 2, "Hackfleisch" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 109, 2, "Hänchenbrustfilet" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 110, 2, "Hänchenschenkel" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 111, 2, "Joghurt" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 112, 2, "Kefir" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 113, 2, "Kochschinken" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 114, 2, "Kräuterquark" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 115, 2, "Milch 1.5%" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 116, 2, "Milch 3.5%" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 117, 2, "Mozarelle" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 118, 2, "Mozzarella" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 119, 2, "Quark Halbfettstufe" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 120, 2, "Räucher-Lachs" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 121, 2, "Salami" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 122, 2, "Schinken" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 123, 2, "Schlagsahne" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 124, 2, "Schlagssahne" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 125, 2, "Schmand" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 126, 2, "Speisequark Magerstufe" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 127, 2, "Süßrahmbutter" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 128, 2, "Wiener Würstchen" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 129, 3, "Shrimps" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 130, 4, "Backin" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 131, 4, "Basmati Reis" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 132, 4, "Bourbon-Vanillezucker" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 133, 4, "Brauner Zucker" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 134, 4, "Couscous" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 135, 4, "Dinkelmehl Type 630" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 136, 4, "Dinkel-Vollkornmehl" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 137, 4, "Essig" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 138, 4, "Fusilli" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 139, 4, "Gemüsebrühe" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 140, 4, "Gnocchi" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 141, 4, "Grießbrei" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 142, 4, "Haferflocken" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 143, 4, "Hefe" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 144, 4, "Hörnchennudeln" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 145, 4, "Hühnerbrühe" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 146, 4, "Ketchup" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 147, 4, "Kicherebsen" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 148, 4, "Kidney-Bohnen" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 149, 4, "Kokosraspel" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 150, 4, "Lasagne" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 151, 4, "Mais" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 152, 4, "Mandeln" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 153, 4, "Milchreis" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 154, 4, "Natron" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 155, 4, "Olivenöl" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 156, 4, "Penne Rigate" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 157, 4, "Pesto alla Genovese" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 158, 4, "Pesto Rosto" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 159, 4, "Puderzucker" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 160, 4, "Reis" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 161, 4, "Rote Linsen" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 162, 4, "Sahnesteif" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 163, 4, "Salz" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 164, 4, "Schokoladen-Kuverüte" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 165, 4, "Senf" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 166, 4, "Sonnenblumenöl" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 167, 4, "Spaghetti" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 168, 4, "Speisestärke" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 169, 4, "Spitzen-Langkorn-Reis" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 170, 4, "Suppennudeln" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 171, 4, "Tomaten passiert" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 172, 4, "Tomatenmark" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 173, 4, "Tortenguss" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 174, 4, "Vanilin" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 175, 4, "Weißbroattoast" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 176, 4, "Weizenmehl 405" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 177, 4, "Zartbitter-Kuvetüre" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 178, 4, "Zucker" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 179, 5, "Basilikum gerebelt" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 180, 5, "Bohnenkraut" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 181, 5, "Chili" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 182, 5, "Curry" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 183, 5, "Curry gemahlen" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 184, 5, "Dillspitzen" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 185, 5, "Kardamon" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 186, 5, "Knoblauch granuliert" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 187, 5, "Koriander gemahlen" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 188, 5, "Kreuzkümmel gemahlen" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 189, 5, "Kurkuma gemahlen" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 190, 5, "Loorbeerblätter" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 191, 5, "Majoran gerebelt" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 192, 5, "Muskatnuss" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 193, 5, "Oregano gerebelt" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 194, 5, "Paprika Edelsüß" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 195, 5, "Paprika Rosenscharf" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 196, 5, "Rosmarin" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 197, 5, "Thymian gerebelt" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 198, 5, "Zimt gemahlen" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 199, 5, "Zimtstangen" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 200, 6, "Walnüsse" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 201, 6, "Cashewkerne" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 202, 6, "Pistazien" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 203, 6, "Paranusskerne" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 204, 6, "Maronen" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 205, 6, "Macadamia" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 206, 6, "Pekannusskerne" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 207, 7, "Kondensmilch" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 208, 7, "Kokosmilch" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 209, 7, "Grüner Tee" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 210, 8, "Apfelsaft" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 211, 8, "Kirschsaft" });

            migrationBuilder.InsertData(
                table: "GroceryItems",
                columns: new[] { "Id", "GroceryCategoryId", "Name" },
                values: new object[] { 212, 9, "Rotwein" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Amount", "Comment", "PortionUnit", "RecipeCategoryId", "Source", "Time", "Title", "Vegetarian" },
                values: new object[] { 1, 2.0, "Dont' add to much water", 2, 1, "Book xyz", 120, "Example recipe 1", true });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Amount", "Comment", "PortionUnit", "RecipeCategoryId", "Source", "Time", "Title", "Vegetarian" },
                values: new object[] { 2, 4.0, null, 3, 2, "https://www.", 30, "Example recipe 2", false });

            migrationBuilder.InsertData(
                table: "InstructionSteps",
                columns: new[] { "Id", "RecipeId", "Text" },
                values: new object[] { 1, 1, "step 1" });

            migrationBuilder.InsertData(
                table: "InstructionSteps",
                columns: new[] { "Id", "RecipeId", "Text" },
                values: new object[] { 2, 1, "step 2" });

            migrationBuilder.InsertData(
                table: "InstructionSteps",
                columns: new[] { "Id", "RecipeId", "Text" },
                values: new object[] { 3, 1, "step 3" });

            migrationBuilder.InsertData(
                table: "InstructionSteps",
                columns: new[] { "Id", "RecipeId", "Text" },
                values: new object[] { 4, 2, "step 1" });

            migrationBuilder.InsertData(
                table: "RecipeGroceryItems",
                columns: new[] { "GroceryItemId", "RecipeId", "Amount", "Measurementunit" },
                values: new object[] { 1, 1, 5.0, 0 });

            migrationBuilder.InsertData(
                table: "RecipeGroceryItems",
                columns: new[] { "GroceryItemId", "RecipeId", "Amount", "Measurementunit" },
                values: new object[] { 3, 1, 5.0, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "InstructionSteps",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InstructionSteps",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InstructionSteps",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InstructionSteps",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RecipeGroceryItems",
                keyColumns: new[] { "GroceryItemId", "RecipeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeGroceryItems",
                keyColumns: new[] { "GroceryItemId", "RecipeId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "GroceryCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GroceryCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GroceryCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GroceryCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "GroceryCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "GroceryCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "GroceryCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "GroceryCategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GroceryItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GroceryCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
