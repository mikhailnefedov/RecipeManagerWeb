// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'recipe_category.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

RecipeCategory _$RecipeCategoryFromJson(Map<String, dynamic> json) =>
    RecipeCategory(
      id: json['id'] as int? ?? 0,
      abbreviation: json['abbreviation'] as String? ?? '',
      name: json['name'] as String? ?? '',
    );

Map<String, dynamic> _$RecipeCategoryToJson(RecipeCategory instance) =>
    <String, dynamic>{
      'id': instance.id,
      'abbreviation': instance.abbreviation,
      'name': instance.name,
    };
