import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:recipemanagerwebclient/api/request_urls.dart';
import 'package:recipemanagerwebclient/dtos/create_recipe_category.dart';

class CreateRecipeCategoryPopup extends StatefulWidget {
  const CreateRecipeCategoryPopup({
    Key? key,
  }) : super(key: key);

  @override
  State<CreateRecipeCategoryPopup> createState() =>
      _CreateRecipeCategoryPopupState();
}

class _CreateRecipeCategoryPopupState extends State<CreateRecipeCategoryPopup> {
  late CreateRecipeCategory newCategory;
  late TextEditingController nameController;
  late TextEditingController abbreviationController;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();

    newCategory = CreateRecipeCategory(name: "", abbreviation: "");
    nameController = TextEditingController(text: newCategory.name);
    abbreviationController =
        TextEditingController(text: newCategory.abbreviation);
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Text('Rezeptkategorie hinzufügen'),
      content: Center(
        child: Column(
          children: [
            TextField(
              controller: nameController,
              decoration: InputDecoration(
                label: Text("Name"),
              ),
            ),
            TextField(
              controller: abbreviationController,
              decoration: InputDecoration(
                label: Text("Abkürzung"),
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
    newCategory.name = nameController.text;
    newCategory.abbreviation = abbreviationController.text;

    await http.post(
      Uri.parse(RequestURL.recipeCategories),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: jsonEncode(newCategory.toJson()),
    );
  }
}
