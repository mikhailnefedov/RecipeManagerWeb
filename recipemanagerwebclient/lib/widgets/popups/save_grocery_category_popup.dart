import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/api/grocery_category_repository.dart';
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
  final GroceryCategoryRepository _groceryCategoryRepository =
      GroceryCategoryRepository();

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
          onPressed: () async {
            if (_isCreate) {
              addGroceryCategory();
            } else {
              updateGroceryCategory();
            }
          },
          icon: Icon(Icons.save),
          splashRadius: 20.0,
        )
      ],
    );
  }

  void addGroceryCategory() async {
    GroceryCategory groceryCategory = await _groceryCategoryRepository
        .add(CreateGroceryCategory(name: _nameController.text));
    Navigator.pop(context, groceryCategory);
  }

  void updateGroceryCategory() async {
    _groceryCategory.name = _nameController.text;
    await _groceryCategoryRepository.update(_groceryCategory);
    Navigator.pop(context, _groceryCategory);
  }
}
