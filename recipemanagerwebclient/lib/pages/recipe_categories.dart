import 'dart:convert';
import 'dart:html';

import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/api/request_urls.dart';
import 'package:recipemanagerwebclient/models/recipe_category.dart';
import 'package:recipemanagerwebclient/models/tables/recipe_category_table.dart';

import '../widgets/header.dart';
import '../widgets/navigation_drawer.dart';
import 'package:http/http.dart' as http;

class RecipeCategories extends StatefulWidget {
  const RecipeCategories({super.key});

  @override
  State<RecipeCategories> createState() => _RecipeCategoriesState();
}

class _RecipeCategoriesState extends State<RecipeCategories> {
  late Future<List<RecipeCategory>> categories;

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
                label: Padding(
                  padding: EdgeInsets.symmetric(vertical: 18.0), // here
                  child: Text("Rezeptkategorie hinzufügen"),
                ),
                onPressed: () {},
              ),
              Container(
                width: MediaQuery.of(context).size.width * 0.33,
                child: TextField(
                  decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    labelText: 'Suche',
                    prefixIcon: Icon(Icons.search),
                  ),
                ),
              )
            ],
          ),
          Divider(),
          FutureBuilder<List<RecipeCategory>>(
            future: categories,
            builder: (context, snapshot) {
              if (snapshot.hasData) {
                return RecipeCategoryTable(
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

  Future<List<RecipeCategory>> fetchCategories() async {
    final response = await http.get(Uri.parse(RequestURL.recipeCategories));

    if (response.statusCode == 200) {
      final map = jsonDecode(response.body);
      return (map as List).map((e) => RecipeCategory.fromJson(e)).toList();
    } else {
      throw Exception('Fail');
    }
  }

  DataRow createRow({required String abbreviation, required String name}) {
    return DataRow(cells: <DataCell>[
      DataCell(Text(abbreviation)),
      DataCell(Text(name)),
    ]);
  }
}
