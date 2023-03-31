import 'package:json_annotation/json_annotation.dart';
import 'package:recipemanagerwebclient/models/base_model.dart';
import 'package:recipemanagerwebclient/models/data_layer.dart';

part 'recipe.g.dart';

@JsonSerializable()
class Recipe extends BaseModel {
  final int id;
  String name;
  late RecipeCategory recipeCategory;
  double amount;
  PortionUnit portionUnit;
  int time;
  bool vegetarian;
  late List<Ingredient> ingredients;
  late List<InstructionStep> instructions;
  String source;
  String comment;

  Recipe({
    this.id = 0,
    this.name = '',
    RecipeCategory? recipeCategory,
    this.amount = 0.0,
    this.portionUnit = PortionUnit.Bread,
    this.time = 0,
    this.vegetarian = false,
    List<Ingredient>? ingredients,
    List<InstructionStep>? instructions,
    this.source = '',
    this.comment = '',
  }) {
    this.recipeCategory = recipeCategory ?? RecipeCategory();
    this.ingredients = ingredients ?? <Ingredient>[];
    this.instructions = instructions ?? <InstructionStep>[];
  }

  factory Recipe.fromJson(Map<String, dynamic> json) => _$RecipeFromJson(json);
  static convertFromJson(Map<String, dynamic> json) => _$RecipeFromJson(json);
  @override
  Map<String, dynamic> toJson() => _$RecipeToJson(this);
}
