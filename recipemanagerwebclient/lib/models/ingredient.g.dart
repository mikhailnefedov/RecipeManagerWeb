// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'ingredient.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Ingredient _$IngredientFromJson(Map<String, dynamic> json) => Ingredient(
      groceryItemId: json['groceryItemId'] as int? ?? 0,
      groceryName: json['groceryName'] as String? ?? '',
      amount: (json['amount'] as num?)?.toDouble() ?? 0.0,
      measurement:
          $enumDecodeNullable(_$MeasurementUnitEnumMap, json['measurement']) ??
              MeasurementUnit.Kg,
    );

Map<String, dynamic> _$IngredientToJson(Ingredient instance) =>
    <String, dynamic>{
      'groceryItemId': instance.groceryItemId,
      'groceryName': instance.groceryName,
      'amount': instance.amount,
      'measurement': _$MeasurementUnitEnumMap[instance.measurement]!,
    };

const _$MeasurementUnitEnumMap = {
  MeasurementUnit.Kg: 'Kg',
  MeasurementUnit.L: 'L',
};
