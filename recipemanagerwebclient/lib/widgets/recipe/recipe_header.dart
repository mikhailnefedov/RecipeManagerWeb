import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/models/data_layer.dart';
import 'package:recipemanagerwebclient/widgets/dropdowns/portion_unit_dropdown.dart';
import 'package:recipemanagerwebclient/widgets/dropdowns/recipe_category_dropdown.dart';

import '../../models/recipe.dart';

class RecipeHeader extends StatefulWidget {
  final Recipe recipe;
  const RecipeHeader({Key? key, required this.recipe}) : super(key: key);

  @override
  _RecipeHeaderState createState() => _RecipeHeaderState();
}

class _RecipeHeaderState extends State<RecipeHeader> {
  late Recipe _recipe;

  TextEditingController nameController = TextEditingController();
  TextEditingController amountController = TextEditingController();
  TextEditingController timeController = TextEditingController();
  TextEditingController sourceController = TextEditingController();
  TextEditingController commentController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _recipe = widget.recipe;
    nameController.text = _recipe.name;
    nameController.addListener(() {
      _recipe.name = nameController.text;
    });
    amountController.text = "${_recipe.amount}";
    amountController.addListener(() {
      _recipe.amount = double.parse(amountController.text);
    });
    timeController.text = "${_recipe.time}";
    timeController.addListener(() {
      _recipe.time = int.parse(timeController.text);
    });
    sourceController.text = _recipe.source;
    sourceController.addListener(() {
      _recipe.source = sourceController.text;
    });
    commentController.text = _recipe.comment;
    commentController.addListener(() {
      _recipe.comment = commentController.text;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Row(
          children: [
            Expanded(
              child: TextField(
                decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  labelText: 'Name',
                ),
                controller: nameController,
              ),
            ),
            SizedBox(
              width: 16.0,
            ),
            RecipeCategoryDropdown(
              recipe: _recipe,
            ),
          ],
        ),
        SizedBox(
          height: 16.0,
        ),
        Row(
          children: [
            Expanded(
              child: TextFormField(
                decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  labelText: 'Amount',
                ),
                controller: amountController,
              ),
            ),
            SizedBox(
              width: 16.0,
            ),
            PortionUnitDropdown(
              value: _recipe.portionUnit,
              recipe: _recipe,
            ),
            SizedBox(
              width: 16.0,
            ),
            Expanded(
              child: TextFormField(
                decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  labelText: 'Time',
                ),
                controller: timeController,
              ),
            ),
          ],
        ),
        SizedBox(height: 16.0),
        Row(
          children: [
            Checkbox(
              value: _recipe.vegetarian,
              onChanged: (value) {
                setState(() {
                  _recipe.vegetarian = value!;
                });
              },
            ),
            Text('vegetarian'),
            SizedBox(width: 16.0),
            Expanded(
              child: TextFormField(
                decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  labelText: 'Source',
                ),
                controller: sourceController,
              ),
            ),
          ],
        ),
        SizedBox(height: 16.0),
        TextFormField(
          decoration: InputDecoration(
            border: OutlineInputBorder(),
            labelText: 'Comment',
          ),
          controller: commentController,
        ),
      ],
    );
  }
}
