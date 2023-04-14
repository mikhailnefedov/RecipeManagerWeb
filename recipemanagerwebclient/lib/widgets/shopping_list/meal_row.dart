import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:recipemanagerwebclient/models/meal_type.dart';

import '../../models/meal.dart';
import 'meal_drag_target.dart';

class MealRow extends StatelessWidget {
  MealRow({
    Key? key,
    required this.date,
  }) : super(key: key);

  final DateTime date;
  final MealDragTarget _breakfastMeal = MealDragTarget(
    mealType: MealType.Breakfast,
  );
  final MealDragTarget _lunchMeal = MealDragTarget(
    mealType: MealType.Lunch,
  );
  final MealDragTarget _dinnerMeal = MealDragTarget(
    mealType: MealType.Dinner,
  );

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
      children: [
        Text(
          _createDateString(),
        ),
        _breakfastMeal,
        _lunchMeal,
        _dinnerMeal
      ],
    );
  }

  String _createDateString() {
    return DateFormat("dd.MM.yyyy").format(date);
  }

  List<Meal> getMeals() {
    List<Meal> meals = [];
    meals.addAll(_breakfastMeal.getMeals());
    meals.addAll(_lunchMeal.getMeals());
    meals.addAll(_dinnerMeal.getMeals());
    return meals;
  }
}
