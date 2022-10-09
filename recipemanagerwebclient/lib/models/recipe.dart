import 'package:recipemanagerwebclient/models/portion_unit.dart';
import 'package:recipemanagerwebclient/models/recipe_category.dart';

class Recipe {
  final int id;
  final String name;
  final double amount;
  final PortionUnit portionUnit;
  final int time;
  final bool vegetarian;
  final String source;
  final String comment;

  const Recipe({
    required this.id,
    required this.name,
    required this.amount,
    required this.portionUnit,
    required this.time,
    required this.vegetarian,
    required this.source,
    required this.comment,
  });

  factory Recipe.fromJson(Map<String, dynamic> json) {
    return Recipe(
      id: json['id'],
      name: json['name'],
      amount: json['amount'],
      portionUnit: PortionUnit.values.byName(json['portionUnit']),
      time: json['time'],
      vegetarian: json['vegetarian'],
      source: json['source'],
      comment: json['comment'],
    );
  }
}
