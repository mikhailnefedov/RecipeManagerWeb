import 'package:flutter/material.dart';

import '../../api/http_helper.dart';
import '../../models/recipe.dart';
import '../../models/recipe_category.dart';

class RecipeCategoryDropdown extends StatefulWidget {
  Recipe recipe;

  RecipeCategoryDropdown({
    Key? key,
    required this.recipe,
  }) : super(key: key);

  @override
  _RecipeCategoryDropdownState createState() => _RecipeCategoryDropdownState();
}

class _RecipeCategoryDropdownState extends State<RecipeCategoryDropdown> {
  late Recipe _recipe;
  late RecipeCategory? _recipeCategory;

  @override
  void initState() {
    super.initState();
    _recipe = widget.recipe;
  }

  @override
  Widget build(BuildContext context) {
    return FutureBuilder(
        future: createMenuItems(),
        builder: (context, snapshot) {
          if (snapshot.hasData) {
            _recipeCategory = snapshot.requireData
                .map((e) => e.value)
                .firstWhere((e) => e == _recipe.recipeCategory,
                    orElse: () => null);

            return DropdownButton(
              value: _recipeCategory,
              items: snapshot.requireData,
              onChanged: (value) {
                setState(() {
                  _recipe.recipeCategory = value!;
                });
              },
            );
          } else {
            return CircularProgressIndicator();
          }
        });
  }

  Future<List<DropdownMenuItem<RecipeCategory>>> createMenuItems() async {
    List<RecipeCategory> fetchedCategories =
        await HttpHelper.fetchRecipeCategories();

    return fetchedCategories.map((e) {
      return DropdownMenuItem<RecipeCategory>(
        value: e,
        child: Text(e.name),
      );
    }).toList();
  }
}
