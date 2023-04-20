import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/gen_exports.dart';

enum MealType { Breakfast, Lunch, Dinner }

extension ParseToLocalizedString on MealType {
  String toLocalizedString(BuildContext context) {
    switch (this) {
      case MealType.Breakfast:
        return AppLocalizations.of(context)!.breakfast;
      case MealType.Lunch:
        return AppLocalizations.of(context)!.lunch;
      case MealType.Dinner:
        return AppLocalizations.of(context)!.dinner;
    }
  }
}
