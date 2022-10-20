import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/api/http_helper.dart';
import '../models/data_layer.dart';
import '../widgets/header.dart';
import '../widgets/navigation_drawer.dart';
import '../widgets/recipe/recipe_widgets.dart';

class RecipeView extends StatefulWidget {
  static const route = '/recipe';

  RecipeView({Key? key}) : super(key: key);

  @override
  State<RecipeView> createState() => _RecipeViewState();
}

class _RecipeViewState extends State<RecipeView> {
  List<DropdownMenuItem<RecipeCategory>> recipeCategories = [];
  List<DropdownMenuItem<PortionUnit>> portionUnits =
      PortionUnit.values.map((e) {
    return DropdownMenuItem<PortionUnit>(
      value: e,
      child: Text(e.name),
    );
  }).toList();

  late Recipe _recipe;
  late bool isNew;

  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    Map arguments = ModalRoute.of(context)?.settings.arguments as Map;
    isNew = arguments['isNew'] ?? false;
    if (isNew) {
      _recipe = Recipe();
    }
    int recipeId = arguments["id"] ?? 1;

    return Scaffold(
      drawer: NavigationDrawer(),
      appBar: Header(),
      floatingActionButton: IconButton(
          icon: Icon(Icons.save),
          onPressed: () {
            print(_recipe.toJson());
            _recipe.ingredients.add(Ingredient());
          }),
      body: FutureBuilder<Recipe>(
        future: isNew
            ? Future<Recipe>.value(Recipe())
            : HttpHelper.fetchRecipe(recipeId),
        builder: (context, snapshot) {
          if (snapshot.hasData) {
            _recipe = snapshot.requireData;

            return SingleChildScrollView(
              child: Center(
                child: Padding(
                  padding: const EdgeInsets.fromLTRB(8.0, 16.0, 8.0, 0.0),
                  child: Column(
                    children: [
                      RecipeHeader(
                        recipe: _recipe,
                      ),
                      Divider(),
                      IngredientTable(
                        recipe: _recipe,
                      ),
                      Divider(),
                      InstructionStepsList(recipe: _recipe),
                    ],
                  ),
                ),
              ),
            );
          } else {
            return Center(child: CircularProgressIndicator());
          }
        },
      ),
    );
  }
}
