import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/api/http_helper.dart';
import 'package:recipemanagerwebclient/models/recipe_category.dart';
import 'package:recipemanagerwebclient/widgets/tables/recipe_category_table.dart';

import '../widgets/header.dart';
import '../widgets/navigation_drawer.dart';

import '../widgets/popups/create_recipe_category_popup.dart';

class RecipeCategories extends StatefulWidget {
  const RecipeCategories({super.key});

  @override
  State<RecipeCategories> createState() => _RecipeCategoriesState();
}

class _RecipeCategoriesState extends State<RecipeCategories> {
  late Future<List<RecipeCategory>> categories;

  @override
  void initState() {
    super.initState();
    categories = HttpHelper.fetchRecipeCategories();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      drawer: NavigationDrawer(),
      appBar: Header(),
      body: Column(
        children: [
          SizedBox(
            height: 16,
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: [
              ElevatedButton.icon(
                icon: Icon(Icons.add),
                label: Text("Rezeptkategorie hinzufügen"),
                onPressed: () {
                  showDialog(
                    context: context,
                    builder: (context) => CreateRecipeCategoryPopup(),
                  );
                },
              ),
            ],
          ),
          Divider(),
          FutureBuilder<List<RecipeCategory>>(
            future: categories,
            builder: (context, snapshot) {
              if (snapshot.hasData) {
                return RecipeCategoryTable(
                  categories: snapshot.requireData,
                );
              } else if (snapshot.hasError) {
                return Text('${snapshot.error}');
              }
              return const CircularProgressIndicator();
            },
          ),
        ],
      ),
    );
  }
}
