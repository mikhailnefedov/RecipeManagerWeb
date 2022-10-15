// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'grocery_category.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

GroceryCategory _$GroceryCategoryFromJson(Map<String, dynamic> json) =>
    GroceryCategory(
      id: json['id'] as int? ?? 0,
      name: json['name'] as String? ?? '',
    );

Map<String, dynamic> _$GroceryCategoryToJson(GroceryCategory instance) =>
    <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
    };
