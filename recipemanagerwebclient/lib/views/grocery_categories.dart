import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/api/grocery_category_repository.dart';
import 'package:recipemanagerwebclient/models/grocery_category.dart';
import 'package:recipemanagerwebclient/widgets/tables/grocery_category_table.dart';

import '../widgets/header.dart';
import '../widgets/navigation_drawer.dart';

import '../widgets/popups/save_grocery_category_popup.dart';

class GroceryCategories extends StatefulWidget {
  static const route = '/grocerycategories';

  const GroceryCategories({super.key});

  @override
  State<GroceryCategories> createState() => _GroceryCategoriesState();
}

class _GroceryCategoriesState extends State<GroceryCategories> {
  late GroceryCategoryRepository _groceryCategoryRepository;
  late Future<List<GroceryCategory>> _categories;
  late TextEditingController _searchController;
  String _searchString = "";

  @override
  void initState() {
    super.initState();
    _groceryCategoryRepository = GroceryCategoryRepository();
    _categories = _groceryCategoryRepository.fetchAll();
    _searchController = TextEditingController(text: _searchString);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      drawer: NavigationDrawer(),
      appBar: Header(),
      body: Column(
        children: [
          SizedBox(
            height: 16,
          ),
          Row(
            children: [
              SizedBox(
                width: 8,
              ),
              ElevatedButton.icon(
                icon: Icon(Icons.add),
                label: Text("Hinzufügen"),
                onPressed: () {
                  showDialog(
                    context: context,
                    builder: (context) => SaveGroceryCategoryPopup(),
                  );
                },
              ),
            ],
          ),
          FutureBuilder<List<GroceryCategory>>(
            future: _categories,
            builder: (context, snapshot) {
              if (snapshot.hasData) {
                return Padding(
                  padding: const EdgeInsets.all(8.0),
                  child: GroceryCategoryTable(
                    categories: snapshot.requireData
                        .where(
                            (element) => element.name.contains(_searchString))
                        .toList(),
                  ),
                );
              } else if (snapshot.hasError) {
                return Text('${snapshot.error}');
              }
              return const CircularProgressIndicator();
            },
          ),
        ],
      ),
    );
  }
}
