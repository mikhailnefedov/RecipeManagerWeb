import 'package:equatable/equatable.dart';
import 'package:json_annotation/json_annotation.dart';

part 'recipe_category.g.dart';

@JsonSerializable()
class RecipeCategory extends Equatable {
  final int id;
  final String abbreviation;
  final String name;

  const RecipeCategory({
    this.id = 0,
    this.abbreviation = '',
    this.name = '',
  });

  factory RecipeCategory.fromJson(Map<String, dynamic> json) =>
      _$RecipeCategoryFromJson(json);
  Map<String, dynamic> toJson() => _$RecipeCategoryToJson(this);

  @override
  List<Object> get props => [id, abbreviation, name];
}
