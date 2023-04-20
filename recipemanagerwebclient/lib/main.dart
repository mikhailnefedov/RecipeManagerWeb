import 'package:flutter/material.dart';
import 'package:flutter_localizations/flutter_localizations.dart';
import 'package:flutter_gen/gen_l10n/app_localizations.dart';

import 'home_page.dart';
import 'views/views.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'RecipeManagerWeb',
      localizationsDelegates: AppLocalizations.localizationsDelegates,
      supportedLocales: [Locale('de')],
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      routes: {
        '/': (context) => HomePage(),
        RecipesLoader.route: (context) => RecipesLoader(),
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
