import 'package:json_annotation/json_annotation.dart';
import 'package:recipemanagerwebclient/models/base_model.dart';

import 'measurement_unit.dart';

part 'ingredient.g.dart';

@JsonSerializable()
class Ingredient {
  int groceryItemId;
  String groceryName;
  double amount;
  MeasurementUnit measurement;

  Ingredient({
    this.groceryItemId = 0,
    this.groceryName = '',
    this.amount = 0.0,
    this.measurement = MeasurementUnit.Kg,
  });

  factory Ingredient.fromJson(Map<String, dynamic> json) =>
      _$IngredientFromJson(json);

  Map<String, dynamic> toJson() => _$IngredientToJson(this);
}
