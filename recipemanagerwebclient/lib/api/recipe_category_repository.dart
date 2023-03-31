import 'package:recipemanagerwebclient/api/base_repository.dart';
import '../models/recipe_category.dart';

class RecipeCategoryRepository extends BaseRepository<RecipeCategory> {
  static const String _route = "recipecategories";

  const RecipeCategoryRepository() : super(route: _route);
}
