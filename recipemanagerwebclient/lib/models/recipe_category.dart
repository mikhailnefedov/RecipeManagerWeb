import 'package:equatable/equatable.dart';
import 'package:json_annotation/json_annotation.dart';
import 'package:recipemanagerwebclient/models/base_model.dart';

part 'recipe_category.g.dart';

@JsonSerializable()
class RecipeCategory extends BaseModel {
  int id;
  String abbreviation;
  String name;

  RecipeCategory({
    this.id = 0,
    this.abbreviation = '',
    this.name = '',
  });

  factory RecipeCategory.fromJson(Map<String, dynamic> json) =>
      _$RecipeCategoryFromJson(json);

  static convertFromJson(Map<String, dynamic> json) =>
      _$RecipeCategoryFromJson(json);

  @override
  Map<String, dynamic> toJson() => _$RecipeCategoryToJson(this);
}
