import 'dart:convert';

import 'package:recipemanagerwebclient/models/measurement_unit.dart';
import 'package:recipemanagerwebclient/models/portion_unit.dart';
import 'package:recipemanagerwebclient/models/recipe_category.dart';

class Recipe {
  final int id;
  final String name;
  final RecipeCategory recipeCategory;
  final double amount;
  final PortionUnit portionUnit;
  final int time;
  final bool vegetarian;
  final List<Ingredient> ingredients;
  final List<InstructionStep> instructions;
  final String source;
  final String comment;

  const Recipe({
    required this.id,
    required this.name,
    required this.recipeCategory,
    required this.amount,
    required this.portionUnit,
    required this.time,
    required this.vegetarian,
    required this.ingredients,
    required this.instructions,
    required this.source,
    required this.comment,
  });

  factory Recipe.fromJson(Map<String, dynamic> json) {
    return Recipe(
      id: json['id'],
      name: json['name'],
      recipeCategory: RecipeCategory.fromJson(json['recipeCategory']),
      amount: json['amount'],
      portionUnit: PortionUnit.values.byName(json['portionUnit']),
      time: json['time'],
      vegetarian: json['vegetarian'],
      ingredients: ((json['ingredients']) as List)
          .map((e) => Ingredient.fromJson(e))
          .toList(),
      instructions: ((json['instructions']) as List)
          .map((e) => InstructionStep.fromJson(e))
          .toList(),
      source: json['source'],
      comment: json['comment'],
    );
  }
}

class Ingredient {
  final int groceryItemId;
  final String groceryName;
  final double amount;
  final MeasurementUnit measurement;

  Ingredient({
    required this.groceryItemId,
    required this.groceryName,
    required this.amount,
    required this.measurement,
  });

  factory Ingredient.fromJson(Map<String, dynamic> json) {
    return Ingredient(
      groceryItemId: json['groceryItemId'],
      groceryName: json['groceryName'],
      amount: json['amount'],
      measurement: MeasurementUnit.values.byName(json['measurement']),
    );
  }
}

class InstructionStep {
  final int id;
  final String text;

  InstructionStep({
    required this.id,
    required this.text,
  });

  factory InstructionStep.fromJson(Map<String, dynamic> json) {
    return InstructionStep(
      id: json['id'],
      text: json['text'],
    );
  }
}
