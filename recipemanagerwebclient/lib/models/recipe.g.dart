// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'recipe.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Recipe _$RecipeFromJson(Map<String, dynamic> json) => Recipe(
      id: json['id'] as int? ?? 0,
      name: json['name'] as String? ?? '',
      recipeCategory: json['recipeCategory'] == null
          ? null
          : RecipeCategory.fromJson(
              json['recipeCategory'] as Map<String, dynamic>),
      amount: (json['amount'] as num?)?.toDouble() ?? 0.0,
      portionUnit:
          $enumDecodeNullable(_$PortionUnitEnumMap, json['portionUnit']) ??
              PortionUnit.Bread,
      time: json['time'] as int? ?? 0,
      vegetarian: json['vegetarian'] as bool? ?? false,
      ingredients: (json['ingredients'] as List<dynamic>?)
          ?.map((e) => Ingredient.fromJson(e as Map<String, dynamic>))
          .toList(),
      instructions: (json['instructions'] as List<dynamic>?)
          ?.map((e) => InstructionStep.fromJson(e as Map<String, dynamic>))
          .toList(),
      source: json['source'] as String? ?? '',
      comment: json['comment'] as String? ?? '',
    );

Map<String, dynamic> _$RecipeToJson(Recipe instance) => <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'recipeCategory': instance.recipeCategory,
      'amount': instance.amount,
      'portionUnit': _$PortionUnitEnumMap[instance.portionUnit]!,
      'time': instance.time,
      'vegetarian': instance.vegetarian,
      'ingredients': instance.ingredients,
      'instructions': instance.instructions,
      'source': instance.source,
      'comment': instance.comment,
    };

const _$PortionUnitEnumMap = {
  PortionUnit.Bun: 'Bun',
  PortionUnit.Bread: 'Bread',
  PortionUnit.Cake: 'Cake',
  PortionUnit.Portion: 'Portion',
};
