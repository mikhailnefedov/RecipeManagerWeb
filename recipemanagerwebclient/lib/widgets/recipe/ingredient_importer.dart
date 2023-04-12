import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/api/grocery_item_repository.dart';
import 'package:recipemanagerwebclient/models/data_layer.dart';

class IngredientImporter extends StatefulWidget {
  const IngredientImporter({Key? key}) : super(key: key);

  @override
  State<IngredientImporter> createState() => _IngredientImporterState();
}

class _IngredientImporterState extends State<IngredientImporter> {
  TextEditingController _importTextController = TextEditingController();
  GroceryItemRepository _groceryItemRepository = GroceryItemRepository();

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Text('Zutaten hinzufügen | Form: Zutat,Menge,Einheit'),
      content: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          TextField(
            minLines: 10,
            maxLines: null,
            decoration: InputDecoration(
              border: OutlineInputBorder(),
              hintText: '''
              Zutaten in Form:
              Ananas;1.0;Kg
              Apfel;0.5;Kg''',
            ),
            controller: _importTextController,
          ),
        ],
      ),
      actionsAlignment: MainAxisAlignment.center,
      actions: [
        TextButton(
          onPressed: () async {
            List<Ingredient> ingredients = await _convertTextIntoIngredients();
            Navigator.pop(context, ingredients);
          },
          child: Text('Hinzufügen'),
        )
      ],
    );
  }

  Future<List<Ingredient>> _convertTextIntoIngredients() async {
    List<GroceryItem> items = await _groceryItemRepository.fetchAll();

    List<String> lines = _importTextController.text.split('\n');

    return lines.map((e) {
      List<String> ingredientData = e.split(";");
      GroceryItem groceryItem =
          items.firstWhere((item) => item.name == ingredientData[0]);
      double amount = double.parse(ingredientData[1]);
      MeasurementUnit unit = MeasurementUnit.values.byName(ingredientData[2]);

      return Ingredient(
        groceryItemId: groceryItem.id,
        groceryName: groceryItem.name,
        amount: amount,
        measurement: unit,
      );
    }).toList();
  }
}
