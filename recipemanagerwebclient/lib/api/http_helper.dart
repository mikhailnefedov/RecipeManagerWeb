import 'dart:convert';
import 'dart:html';

import '../models/data_layer.dart';
import 'package:http/http.dart' as http;

//TODO: Refactor to n-service layer architecture
class HttpHelper {
  static const String _authority = "https://localhost:7287/api/";

  static const String _recipeCategories = "${_authority}recipecategories";
  static const String _groceryCategories = "${_authority}grocerycategories";
  static const String _groceryItems = "${_authority}groceryitems";
  static const String _recipes = "${_authority}recipes";
  static const String _smallRecipes = "${_authority}recipes/smallRecipes";

  static Future<List<RecipeCategory>> fetchRecipeCategories() async {
    final response = await http.get(Uri.parse(_recipeCategories));

    if (response.statusCode == HttpStatus.ok) {
      final map = jsonDecode(response.body);
      return (map as List).map((e) => RecipeCategory.fromJson(e)).toList();
    } else {
      throw Exception('Fail');
    }
  }

  static Future<List<GroceryItem>> fetchGroceryItems() async {
    final response = await http.get(Uri.parse(_groceryItems));

    if (response.statusCode == HttpStatus.ok) {
      final map = jsonDecode(response.body);
      return (map as List).map((e) => GroceryItem.fromJson(e)).toList();
    } else {
      throw Exception('Fail');
    }
  }

  static Future<Recipe> fetchRecipe(int recipeId) async {
    final response = await http.get(Uri.parse("$_recipes/$recipeId"));

    if (response.statusCode == HttpStatus.ok) {
      return Recipe.fromJson(jsonDecode(response.body));
    } else {
      throw Exception('Fail');
    }
  }

  static Future<List<SmallRecipe>> fetchSmallRecipes() async {
    final response = await http.get(Uri.parse(_smallRecipes));

    if (response.statusCode == HttpStatus.ok) {
      final map = jsonDecode(response.body);
      return (map as List).map((e) => SmallRecipe.fromJson(e)).toList();
    } else {
      throw Exception('Fail');
    }
  }

  static Future<List<GroceryCategory>> fetchGroceryCategories() async {
    final response = await http.get(Uri.parse(_groceryCategories));

    if (response.statusCode == HttpStatus.ok) {
      final map = jsonDecode(response.body);
      return (map as List).map((e) => GroceryCategory.fromJson(e)).toList();
    } else {
      throw Exception('Fail');
    }
  }
}
