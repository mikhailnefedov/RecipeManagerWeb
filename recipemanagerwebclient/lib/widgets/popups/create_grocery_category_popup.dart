import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:recipemanagerwebclient/api/request_urls.dart';
import 'package:recipemanagerwebclient/dtos/create_grocery_category.dart';
import 'package:recipemanagerwebclient/dtos/create_recipe_category.dart';

import '../../models/grocery_category.dart';

class CreateGroceryCategoryPopup extends StatefulWidget {
  const CreateGroceryCategoryPopup({
    Key? key,
  }) : super(key: key);

  @override
  State<CreateGroceryCategoryPopup> createState() =>
      _CreateGroceryCategoryPopupState();
}

class _CreateGroceryCategoryPopupState
    extends State<CreateGroceryCategoryPopup> {
  late TextEditingController nameController;

  @override
  void initState() {
    super.initState();
    nameController = TextEditingController(text: "");
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Text('Lebensmittelkategorie hinzufügen'),
      content: Center(
        child: Column(
          children: [
            TextField(
              controller: nameController,
              decoration: InputDecoration(
                label: Text("Name"),
              ),
            ),
          ],
        ),
      ),
      actions: [
        TextButton(
          onPressed: () {
            postCategory();
            Navigator.pop(context);
          },
          child: Text('Speichern'),
        )
      ],
    );
  }

  Future<void> postCategory() async {
    CreateGroceryCategory newCategory =
        CreateGroceryCategory(name: nameController.text);

    await http.post(
      Uri.parse(RequestURL.groceryCategories),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: jsonEncode(newCategory.toJson()),
    );
  }
}
