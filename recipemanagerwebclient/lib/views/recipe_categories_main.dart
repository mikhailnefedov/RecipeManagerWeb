import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/api/recipe_category_repository.dart';
import 'package:recipemanagerwebclient/models/recipe_category.dart';
import 'package:recipemanagerwebclient/views/recipe_categories_view.dart';
import 'package:recipemanagerwebclient/widgets/tables/recipe_category_table.dart';

import '../widgets/header.dart';
import '../widgets/navigation_drawer.dart';

import '../widgets/popups/save_recipe_category_popup.dart';

class RecipeCategoriesMain extends StatefulWidget {
  static const route = '/recipecategories';

  const RecipeCategoriesMain({super.key});

  @override
  State<RecipeCategoriesMain> createState() => _RecipeCategoriesMainState();
}

class _RecipeCategoriesMainState extends State<RecipeCategoriesMain> {
  late RecipeCategoryRepository _recipeCategoryRepository;
  late Future<List<RecipeCategory>> categories;

  @override
  void initState() {
    super.initState();
    _recipeCategoryRepository = RecipeCategoryRepository();
    categories = _recipeCategoryRepository.fetchAll();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      drawer: NavigationDrawer(),
      appBar: Header(),
      body: FutureBuilder<List<RecipeCategory>>(
        future: categories,
        builder: (context, snapshot) {
          if (snapshot.hasData) {
            return RecipeCategoriesView(recipeCategories: snapshot.requireData);
          } else if (snapshot.hasError) {
            return Text('${snapshot.error}');
          }
          return Center(
            child: const CircularProgressIndicator(),
          );
        },
      ),
    );
  }
}
