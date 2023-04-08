import 'package:flutter/material.dart';

import 'home_page.dart';
import 'views/recipes.dart';
import 'views/views.dart';

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
        Recipes.route: (context) => Recipes(),
        ShoppingList.route: (context) => ShoppingList(),
        RecipeCategoriesMain.route: (context) => RecipeCategoriesMain(),
        GroceryItems.route: (context) => GroceryItems(),
        GroceryCategoriesMain.route: (context) => GroceryCategoriesMain(),
        RecipeView.route: (context) => RecipeView(),
      },
      initialRoute: '/',
    );
  }
}
