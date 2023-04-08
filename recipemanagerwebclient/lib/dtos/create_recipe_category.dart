import 'package:json_annotation/json_annotation.dart';
import 'package:recipemanagerwebclient/models/base_model.dart';

part 'create_recipe_category.g.dart';

@JsonSerializable()
class CreateRecipeCategory extends BaseModel {
  CreateRecipeCategory({
    required this.name,
    required this.abbreviation,
  });

  String name;
  String abbreviation;

  factory CreateRecipeCategory.fromJson(Map<String, dynamic> json) =>
      _$CreateRecipeCategoryFromJson(json);

  static convertFromJson(Map<String, dynamic> json) =>
      _$CreateRecipeCategoryFromJson(json);

  @override
  Map<String, dynamic> toJson() => _$CreateRecipeCategoryToJson(this);
}
