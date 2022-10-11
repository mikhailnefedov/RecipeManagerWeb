class CreateRecipeCategory {
  CreateRecipeCategory({
    required this.name,
    required this.abbreviation,
  });

  String name;
  String abbreviation;

  Map<String, dynamic> toJson() {
    return {
      'name': name,
      'abbreviation': abbreviation,
    };
  }
}
