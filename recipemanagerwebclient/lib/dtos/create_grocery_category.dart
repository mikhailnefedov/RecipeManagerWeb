import 'package:json_annotation/json_annotation.dart';
import 'package:recipemanagerwebclient/models/base_model.dart';

part 'create_grocery_category.g.dart';

@JsonSerializable()
class CreateGroceryCategory extends BaseModel {
  CreateGroceryCategory({
    required this.name,
  });

  String name;

  factory CreateGroceryCategory.fromJson(Map<String, dynamic> json) =>
      _$CreateGroceryCategoryFromJson(json);

  static convertFromJson(Map<String, dynamic> json) =>
      _$CreateGroceryCategoryFromJson(json);

  @override
  Map<String, dynamic> toJson() => _$CreateGroceryCategoryToJson(this);
}
