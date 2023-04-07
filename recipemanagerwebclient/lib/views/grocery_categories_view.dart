import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/models/grocery_category.dart';

import '../widgets/popups/save_grocery_category_popup.dart';
import '../widgets/tables/grocery_category_table.dart';

class GroceryCategoriesView extends StatefulWidget {
  GroceryCategoriesView({Key? key, required this.groceryCategories})
      : super(key: key);

  final List<GroceryCategory> groceryCategories;

  @override
  State<GroceryCategoriesView> createState() => _GroceryCategoriesViewState();
}

class _GroceryCategoriesViewState extends State<GroceryCategoriesView> {
  late TextEditingController _searchController;
  late List<GroceryCategory> _groceryCategories;

  @override
  void initState() {
    super.initState();
    _searchController = TextEditingController(text: '');
    _groceryCategories = widget.groceryCategories;
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
                    builder: (context) => SaveGroceryCategoryPopup(),
                  );
                },
              ),
            ),
            SizedBox(
              height: 8,
            ),
            SizedBox(
              width: MediaQuery.of(context).size.width * 0.5,
              child: GroceryCategoryTable(
                categories: _groceryCategories
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
