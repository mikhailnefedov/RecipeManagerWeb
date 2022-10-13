// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'grocery_item.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

GroceryItem _$GroceryItemFromJson(Map<String, dynamic> json) => GroceryItem(
      id: json['id'] as int? ?? 0,
      name: json['name'] as String? ?? '',
      groceryCategoryId: json['groceryCategoryId'] as int? ?? 0,
      groceryCategoryName: json['groceryCategoryName'] as String? ?? '',
    );

Map<String, dynamic> _$GroceryItemToJson(GroceryItem instance) =>
    <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'groceryCategoryId': instance.groceryCategoryId,
      'groceryCategoryName': instance.groceryCategoryName,
    };
