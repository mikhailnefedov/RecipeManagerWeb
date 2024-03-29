import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/api/shopping_list_repository.dart';
import 'package:recipemanagerwebclient/api/small_recipes_repository.dart';
import 'package:recipemanagerwebclient/gen_exports.dart';
import 'package:recipemanagerwebclient/models/meal.dart';
import 'package:recipemanagerwebclient/models/shopping_list.dart';
import 'package:recipemanagerwebclient/widgets/shopping_list/horizontal_recipe_picker.dart';
import 'package:recipemanagerwebclient/widgets/shopping_list/meal_row.dart';

import '../models/small_recipe.dart';
import '../widgets/header.dart';
import '../widgets/navigation_drawer.dart';

import 'package:http/http.dart' as http;

class ShoppingList extends StatefulWidget {
  static const route = '/shoppinglist';

  const ShoppingList({super.key});

  @override
  State<ShoppingList> createState() => _ShoppingListState();
}

class _ShoppingListState extends State<ShoppingList> {
  List<MealRow> _mealRows = [
    MealRow(date: DateTime.now()),
  ];
  int _additionalDays = 0;
  ShoppingListModel _shoppingList = ShoppingListModel(items: []);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      drawer: NavigationDrawer(),
      appBar: Header(),
      body: SingleChildScrollView(
        child: Column(
          children: [
            FutureBuilder<List<SmallRecipe>>(
              future: SmallRecipeRepository().fetchAll(),
              builder: (context, snapshot) {
                if (snapshot.hasData) {
                  return HorizontalRecipePicker(
                    recipes: snapshot.requireData,
                  );
                } else if (snapshot.hasError) {
                  return Text('${snapshot.error}');
                }
                return Center(child: const CircularProgressIndicator());
              },
            ),
            ..._mealRows.fold([], (previousValue, element) {
              List<Widget> widgets = previousValue.toList();
              widgets.add(Divider());
              widgets.add(element);
              return widgets;
            }),
            Divider(),
            IconButton(
                onPressed: () {
                  _additionalDays += 1;
                  setState(() {
                    _mealRows.add(
                      MealRow(
                        date:
                            DateTime.now().add(Duration(days: _additionalDays)),
                      ),
                    );
                  });
                },
                icon: Icon(Icons.add)),
            ElevatedButton(
              child: Text(AppLocalizations.of(context)!.createShoppingList),
              onPressed: () async {
                ShoppingListModel shoppingList = await createShoppingList();
                setState(() {
                  _shoppingList = shoppingList;
                });
              },
            ),
            SelectionArea(
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  ..._shoppingList.items
                      .map((e) => Text(
                          "${e.groceryCategory} - ${e.groceryItem} : ${e.amounts}"))
                      .toList(),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }

  Future<ShoppingListModel> createShoppingList() async {
    List<Meal> meals = _mealRows.fold<List<Meal>>([], (previousValue, element) {
      previousValue.addAll(element.getMeals());
      return previousValue;
    });
    var shoppingList = await ShoppingListRepository().post(meals);
    return ShoppingListModel.fromJson(shoppingList);
  }
}
