import 'package:json_annotation/json_annotation.dart';
import 'package:recipemanagerwebclient/models/base_model.dart';

part 'grocery_item.g.dart';

@JsonSerializable()
class GroceryItem extends BaseModel {
  int id;
  String name;
  int groceryCategoryId;
  String groceryCategoryName;

  GroceryItem(
      {this.id = 0,
      this.name = '',
      this.groceryCategoryId = 0,
      this.groceryCategoryName = ''});

  factory GroceryItem.fromJson(Map<String, dynamic> json) =>
      _$GroceryItemFromJson(json);

  static convertFromJson(Map<String, dynamic> json) =>
      _$GroceryItemFromJson(json);

  @override
  Map<String, dynamic> toJson() => _$GroceryItemToJson(this);
}
