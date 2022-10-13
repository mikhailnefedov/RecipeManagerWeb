// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'small_recipe.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

SmallRecipe _$SmallRecipeFromJson(Map<String, dynamic> json) => SmallRecipe(
      id: json['id'] as int? ?? 0,
      name: json['name'] as String? ?? '',
      recipeCategory: json['recipeCategory'] == null
          ? const RecipeCategory()
          : RecipeCategory.fromJson(
              json['recipeCategory'] as Map<String, dynamic>),
      amount: (json['amount'] as num?)?.toDouble() ?? 0.0,
      portionUnit:
          $enumDecodeNullable(_$PortionUnitEnumMap, json['portionUnit']) ??
              PortionUnit.Bread,
      time: json['time'] as int? ?? 0,
      vegetarian: json['vegetarian'] as bool? ?? false,
    );

Map<String, dynamic> _$SmallRecipeToJson(SmallRecipe instance) =>
    <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'recipeCategory': instance.recipeCategory,
      'amount': instance.amount,
      'portionUnit': _$PortionUnitEnumMap[instance.portionUnit]!,
      'time': instance.time,
      'vegetarian': instance.vegetarian,
    };

const _$PortionUnitEnumMap = {
  PortionUnit.Bun: 'Bun',
  PortionUnit.Bread: 'Bread',
  PortionUnit.Cake: 'Cake',
  PortionUnit.Portion: 'Portion',
};
