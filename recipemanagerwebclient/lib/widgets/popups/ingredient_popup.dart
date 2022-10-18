import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/models/data_layer.dart';
import 'package:recipemanagerwebclient/widgets/dropdowns/measurement_unit_dropdown.dart';

import '../../models/ingredient.dart';
import 'ingredient_search_delegate.dart';

class IngredientPopup extends StatefulWidget {
  Ingredient? ingredient;
  IngredientPopup({Key? key, Ingredient? this.ingredient}) : super(key: key);

  @override
  _IngredientPopupState createState() => _IngredientPopupState();
}

class _IngredientPopupState extends State<IngredientPopup> {
  late Ingredient _ingredient;

  TextEditingController amountController = TextEditingController();
  TextEditingController itemController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _ingredient = widget.ingredient ?? Ingredient();

    amountController.text = '${_ingredient.amount}';
    amountController.addListener(() {
      _ingredient.amount = double.parse(amountController.text);
    });
    itemController.text = _ingredient.groceryName;
    itemController.addListener(() {
      _ingredient.groceryName = itemController.text;
    });
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Text('Zutat hinzufügen'),
      content: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          TextField(
            decoration: InputDecoration(
              border: OutlineInputBorder(),
              labelText: 'Grocery item',
              prefixIcon: IconButton(
                onPressed: () async {
                  /*
            GroceryItem item = await showSearch(
                context: context,
                delegate: IngredientSearchDelegate(groceryItems));
            setState(() {
              groceryItemId = item.id;
              groceryItemIdController.text = '${item.id}';
            });*/
                },
                icon: Icon(Icons.search),
              ),
            ),
            controller: itemController,
          ),
          SizedBox(
            height: 16.0,
          ),
          TextFormField(
            keyboardType: TextInputType.number,
            decoration: InputDecoration(
              border: OutlineInputBorder(),
              labelText: 'Amount',
            ),
            controller: amountController,
          ),
          MeasurementDropdown(ingredient: _ingredient),
        ],
      ),
      actions: [
        TextButton(
          onPressed: () {
            Navigator.pop(context, _ingredient);
          },
          child: Text('Speichern'),
        )
      ],
    );
  }
}
