import 'package:json_annotation/json_annotation.dart';

part 'grocery_category.g.dart';

@JsonSerializable()
class GroceryCategory {
  final int id;
  final String name;

  const GroceryCategory({
    this.id = 0,
    this.name = '',
  });

  factory GroceryCategory.fromJson(Map<String, dynamic> json) =>
      _$GroceryCategoryFromJson(json);

  Map<String, dynamic> toJson() => _$GroceryCategoryToJson(this);
}
