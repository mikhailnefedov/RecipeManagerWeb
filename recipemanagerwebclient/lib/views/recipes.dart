import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/api/http_helper.dart';
import 'package:recipemanagerwebclient/models/small_recipe.dart';
import 'package:recipemanagerwebclient/views/recipe_view.dart';
import '../widgets/header.dart';
import '../widgets/navigation_drawer.dart';

class Recipes extends StatefulWidget {
  static const route = '/recipes';

  const Recipes({super.key});

  @override
  State<Recipes> createState() => _RecipesState();
}

class _RecipesState extends State<Recipes> {
  late Future<List<SmallRecipe>> _recipes;

  @override
  void initState() {
    super.initState();
    _recipes = HttpHelper.fetchSmallRecipes();
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
                  Navigator.pushNamed(context, RecipeView.route);
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
                                    RecipeView.route,
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
}
