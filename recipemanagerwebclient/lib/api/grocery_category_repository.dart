import 'package:recipemanagerwebclient/api/base_repository.dart';
import '../models/grocery_category.dart';

class GroceryCategoryRepository extends BaseRepository<GroceryCategory> {
  static const String _route = "grocerycategories";

  const GroceryCategoryRepository() : super(route: _route);
}
