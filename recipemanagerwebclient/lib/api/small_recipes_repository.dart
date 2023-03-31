import 'package:recipemanagerwebclient/api/base_repository.dart';
import '../models/small_recipe.dart';

class SmallRecipeRepository extends BaseRepository<SmallRecipe> {
  static const String _route = "recipes/smallRecipes";

  const SmallRecipeRepository() : super(route: _route);
}
