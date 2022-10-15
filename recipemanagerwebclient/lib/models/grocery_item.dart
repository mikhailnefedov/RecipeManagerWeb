import 'package:json_annotation/json_annotation.dart';

part 'grocery_item.g.dart';

@JsonSerializable()
class GroceryItem {
  final int id;
  final String name;
  final int groceryCategoryId;
  final String groceryCategoryName;

  const GroceryItem(
      {this.id = 0,
      this.name = '',
      this.groceryCategoryId = 0,
      this.groceryCategoryName = ''});

  factory GroceryItem.fromJson(Map<String, dynamic> json) =>
      _$GroceryItemFromJson(json);
}
