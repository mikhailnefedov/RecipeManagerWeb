import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/api/grocery_category_repository.dart';
import 'package:recipemanagerwebclient/models/data_layer.dart';

class GroceryCategoryDropwdown extends StatefulWidget {
  GroceryCategoryDropwdown(
      {Key? key,
      required this.groceryCategories,
      required this.selectedCategory})
      : super(key: key);

  final List<GroceryCategory> groceryCategories;
  GroceryCategory selectedCategory;

  @override
  State<GroceryCategoryDropwdown> createState() =>
      _GroceryCategoryDropwdownState();
}

class _GroceryCategoryDropwdownState extends State<GroceryCategoryDropwdown> {
  late List<GroceryCategory> _groceryCategories;
  late GroceryCategory _selectedCategory;

  @override
  void initState() {
    super.initState();
    _groceryCategories = widget.groceryCategories;
    _selectedCategory = widget.selectedCategory;
  }

  @override
  Widget build(BuildContext context) {
    return DropdownButton(
      value: _selectedCategory,
      items: _groceryCategories.map<DropdownMenuItem<GroceryCategory>>((e) {
        return DropdownMenuItem<GroceryCategory>(
          value: e,
          child: Text(e.name),
        );
      }).toList(),
      onChanged: (value) {
        setState(() {
          _selectedCategory = value!;
          widget.selectedCategory = _selectedCategory;
        });
      },
    );
  }
}
