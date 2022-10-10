import 'package:recipemanagerwebclient/models/measurement_unit.dart';

import '../models/portion_unit.dart';

class CreateRecipe {
  String name;
  int recipeCategoryId;
  double amount;
  PortionUnit portionUnit;
  int time;
  bool vegetarian;
  List<CreateIngredient> ingredients;
  List<String> instructions;
  String source;
  String comment;

  CreateRecipe({
    this.name = '',
    this.recipeCategoryId = 1,
    this.amount = 0.0,
    this.portionUnit = PortionUnit.Portion,
    this.time = 0,
    this.vegetarian = false,
    this.ingredients = const [],
    this.instructions = const [],
    this.source = '',
    this.comment = '',
  });

  Map<String, dynamic> toJson() {
    return {
      'name': name,
      'recipeCategoryId': recipeCategoryId,
      'amount': amount,
      'portionUnit': portionUnit.name,
      'time': time,
      'vegetarian': vegetarian,
      'ingredients': ingredients.map((e) => e.toJson()).toList(),
      'instructions': instructions,
      'source': source,
      'comment': comment,
    };
  }
}

class CreateIngredient {
  int groceryItemId;
  double amount;
  MeasurementUnit measurement;

  CreateIngredient(
      {required this.groceryItemId,
      required this.amount,
      required this.measurement});

  Map<String, dynamic> toJson() {
    return {
      'groceryItemId': groceryItemId,
      'amount': amount,
      'measurement': measurement.name,
    };
  }
}
