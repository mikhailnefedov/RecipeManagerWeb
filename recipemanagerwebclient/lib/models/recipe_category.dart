class RecipeCategory {
  final int id;
  final String abbreviation;
  final String name;

  const RecipeCategory({
    required this.id,
    required this.abbreviation,
    required this.name,
  });

  factory RecipeCategory.fromJson(Map<String, dynamic> json) {
    return RecipeCategory(
      id: json['id'],
      abbreviation: json['abbreviation'],
      name: json['name'],
    );
  }
}
