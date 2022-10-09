import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

import '../api/request_urls.dart';
import '../models/recipe.dart';
import '../widgets/header.dart';
import '../widgets/navigation_drawer.dart';

class RecipePage extends StatefulWidget {
  const RecipePage({Key? key}) : super(key: key);

  @override
  _RecipePageState createState() => _RecipePageState();
}

class _RecipePageState extends State<RecipePage> {
  late Future<Recipe> _recipe;

  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    Map arguments = ModalRoute.of(context)?.settings.arguments as Map;
    int recipeId = arguments["id"];

    return Scaffold(
      drawer: NavigationDrawer(),
      appBar: Header(),
      body: FutureBuilder<Recipe>(
        future: loadRecipe(recipeId),
        builder: (context, snapshot) {
          if (snapshot.hasData) {
            return Center(
              child: Text(snapshot.requireData.name),
            );
          } else {
            return CircularProgressIndicator();
          }
        },
      ),
    );
  }

  Future<Recipe> loadRecipe(int recipeId) async {
    final response =
        await http.get(Uri.parse("${RequestURL.recipes}/$recipeId"));

    if (response.statusCode == 200) {
      return Recipe.fromJson(jsonDecode(response.body));
    } else {
      throw Exception('Fail');
    }
  }
}
