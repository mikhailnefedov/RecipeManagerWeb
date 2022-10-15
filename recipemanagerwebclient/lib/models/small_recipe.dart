import 'package:json_annotation/json_annotation.dart';
import 'package:recipemanagerwebclient/models/portion_unit.dart';
import 'package:recipemanagerwebclient/models/recipe_category.dart';

part 'small_recipe.g.dart';

@JsonSerializable()
class SmallRecipe {
  final int id;
  final String name;
  final RecipeCategory recipeCategory;
  final double amount;
  final PortionUnit portionUnit;
  final int time;
  final bool vegetarian;

  const SmallRecipe({
    this.id = 0,
    this.name = '',
    this.recipeCategory = const RecipeCategory(),
    this.amount = 0.0,
    this.portionUnit = PortionUnit.Bread,
    this.time = 0,
    this.vegetarian = false,
  });

  factory SmallRecipe.fromJson(Map<String, dynamic> json) =>
      _$SmallRecipeFromJson(json);
}
