import 'package:json_annotation/json_annotation.dart';
import 'package:recipemanagerwebclient/models/base_model.dart';
import 'package:recipemanagerwebclient/models/portion_unit.dart';
import 'package:recipemanagerwebclient/models/recipe_category.dart';

part 'small_recipe.g.dart';

@JsonSerializable()
class SmallRecipe extends BaseModel {
  int id;
  String name;
  late RecipeCategory recipeCategory;
  double amount;
  PortionUnit portionUnit;
  int time;
  bool vegetarian;

  SmallRecipe({
    this.id = 0,
    this.name = '',
    RecipeCategory? recipeCategory,
    this.amount = 0.0,
    this.portionUnit = PortionUnit.Bread,
    this.time = 0,
    this.vegetarian = false,
  }) {
    this.recipeCategory = recipeCategory ?? RecipeCategory();
  }

  factory SmallRecipe.fromJson(Map<String, dynamic> json) =>
      _$SmallRecipeFromJson(json);
  static convertFromJson(Map<String, dynamic> json) =>
      _$SmallRecipeFromJson(json);
  @override
  Map<String, dynamic> toJson() => _$SmallRecipeToJson(this);
}
