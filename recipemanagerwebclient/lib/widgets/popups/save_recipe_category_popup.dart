import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/dtos/create_recipe_category.dart';

import '../../api/recipe_category_repository.dart';
import '../../models/recipe_category.dart';

class SaveRecipeCategoryPopup extends StatefulWidget {
  const SaveRecipeCategoryPopup({
    Key? key,
    this.recipeCategory,
  }) : super(key: key);

  final RecipeCategory? recipeCategory;

  @override
  State<SaveRecipeCategoryPopup> createState() =>
      _SaveRecipeCategoryPopupState();
}

class _SaveRecipeCategoryPopupState extends State<SaveRecipeCategoryPopup> {
  bool _isCreate = false;
  late RecipeCategory _recipeCategory;
  late TextEditingController _nameController;
  late TextEditingController _abbreviationController;
  final RecipeCategoryRepository _recipeCategoryRepository =
      RecipeCategoryRepository();

  @override
  void initState() {
    super.initState();
    _isCreate = widget.recipeCategory == null;
    _recipeCategory = widget.recipeCategory ?? RecipeCategory();
    _nameController = TextEditingController(text: _recipeCategory.name);
    _abbreviationController =
        TextEditingController(text: _recipeCategory.abbreviation);
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Text(_isCreate
          ? 'Rezeptkategorie hinzufügen'
          : 'Rezeptkategorie verändern'),
      content: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          TextField(
            controller: _nameController,
            decoration: InputDecoration(
              label: Text("Name"),
            ),
          ),
          TextField(
            controller: _abbreviationController,
            decoration: InputDecoration(
              label: Text("Abkürzung"),
            ),
          ),
        ],
      ),
      actionsAlignment: MainAxisAlignment.center,
      actions: [
        TextButton(
          onPressed: () {
            if (_isCreate) {
              addRecipeCategory();
            } else {
              updateRecipeCategory();
            }
          },
          child: Text('Speichern'),
        )
      ],
    );
  }

  void addRecipeCategory() async {
    CreateRecipeCategory dto = CreateRecipeCategory(
        name: _nameController.text, abbreviation: _abbreviationController.text);

    RecipeCategory recipeCategory = await _recipeCategoryRepository.add(dto);
    Navigator.pop(context, recipeCategory);
  }

  void updateRecipeCategory() async {
    _recipeCategory.name = _nameController.text;
    _recipeCategory.abbreviation = _abbreviationController.text;
    await _recipeCategoryRepository.update(_recipeCategory);
    Navigator.pop(context, _recipeCategory);
  }
}
