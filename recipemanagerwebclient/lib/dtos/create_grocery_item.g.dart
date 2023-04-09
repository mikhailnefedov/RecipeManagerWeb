// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'create_grocery_item.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

CreateGroceryItem _$CreateGroceryItemFromJson(Map<String, dynamic> json) =>
    CreateGroceryItem(
      name: json['name'] as String,
      groceryCategoryId: json['groceryCategoryId'] as int,
    );

Map<String, dynamic> _$CreateGroceryItemToJson(CreateGroceryItem instance) =>
    <String, dynamic>{
      'name': instance.name,
      'groceryCategoryId': instance.groceryCategoryId,
    };
