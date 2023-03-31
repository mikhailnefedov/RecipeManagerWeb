import 'package:recipemanagerwebclient/api/web_client.dart';
import 'package:recipemanagerwebclient/models/base_model.dart';

import '../models/grocery_category.dart';

abstract class BaseRepository<T extends BaseModel> {
  final WebClient webclient;
  final String route;

  const BaseRepository(
      {this.webclient = const WebClient(), required this.route});

  T fromJson(Map<String, dynamic> json) {
    if (T == GroceryCategory) {
      return GroceryCategory.fromJson(json) as T;
    } else {
      throw ArgumentError('Unable to deserialize json. Target class unknown');
    }
  }

  Future<List<T>> fetchAll() async {
    final response = await webclient.get(route);
    return (response as List).map((e) => fromJson(e)).toList();
  }

  Future<T> fetchById(String id) async {
    final response = await webclient.get("$route/$id");
    return fromJson(response);
  }
}
