class ShoppingListModel {
  List<ShoppingListItem> items;

  ShoppingListModel({
    required this.items,
  });

  factory ShoppingListModel.fromJson(Map<String, dynamic> json) {
    List<dynamic> shoppingListItems = json["items"];
    return ShoppingListModel(
        items: shoppingListItems
            .map(
              (e) => ShoppingListItem.fromJson(e),
            )
            .toList());
  }
}

class ShoppingListItem {
  String groceryItem;
  String groceryCategory;
  Map<String, dynamic> amounts;

  ShoppingListItem({
    required this.groceryItem,
    required this.groceryCategory,
    required this.amounts,
  });

  factory ShoppingListItem.fromJson(Map<String, dynamic> json) {
    return ShoppingListItem(
      groceryItem: json["groceryItem"],
      groceryCategory: json["groceryCategory"],
      amounts: json["amounts"],
    );
  }
}
