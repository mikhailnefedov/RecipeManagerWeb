import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:recipemanagerwebclient/api/request_urls.dart';
import 'package:recipemanagerwebclient/dtos/create_grocery_category.dart';
import 'package:recipemanagerwebclient/models/data_layer.dart';

class SaveGroceryCategoryPopup extends StatefulWidget {
  const SaveGroceryCategoryPopup({Key? key, this.groceryCategory})
      : super(key: key);

  final GroceryCategory? groceryCategory;

  @override
  State<SaveGroceryCategoryPopup> createState() =>
      _SaveGroceryCategoryPopupState();
}

class _SaveGroceryCategoryPopupState extends State<SaveGroceryCategoryPopup> {
  bool _isCreate = false;
  late GroceryCategory _groceryCategory;
  late TextEditingController _nameController;

  @override
  void initState() {
    super.initState();
    _isCreate = widget.groceryCategory == null;
    _groceryCategory = widget.groceryCategory ?? GroceryCategory();
    _nameController = TextEditingController(text: _groceryCategory.name);
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Text(_isCreate
          ? "Lebensmittelkategorie hinzufügen"
          : "Lebensmittelkategorie verändern"),
      content: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          TextField(
            controller: _nameController,
            decoration: InputDecoration(
              label: Text("Name"),
            ),
          ),
        ],
      ),
      actionsAlignment: MainAxisAlignment.center,
      actions: [
        IconButton(
          onPressed: () {
            postCategory();
            Navigator.pop(context);
          },
          icon: Icon(Icons.save),
          splashRadius: 20.0,
        )
      ],
    );
  }

  Future<void> postCategory() async {
    CreateGroceryCategory newCategory =
        CreateGroceryCategory(name: _nameController.text);

    await http.post(
      Uri.parse(RequestURL.groceryCategories),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: jsonEncode(newCategory.toJson()),
    );
  }
}
