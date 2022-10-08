class GroceryItem {
  final int id;
  final String name;
  final int groceryCategoryId;
  final String groceryCategoryName;

  const GroceryItem(
      {required this.id,
      required this.name,
      required this.groceryCategoryId,
      required this.groceryCategoryName});

  factory GroceryItem.fromJson(Map<String, dynamic> json) {
    return GroceryItem(
      id: json['id'],
      name: json['name'],
      groceryCategoryId: json['groceryCategoryId'],
      groceryCategoryName: json['groceryCategoryName'],
    );
  }
}
