import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/models/data_layer.dart';
import 'package:recipemanagerwebclient/views/recipe_card.dart';
import 'package:recipemanagerwebclient/views/recipe_view.dart';
import 'package:recipemanagerwebclient/views/recipes_search_parameters.dart';

class RecipesView extends StatefulWidget {
  RecipesView({Key? key, required this.recipes, this.recipeSearchParameters})
      : super(key: key);

  List<SmallRecipe> recipes;
  RecipeSearchParameters? recipeSearchParameters;

  @override
  _RecipesViewState createState() => _RecipesViewState();
}

class _RecipesViewState extends State<RecipesView> {
  late List<SmallRecipe> _recipes;
  late RecipeSearchParameters _recipeSearchParameters;
  late TextEditingController _nameController;
  late TextEditingController _categoryController;
  late List<SmallRecipe> _filteredRecipes;

  @override
  void initState() {
    super.initState();
    _recipes = widget.recipes;
    _recipeSearchParameters =
        widget.recipeSearchParameters ?? RecipeSearchParameters();
    _nameController = TextEditingController(text: _recipeSearchParameters.name);
    _categoryController =
        TextEditingController(text: _recipeSearchParameters.recipeCategory);

    _filterRecipes();
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        SizedBox(
          height: 16,
        ),
        SizedBox(
          width: MediaQuery.of(context).size.width * 0.5,
          child: ElevatedButton.icon(
            icon: Icon(Icons.add),
            label: Text("Rezepte hinzufügen"),
            onPressed: () {
              Navigator.pushNamed(
                context,
                RecipeView.route,
                arguments: {"isNew": true},
              ).then((value) {
                if (value != null) {
                  SmallRecipe newRecipe =
                      Recipe.convertToSmallRecipe(value as Recipe);
                  setState(() {
                    _recipes.add(newRecipe);
                    _filterRecipes();
                  });
                }
              });
            },
          ),
        ),
        SizedBox(
          width: MediaQuery.of(context).size.width * 0.5,
          child: Row(
            children: [
              Expanded(
                child: Padding(
                  padding: const EdgeInsets.only(left: 5, right: 5),
                  child: TextFormField(
                    controller: _nameController,
                    decoration: InputDecoration(
                      labelText: "Filtere nach Name",
                      prefixIcon: Icon(Icons.search),
                    ),
                    onChanged: (value) {
                      setState(() {
                        _recipeSearchParameters.name = value;
                        _filterRecipes();
                      });
                    },
                  ),
                ),
              ),
              Expanded(
                child: Padding(
                  padding: const EdgeInsets.only(left: 5, right: 5),
                  child: TextFormField(
                    controller: _categoryController,
                    decoration: InputDecoration(
                      labelText: "Filtere nach Kategorie",
                      prefixIcon: Icon(Icons.search),
                    ),
                    onChanged: (value) {
                      setState(() {
                        _recipeSearchParameters.recipeCategory = value;
                        _filterRecipes();
                      });
                    },
                  ),
                ),
              ),
              Text("Max. Zeit:"),
              Slider(
                value: _recipeSearchParameters.maxTime.toDouble(),
                min: 0,
                max: 300,
                divisions: 300 / 30 as int,
                label: "${_recipeSearchParameters.maxTime} min",
                onChanged: (value) {
                  setState(() {
                    _recipeSearchParameters.maxTime = value.toInt();
                    _filterRecipes();
                  });
                },
              ),
            ],
          ),
        ),
        Divider(),
        Expanded(
          child: GridView.builder(
            padding: EdgeInsets.only(left: 20, right: 20),
            shrinkWrap: true,
            gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
              crossAxisCount: 4,
              crossAxisSpacing: 20,
              mainAxisSpacing: 8,
              childAspectRatio: 2,
            ),
            itemCount: _filteredRecipes.length,
            scrollDirection: Axis.vertical,
            itemBuilder: (BuildContext context, int index) {
              return Padding(
                padding: (index % 2) == 0
                    ? EdgeInsets.only(bottom: 10)
                    : EdgeInsets.only(top: 10),
                child: RecipeCard(
                  recipe: _filteredRecipes[index],
                ),
              );
            },
          ),
        ),
      ],
    );
  }

  void _filterRecipes() {
    setState(() {
      _filteredRecipes = _recipes
          .where((recipe) =>
              recipe.name.contains(_recipeSearchParameters.name) &&
              recipe.recipeCategory.name
                  .contains(_recipeSearchParameters.recipeCategory) &&
              recipe.time < _recipeSearchParameters.maxTime)
          .toList();
    });
  }
}
