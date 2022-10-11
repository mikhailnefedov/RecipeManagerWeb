class CreateGroceryCategory {
  CreateGroceryCategory({
    required this.name,
  });

  String name;

  Map<String, dynamic> toJson() {
    return {
      'name': name,
    };
  }
}
