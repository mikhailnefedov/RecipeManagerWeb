import 'package:recipemanagerwebclient/models/portion_unit.dart';
import 'package:recipemanagerwebclient/models/recipe_category.dart';

class SmallRecipe {
  final int id;
  final String name;
  final RecipeCategory recipeCategory;
  final double amount;
  final PortionUnit portionUnit;
  final int time;
  final bool vegetarian;

  const SmallRecipe({
    required this.id,
    required this.name,
    required this.recipeCategory,
    required this.amount,
    required this.portionUnit,
    required this.time,
    required this.vegetarian,
  });

  factory SmallRecipe.fromJson(Map<String, dynamic> json) {
    return SmallRecipe(
      id: json['id'],
      name: json['name'],
      recipeCategory: RecipeCategory.fromJson(json['recipeCategory']),
      amount: json['amount'],
      portionUnit: PortionUnit.values.byName(json['portionUnit']),
      time: json['time'],
      vegetarian: json['vegetarian'],
    );
  }
}
