import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/dtos/create_recipe.dart';
import 'package:recipemanagerwebclient/models/measurement_unit.dart';

import 'package:http/http.dart' as http;
import 'package:recipemanagerwebclient/pages/grocery_items.dart';

import '../../api/request_urls.dart';
import '../../models/grocery_item.dart';

class CreateIngredientPopup extends StatefulWidget {
  const CreateIngredientPopup({Key? key}) : super(key: key);

  @override
  _CreateIngredientPopupState createState() => _CreateIngredientPopupState();
}

class _CreateIngredientPopupState extends State<CreateIngredientPopup> {
  TextEditingController groceryItemIdController = TextEditingController();
  TextEditingController amountController = TextEditingController();
  List<DropdownMenuItem<MeasurementUnit>> measurementUnits =
      MeasurementUnit.values.map((e) {
    return DropdownMenuItem<MeasurementUnit>(
      value: e,
      child: Text(e.name),
    );
  }).toList();

  int groceryItemId = 0;
  double amount = 0.0;
  MeasurementUnit measurementUnit = MeasurementUnit.Kg;

  @override
  void initState() {
    super.initState();
    amountController.text = "0.0";
    amountController.addListener(() {
      amount = double.parse(amountController.text);
    });
    groceryItemIdController.text = "0";
    groceryItemIdController.addListener(() {
      groceryItemId = int.parse(groceryItemIdController.text);
    });
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Text('Zutat hinzufügen'),
      content: Center(
        child: SingleChildScrollView(
          child: Column(children: [
            TextFormField(
              keyboardType: TextInputType.number,
              decoration: InputDecoration(
                border: OutlineInputBorder(),
                labelText: 'GroceryItemId',
              ),
              controller: groceryItemIdController,
            ),
            TextFormField(
              keyboardType: TextInputType.number,
              decoration: InputDecoration(
                border: OutlineInputBorder(),
                labelText: 'Amount',
              ),
              controller: amountController,
            ),
            DropdownButton(
              value: measurementUnit,
              items: measurementUnits,
              onChanged: (value) {
                setState(() {
                  measurementUnit = value!;
                });
              },
            ),
          ]),
        ),
      ),
      actions: [
        TextButton(
          onPressed: () {
            CreateIngredient ingredient = CreateIngredient(
              groceryItemId: groceryItemId,
              amount: amount,
              measurement: measurementUnit,
            );
            Navigator.pop(context, ingredient);
          },
          child: Text('Hinzufügen'),
        )
      ],
    );
  }
}
