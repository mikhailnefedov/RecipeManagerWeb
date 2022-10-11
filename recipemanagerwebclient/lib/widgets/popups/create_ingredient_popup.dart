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
  late List<GroceryItem> groceryItems;

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
    call();
  }

  void call() async {
    groceryItems = await fetchItems();
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Text('Zutat hinzufügen'),
      content: Center(
        child: SingleChildScrollView(
          child: Column(children: [
            IconButton(
              onPressed: () async {
                GroceryItem item = await showSearch(
                    context: context,
                    delegate: IngredientSearchDelegate(groceryItems));
                setState(() {
                  groceryItemId = item.id;
                  groceryItemIdController.text = '${item.id}';
                });
              },
              icon: Icon(Icons.search),
            ),
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

  Future<List<GroceryItem>> fetchItems() async {
    final response = await http.get(Uri.parse(RequestURL.groceryItems));

    if (response.statusCode == 200) {
      final map = jsonDecode(response.body);
      return (map as List).map((e) => GroceryItem.fromJson(e)).toList();
    } else {
      throw Exception('Fail');
    }
  }
}

class IngredientSearchDelegate extends SearchDelegate {
  late List<GroceryItem> _groceryItems;

  IngredientSearchDelegate(this._groceryItems);

  @override
  List<Widget>? buildActions(BuildContext context) {
    return [
      IconButton(
        onPressed: () {
          query = '';
        },
        icon: Icon(Icons.clear),
      ),
    ];
  }

  @override
  Widget? buildLeading(BuildContext context) {
    return IconButton(
      onPressed: () {
        close(context, null);
      },
      icon: Icon(Icons.arrow_back),
    );
  }

  // third overwrite to show query result
  @override
  Widget buildResults(BuildContext context) {
    List<GroceryItem> matchQuery = [];
    for (var item in _groceryItems) {
      if (item.name.toLowerCase().contains(query.toLowerCase())) {
        matchQuery.add(item);
      }
    }
    return ListView.builder(
      itemCount: matchQuery.length,
      itemBuilder: (context, index) {
        var result = matchQuery[index];
        return ListTile(
          title: Text(result.name),
        );
      },
    );
  }

  // last overwrite to show the
  // querying process at the runtime
  @override
  Widget buildSuggestions(BuildContext context) {
    List<GroceryItem> matchQuery = [];
    for (var item in _groceryItems) {
      if (item.name.toLowerCase().contains(query.toLowerCase())) {
        matchQuery.add(item);
      }
    }
    return ListView.builder(
      itemCount: matchQuery.length,
      itemBuilder: (context, index) {
        var result = matchQuery[index];
        return ListTile(
          title: Text(result.name),
          onTap: () {
            close(context, result);
          },
        );
      },
    );
  }
}
