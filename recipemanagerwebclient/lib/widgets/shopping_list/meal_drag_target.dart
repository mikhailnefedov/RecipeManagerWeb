import 'dart:html';

import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:recipemanagerwebclient/models/meal.dart';
import 'package:recipemanagerwebclient/models/meal_type.dart';
import 'package:recipemanagerwebclient/widgets/shopping_list/meal_amount_stepper.dart';

class MealDragTarget extends StatelessWidget {
  MealDragTarget({Key? key, required this.mealType}) : super(key: key);

  final List<Meal> _meals = [];
  final MealType mealType;

  @override
  Widget build(BuildContext context) {
    return Container(
      width: 400,
      height: 100,
      decoration: BoxDecoration(
        border: Border.all(color: Colors.black),
      ),
      child: DragTarget<Meal>(
        onAccept: (data) {
          _meals.add(data);
        },
        builder: (context, candidateData, rejectedData) {
          if (_meals.isNotEmpty) {
            return Column(
              children: _meals
                  .map((meal) => Padding(
                        padding: const EdgeInsets.only(bottom: 5),
                        child: Row(
                          mainAxisAlignment: MainAxisAlignment.center,
                          children: [
                            Text(meal.recipeName),
                            MealAmountStepper(meal: meal),
                          ],
                        ),
                      ))
                  .toList(),
            );
          } else {
            return Center(
              child: Text(
                mealType.name,
                style: TextStyle(color: Colors.black38),
              ),
            );
          }
        },
      ),
    );
  }

  List<Meal> getMeals() {
    return _meals;
  }
}
