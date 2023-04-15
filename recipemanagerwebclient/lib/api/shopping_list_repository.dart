import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:recipemanagerwebclient/api/web_client.dart';

import '../models/meal.dart';

class ShoppingListRepository {
  String _route = "ShoppingList";

  Future<dynamic> post(List<Meal> meals) async {
    final response = await http.post(
      Uri.parse(WebClient.host + _route),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: jsonEncode(meals.map((e) => e.toJson()).toList()),
    );
    return json.decode(response.body);
  }
}
