import 'package:json_annotation/json_annotation.dart';
import 'package:recipemanagerwebclient/models/base_model.dart';

part 'create_grocery_item.g.dart';

@JsonSerializable()
class CreateGroceryItem extends BaseModel {
  CreateGroceryItem({
    required this.name,
    required this.groceryCategoryId,
  });

  String name;
  int groceryCategoryId;

  factory CreateGroceryItem.fromJson(Map<String, dynamic> json) =>
      _$CreateGroceryItemFromJson(json);

  static convertFromJson(Map<String, dynamic> json) =>
      _$CreateGroceryItemFromJson(json);

  @override
  Map<String, dynamic> toJson() => _$CreateGroceryItemToJson(this);
}
