class GroceryCategory {
  final int id;
  final String name;

  const GroceryCategory({
    required this.id,
    required this.name,
  });

  factory GroceryCategory.fromJson(Map<String, dynamic> json) {
    return GroceryCategory(
      id: json['id'],
      name: json['name'],
    );
  }
}
