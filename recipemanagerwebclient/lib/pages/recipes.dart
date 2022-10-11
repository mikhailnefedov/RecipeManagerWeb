import 'dart:convert';
import 'dart:developer';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:recipemanagerwebclient/models/small_recipe.dart';
import '../api/request_urls.dart';
import '../widgets/header.dart';
import '../widgets/navigation_drawer.dart';

class Recipes extends StatefulWidget {
  const Recipes({super.key});

  @override
  State<Recipes> createState() => _RecipesState();
}

class _RecipesState extends State<Recipes> {
  late Future<List<SmallRecipe>> _recipes;

  @override
  void initState() {
    super.initState();
    _recipes = fetchRecipes();
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
                label: Text("Rezepte hinzufügen"),
                onPressed: () {
                  Navigator.pushNamed(context, "/createrecipe");
                },
              ),
            ],
          ),
          Divider(),
          FutureBuilder<List<SmallRecipe>>(
            future: _recipes,
            builder: (context, snapshot) {
              if (snapshot.hasData) {
                return Expanded(
                  child: ListView.builder(
                      itemCount: snapshot.requireData.length,
                      scrollDirection: Axis.vertical,
                      shrinkWrap: true,
                      itemBuilder: (BuildContext context, int index) {
                        return Card(
                          child: Column(
                            mainAxisSize: MainAxisSize.min,
                            children: <Widget>[
                              ListTile(
                                title: Text(snapshot.requireData[index].name),
                                subtitle: Text(snapshot
                                    .requireData[index].recipeCategory.name),
                                onTap: () {
                                  Navigator.pushNamed(
                                    context,
                                    "/recipe",
                                    arguments: {
                                      "id": snapshot.requireData[index].id
                                    },
                                  );
                                },
                              ),
                            ],
                          ),
                        );
                      }),
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

  Future<List<SmallRecipe>> fetchRecipes() async {
    final response = await http.get(Uri.parse(RequestURL.smallRecipes));

    if (response.statusCode == 200) {
      final map = jsonDecode(response.body);
      return (map as List).map((e) => SmallRecipe.fromJson(e)).toList();
    } else {
      throw Exception('Fail');
    }
  }
}
