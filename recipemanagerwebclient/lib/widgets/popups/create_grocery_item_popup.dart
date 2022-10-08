import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:recipemanagerwebclient/api/request_urls.dart';
import 'package:recipemanagerwebclient/dtos/create_grocery_category.dart';
import 'package:recipemanagerwebclient/dtos/create_recipe_category.dart';

import '../../models/grocery_category.dart';

class CreateGroceryItemPopup extends StatefulWidget {
  const CreateGroceryItemPopup({
    Key? key,
  }) : super(key: key);

  @override
  State<CreateGroceryItemPopup> createState() => _CreateGroceryItemPopupState();
}

class _CreateGroceryItemPopupState extends State<CreateGroceryItemPopup> {
  late TextEditingController nameController;
  late GroceryCategory category;
  late List<GroceryCategory> categories;

  @override
  void initState() {
    super.initState();
    nameController = TextEditingController(text: "");
    categories = [];
    call();
    category = GroceryCategory(id: 0, name: "");
  }

  void call() async {
    var fetchedCategories = await fetchCategories();
    setState(() {
      categories = fetchedCategories;
    });
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Text('Lebensmittel hinzufügen'),
      content: Center(
        child: Column(
          children: [
            TextField(
              controller: nameController,
              decoration: InputDecoration(
                label: Text("Name"),
              ),
            ),
            DropdownButton(
              items: categories.map<DropdownMenuItem<GroceryCategory>>((e) {
                return DropdownMenuItem<GroceryCategory>(
                  value: e,
                  child: Text(e.name),
                );
                ;
              }).toList(),
              onChanged: (value) {
                category = value!;
              },
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

  Future<List<GroceryCategory>> fetchCategories() async {
    final response = await http.get(Uri.parse(RequestURL.groceryCategories));

    if (response.statusCode == 200) {
      final map = jsonDecode(response.body);
      return (map as List).map((e) => GroceryCategory.fromJson(e)).toList();
    } else {
      throw Exception('Fail');
    }
  }
}
