import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/models/data_layer.dart';

import '../widgets/popups/save_recipe_category_popup.dart';
import '../widgets/tables/recipe_category_table.dart';

class RecipeCategoriesView extends StatefulWidget {
  RecipeCategoriesView({Key? key, required this.recipeCategories})
      : super(key: key);

  final List<RecipeCategory> recipeCategories;

  @override
  State<RecipeCategoriesView> createState() => _RecipeCategoriesViewState();
}

class _RecipeCategoriesViewState extends State<RecipeCategoriesView> {
  late TextEditingController _searchController;
  late List<RecipeCategory> _recipeCategories;

  @override
  void initState() {
    super.initState();
    _searchController = TextEditingController(text: '');
    _recipeCategories = widget.recipeCategories;
  }

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: Center(
        child: Column(
          children: [
            SizedBox(
              height: 8,
            ),
            SizedBox(
              width: MediaQuery.of(context).size.width * 0.5,
              child: TextFormField(
                controller: _searchController,
                decoration: InputDecoration(
                  labelText: "Suche",
                  prefixIcon: Icon(Icons.search),
                ),
                onChanged: (value) {
                  setState(() {});
                },
              ),
            ),
            SizedBox(
              height: 8,
            ),
            SizedBox(
              width: MediaQuery.of(context).size.width * 0.5,
              child: ElevatedButton.icon(
                icon: Icon(Icons.add),
                label: Text("Hinzufügen"),
                onPressed: () {
                  showDialog(
                    context: context,
                    builder: (context) => SaveRecipeCategoryPopup(),
                  ).then((value) {
                    RecipeCategory recipeCategory = value as RecipeCategory;
                    setState(() {
                      _recipeCategories.add(recipeCategory);
                    });
                  });
                },
              ),
            ),
            SizedBox(
              height: 8,
            ),
            SizedBox(
              width: MediaQuery.of(context).size.width * 0.5,
              child: RecipeCategoryTable(
                categories: _recipeCategories
                    .where((element) =>
                        element.name.contains(_searchController.text))
                    .toList(),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
