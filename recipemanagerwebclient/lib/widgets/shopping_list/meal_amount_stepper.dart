import 'package:flutter/material.dart';

import '../../models/meal.dart';

class MealAmountStepper extends StatefulWidget {
  MealAmountStepper({Key? key, required this.meal}) : super(key: key);

  Meal meal;

  @override
  State<MealAmountStepper> createState() => _MealAmountStepperState();
}

class _MealAmountStepperState extends State<MealAmountStepper> {
  late Meal _meal;

  @override
  void initState() {
    super.initState();
    _meal = widget.meal;
  }

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        IconButton(
          onPressed: () {
            setState(() {
              _meal.requestedAmount -= 0.5;
            });
          },
          icon: Icon(Icons.remove),
        ),
        Text("${_meal.requestedAmount}"),
        IconButton(
          onPressed: () {
            setState(() {
              _meal.requestedAmount += 0.5;
            });
          },
          icon: Icon(Icons.add),
        ),
        Text(_meal.portionUnit.name),
      ],
    );
  }
}
