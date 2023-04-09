import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:recipemanagerwebclient/api/grocery_category_repository.dart';
import 'package:recipemanagerwebclient/api/grocery_item_repository.dart';
import 'package:recipemanagerwebclient/api/request_urls.dart';
import 'package:recipemanagerwebclient/dtos/create_grocery_category.dart';
import 'package:recipemanagerwebclient/widgets/dropdowns/grocery_category_dropwdown.dart';

import '../../dtos/create_grocery_item.dart';
import '../../models/grocery_category.dart';
import '../../models/grocery_item.dart';

class SaveGroceryItemPopup extends StatefulWidget {
  const SaveGroceryItemPopup({
    Key? key,
    this.groceryItem,
  }) : super(key: key);

  final GroceryItem? groceryItem;

  @override
  State<SaveGroceryItemPopup> createState() => _SaveGroceryItemPopupState();
}

class _SaveGroceryItemPopupState extends State<SaveGroceryItemPopup> {
  bool _isCreate = false;
  late GroceryItem _groceryItem;

  late TextEditingController _nameController;
  late GroceryItemRepository _groceryItemRepository;

  late GroceryCategoryDropwdown _groceryCategoryDropdown;

  @override
  void initState() {
    super.initState();
    _isCreate = widget.groceryItem == null;
    _groceryItem = widget.groceryItem ?? GroceryItem();
    _nameController = TextEditingController(text: _groceryItem.name);
    _groceryItemRepository = GroceryItemRepository();
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Text(
          _isCreate ? 'Lebensmittel hinzufügen' : 'Lebensmittel verändern'),
      content: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          TextField(
            controller: _nameController,
            decoration: InputDecoration(
              label: Text("Name"),
            ),
          ),
          FutureBuilder<List<GroceryCategory>>(
            future: GroceryCategoryRepository().fetchAll(),
            builder: (context, snapshot) {
              if (snapshot.hasData) {
                GroceryCategory groceryCategory = _isCreate
                    ? snapshot.requireData[0]
                    : snapshot.requireData.firstWhere(
                        (cat) => cat.id == _groceryItem.groceryCategoryId);
                _groceryCategoryDropdown = GroceryCategoryDropwdown(
                  groceryCategories: snapshot.requireData,
                  selectedCategory: groceryCategory,
                );
                return _groceryCategoryDropdown;
              } else if (snapshot.hasError) {
                return Text('${snapshot.error}');
              }
              return Center(
                child: const CircularProgressIndicator(),
              );
            },
          )
        ],
      ),
      actionsAlignment: MainAxisAlignment.center,
      actions: [
        TextButton(
          onPressed: () {
            if (_isCreate) {
              addGroceryItem();
            } else {
              updateGroceryItem();
            }
          },
          child: Text('Speichern'),
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

  void addGroceryItem() async {
    CreateGroceryItem dto = CreateGroceryItem(
      name: _nameController.text,
      groceryCategoryId: _groceryCategoryDropdown.selectedCategory.id,
    );
    GroceryItem groceryItem = await _groceryItemRepository.add(dto);
    Navigator.pop(context, groceryItem);
  }

  void updateGroceryItem() async {
    _groceryItem.name = _nameController.text;
    _groceryItem.groceryCategoryId =
        _groceryCategoryDropdown.selectedCategory.id;
    _groceryItem.groceryCategoryName =
        _groceryCategoryDropdown.selectedCategory.name;
    await _groceryItemRepository.update(_groceryItem);
    Navigator.pop(context, _groceryItem);
  }
}
