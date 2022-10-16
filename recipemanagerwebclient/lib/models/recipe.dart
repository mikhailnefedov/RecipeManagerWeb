import 'package:json_annotation/json_annotation.dart';
import 'package:recipemanagerwebclient/models/data_layer.dart';
import 'ingredient.dart';
import 'instruction_step.dart';

part 'recipe.g.dart';

@JsonSerializable()
class Recipe {
  final int id;
  String name;
  RecipeCategory recipeCategory;
  double amount;
  PortionUnit portionUnit;
  int time;
  bool vegetarian;
  final List<Ingredient> ingredients;
  final List<InstructionStep> instructions;
  String source;
  String comment;

  Recipe({
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

  factory Recipe.fromJson(Map<String, dynamic> json) => _$RecipeFromJson(json);
  Map<String, dynamic> toJson() => _$RecipeToJson(this);
}
