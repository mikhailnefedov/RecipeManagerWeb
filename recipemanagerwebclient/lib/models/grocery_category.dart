import 'package:json_annotation/json_annotation.dart';
import 'package:recipemanagerwebclient/models/base_model.dart';

part 'grocery_category.g.dart';

@JsonSerializable()
class GroceryCategory extends BaseModel {
  final int id;
  final String name;

  GroceryCategory({
    this.id = 0,
    this.name = '',
  });

  factory GroceryCategory.fromJson(Map<String, dynamic> json) =>
      _$GroceryCategoryFromJson(json);

  @override
  Map<String, dynamic> toJson() => _$GroceryCategoryToJson(this);

  static convertFromJson(Map<String, dynamic> json) =>
      _$GroceryCategoryFromJson(json);
}
