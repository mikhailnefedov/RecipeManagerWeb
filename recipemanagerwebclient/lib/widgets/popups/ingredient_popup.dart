import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/api/grocery_item_repository.dart';
import 'package:recipemanagerwebclient/models/data_layer.dart';
import 'package:recipemanagerwebclient/widgets/dropdowns/measurement_unit_dropdown.dart';

import 'ingredient_search_delegate.dart';

class IngredientPopup extends StatefulWidget {
  Ingredient? ingredient;
  IngredientPopup({Key? key, Ingredient? this.ingredient}) : super(key: key);

  @override
  _IngredientPopupState createState() => _IngredientPopupState();
}

class _IngredientPopupState extends State<IngredientPopup> {
  late Ingredient _ingredient;
  late List<GroceryItem> groceryItems;

  TextEditingController amountController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _ingredient = widget.ingredient ?? Ingredient();

    amountController.text = '${_ingredient.amount}';
    amountController.addListener(() {
      _ingredient.amount = double.parse(amountController.text);
    });
    fetchGroceryItems(); //TODO: better loading of these entities
  }

  void fetchGroceryItems() async {
    GroceryItemRepository _groceryItemRepository = GroceryItemRepository();
    groceryItems = await _groceryItemRepository.fetchAll();
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Text('Zutat hinzufügen'),
      content: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          Row(
            children: [
              IconButton(
                onPressed: () async {
                  GroceryItem item = await showSearch(
                      context: context,
                      delegate: IngredientSearchDelegate(groceryItems));
                  setState(() {
                    _ingredient.groceryItemId = item.id;
                    _ingredient.groceryName = item.name;
                  });
                },
                icon: Icon(Icons.search),
              ),
              Text(_ingredient.groceryName),
            ],
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
