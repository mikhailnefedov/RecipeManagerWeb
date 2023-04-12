import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/api/recipe_repository.dart';
import 'package:recipemanagerwebclient/dtos/create_recipe.dart';
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

  late RecipeRepository _recipeRepository;
  late Recipe _recipe;
  late bool isNew;

  @override
  void initState() {
    super.initState();
    _recipeRepository = RecipeRepository();
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
            if (isNew) {
              addRecipe();
            } else {
              updateRecipe();
            }
          }),
      body: FutureBuilder<Recipe>(
        future: isNew
            ? Future<Recipe>.value(Recipe())
            : _recipeRepository.fetchById(recipeId),
        builder: (context, snapshot) {
          if (snapshot.hasData) {
            _recipe = snapshot.requireData;

            return SingleChildScrollView(
              child: Center(
                child: Padding(
                  padding: const EdgeInsets.fromLTRB(8.0, 16.0, 8.0, 0.0),
                  child: Column(
                    children: [
                      LayoutBuilder(
                        builder: (context, constraints) {
                          return SizedBox(
                            width: MediaQuery.of(context).size.width * 0.7,
                            child: RecipeHeader(
                              recipe: _recipe,
                            ),
                          );
                        },
                      ),
                      Divider(),
                      Row(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Expanded(
                            child: InstructionStepsList(recipe: _recipe),
                          ),
                          Expanded(
                            child: IngredientTable(
                              recipe: _recipe,
                            ),
                          ),
                        ],
                      ),
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

  void addRecipe() async {
    CreateRecipe dto = CreateRecipe(
      name: _recipe.name,
      recipeCategoryId: _recipe.recipeCategory.id,
      amount: _recipe.amount,
      portionUnit: _recipe.portionUnit,
      time: _recipe.time,
      vegetarian: _recipe.vegetarian,
      ingredients: _recipe.ingredients
          .map((e) => CreateIngredient(
              groceryItemId: e.groceryItemId,
              amount: e.amount,
              measurement: e.measurement))
          .toList(),
      instructions: _recipe.instructions
          .map((e) => CreateInstruction(text: e.text))
          .toList(),
      source: _recipe.source,
      comment: _recipe.comment,
    );

    Recipe recipe = await _recipeRepository.add(dto);
    Navigator.pop(context, recipe);
  }

  void updateRecipe() async {
    await _recipeRepository.update(_recipe);
    Navigator.pop(context, _recipe);
  }
}
