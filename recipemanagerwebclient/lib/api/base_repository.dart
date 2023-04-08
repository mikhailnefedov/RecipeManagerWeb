import 'package:recipemanagerwebclient/api/web_client.dart';
import 'package:recipemanagerwebclient/models/base_model.dart';

import '../models/data_layer.dart';

abstract class BaseRepository<T extends BaseModel> {
  final WebClient webclient;
  final String route;

  const BaseRepository(
      {this.webclient = const WebClient(), required this.route});

  T fromJson(Map<String, dynamic> json) {
    if (T == GroceryCategory) {
      return GroceryCategory.fromJson(json) as T;
    } else if (T == GroceryItem) {
      return GroceryItem.fromJson(json) as T;
    } else if (T == Recipe) {
      return Recipe.fromJson(json) as T;
    } else if (T == SmallRecipe) {
      return SmallRecipe.fromJson(json) as T;
    } else if (T == RecipeCategory) {
      return RecipeCategory.fromJson(json) as T;
    } else {
      throw ArgumentError('Unable to deserialize json. Target class unknown');
    }
  }

  Future<List<T>> fetchAll() async {
    final response = await webclient.get(route);
    return (response as List).map((e) => fromJson(e)).toList();
  }

  Future<T> fetchById(int id) async {
    final response = await webclient.get("$route/$id");
    return fromJson(response);
  }

  Future<void> deleteById(int id) async {
    final response = await webclient.delete("$route/$id");
  }

  Future<T> add(BaseModel dto) async {
    final response = await webclient.post(route, dto);
    return fromJson(response);
  }

  Future<void> update(T model) async {
    final response = await webclient.update(route, model);
  }
}
