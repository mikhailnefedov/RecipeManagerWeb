import 'package:recipemanagerwebclient/models/data_layer.dart';

class Meal {
  int recipeId;
  String recipeName;
  double requestedAmount;
  PortionUnit portionUnit;

  Meal({
    required this.recipeId,
    required this.recipeName,
    required this.requestedAmount,
    required this.portionUnit,
  });

  Map<String, dynamic> toJson() {
    return {
      'recipeId': recipeId,
      'requestedAmount': requestedAmount,
    };
  }
}
