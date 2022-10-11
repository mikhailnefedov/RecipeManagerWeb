import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/models/grocery_category.dart';
import 'package:recipemanagerwebclient/widgets/tables/grocery_category_table.dart';

import '../api/request_urls.dart';
import '../widgets/header.dart';
import '../widgets/navigation_drawer.dart';

import 'package:http/http.dart' as http;

import '../widgets/popups/create_grocery_category_popup.dart';

class GroceryCategories extends StatefulWidget {
  const GroceryCategories({super.key});

  @override
  State<GroceryCategories> createState() => _GroceryCategoriesState();
}

class _GroceryCategoriesState extends State<GroceryCategories> {
  late Future<List<GroceryCategory>> categories;

  @override
  void initState() {
    super.initState();
    categories = fetchCategories();
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
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: [
              ElevatedButton.icon(
                icon: Icon(Icons.add),
                label: Text("Lebensmittelkategorie hinzufügen"),
                onPressed: () {
                  showDialog(
                    context: context,
                    builder: (context) => CreateGroceryCategoryPopup(),
                  );
                },
              ),
            ],
          ),
          Divider(),
          FutureBuilder<List<GroceryCategory>>(
            future: categories,
            builder: (context, snapshot) {
              if (snapshot.hasData) {
                return GroceryCategoryTable(
                  categories: snapshot.requireData,
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
