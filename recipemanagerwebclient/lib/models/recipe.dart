import 'package:json_annotation/json_annotation.dart';
import 'package:recipemanagerwebclient/models/data_layer.dart';
import 'ingredient.dart';
import 'instruction_step.dart';

part 'recipe.g.dart';

@JsonSerializable()
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
    this.id = 0,
    this.name = '',
    this.recipeCategory = const RecipeCategory(),
    this.amount = 0.0,
    this.portionUnit = PortionUnit.Bread,
    this.time = 0,
    this.vegetarian = false,
    this.ingredients = const <Ingredient>[],
    this.instructions = const <InstructionStep>[],
    this.source = '',
    this.comment = '',
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
