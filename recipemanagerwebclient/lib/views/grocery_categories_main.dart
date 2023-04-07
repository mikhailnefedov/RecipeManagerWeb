import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/api/grocery_category_repository.dart';
import 'package:recipemanagerwebclient/models/grocery_category.dart';
import 'package:recipemanagerwebclient/views/grocery_categories_view.dart';

import '../widgets/header.dart';
import '../widgets/navigation_drawer.dart';

class GroceryCategoriesMain extends StatefulWidget {
  static const route = '/grocerycategories';

  const GroceryCategoriesMain({super.key});

  @override
  State<GroceryCategoriesMain> createState() => _GroceryCategoriesMainState();
}

class _GroceryCategoriesMainState extends State<GroceryCategoriesMain> {
  late GroceryCategoryRepository _groceryCategoryRepository;
  late Future<List<GroceryCategory>> _categories;

  @override
  void initState() {
    super.initState();
    _groceryCategoryRepository = GroceryCategoryRepository();
    _categories = _groceryCategoryRepository.fetchAll();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      drawer: NavigationDrawer(),
      appBar: Header(),
      body: FutureBuilder<List<GroceryCategory>>(
        future: _categories,
        builder: (context, snapshot) {
          if (snapshot.hasData) {
            return GroceryCategoriesView(
              groceryCategories: snapshot.requireData,
            );
          } else if (snapshot.hasError) {
            return Text('${snapshot.error}');
          }
          return const CircularProgressIndicator();
        },
      ),
    );
  }
}
