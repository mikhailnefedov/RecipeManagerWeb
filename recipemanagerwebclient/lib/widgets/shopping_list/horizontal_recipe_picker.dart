import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/api/small_recipes_repository.dart';
import 'package:recipemanagerwebclient/models/data_layer.dart';

import '../../models/meal.dart';

class HorizontalRecipePicker extends StatefulWidget {
  HorizontalRecipePicker({Key? key, required this.recipes}) : super(key: key);

  List<SmallRecipe> recipes;

  @override
  State<HorizontalRecipePicker> createState() => _HorizontalRecipePickerState();
}

class _HorizontalRecipePickerState extends State<HorizontalRecipePicker> {
  SmallRecipeRepository _smallRecipeRepository = SmallRecipeRepository();
  TextEditingController _searchController = TextEditingController(text: "");
  late List<SmallRecipe> _recipes;
  late List<SmallRecipe> _filteredRecipes;

  @override
  void initState() {
    super.initState();
    _recipes = widget.recipes;
    _filteredRecipes = _recipes;
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Container(
          width: 400,
          child: TextFormField(
            controller: _searchController,
            decoration: InputDecoration(
              labelText: "Suche nach Rezept",
              prefixIcon: Icon(Icons.search),
            ),
            onChanged: (value) {
              setState(() {
                _filteredRecipes = _recipes
                    .where((element) => element.name.contains(value))
                    .toList();
              });
            },
          ),
        ),
        SizedBox(
          height: 10,
        ),
        Container(
          height: 50,
          child: ListView.builder(
            itemCount: _filteredRecipes.length,
            scrollDirection: Axis.horizontal,
            itemBuilder: (context, index) {
              var recipe = _filteredRecipes[index];
              return Draggable<Meal>(
                data: Meal(
                    recipeId: recipe.id,
                    recipeName: recipe.name,
                    requestedAmount: recipe.amount,
                    portionUnit: recipe.portionUnit),
                feedback: Container(
                  height: 100,
                  width: 200,
                  child: Text(recipe.name,
                      style: TextStyle(
                        decoration: TextDecoration.none,
                      )),
                ),
                child: Padding(
                  padding: EdgeInsets.only(left: 5.0, right: 5.0),
                  child: Container(
                    decoration: BoxDecoration(
                      border: Border.all(color: Colors.black),
                      borderRadius: BorderRadius.circular(5),
                    ),
                    padding: EdgeInsets.all(5),
                    child: Column(
                      children: [
                        Text(recipe.name),
                        Text("${recipe.amount} ${recipe.portionUnit.name}"),
                      ],
                    ),
                  ),
                ),
              );
            },
          ),
        ),
      ],
    );
  }
}
