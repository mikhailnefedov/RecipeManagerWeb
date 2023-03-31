import 'package:recipemanagerwebclient/api/base_repository.dart';
import '../models/recipe.dart';

class RecipeRepository extends BaseRepository<Recipe> {
  static const String _route = "recipes";

  const RecipeRepository() : super(route: _route);
}
