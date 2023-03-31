import 'package:recipemanagerwebclient/api/base_repository.dart';
import '../models/grocery_item.dart';

class GroceryItemRepository extends BaseRepository<GroceryItem> {
  static const String _route = "groceryitems";

  const GroceryItemRepository() : super(route: _route);
}
