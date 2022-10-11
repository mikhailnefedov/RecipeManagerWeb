import 'dart:ui';

import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/pages/create_recipe_page.dart';
import 'package:recipemanagerwebclient/pages/grocery_categories.dart';
import 'package:recipemanagerwebclient/pages/grocery_items.dart';
import 'package:recipemanagerwebclient/pages/recipe_categories.dart';
import 'package:recipemanagerwebclient/pages/recipe_page.dart';
import 'package:recipemanagerwebclient/pages/shopping_list.dart';

import 'home_page.dart';
import 'pages/recipes.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      routes: {
        '/': (context) => HomePage(),
        '/recipes': (context) => Recipes(),
        '/shoppinglist': (context) => ShoppingList(),
        '/recipecategories': (context) => RecipeCategories(),
        '/groceryitems': (context) => GroceryItems(),
        '/grocerycategories': (context) => GroceryCategories(),
        '/recipe': (context) => RecipePage(),
        '/createrecipe': (context) => CreateRecipePage(),
      },
      initialRoute: '/',
    );
  }
}
