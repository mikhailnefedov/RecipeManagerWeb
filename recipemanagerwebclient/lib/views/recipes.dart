import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/api/small_recipes_repository.dart';
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
  late SmallRecipeRepository _smallRecipeRepository;
  late Future<List<SmallRecipe>> _recipes;

  @override
  void initState() {
    super.initState();
    _smallRecipeRepository = SmallRecipeRepository();
    _recipes = _smallRecipeRepository.fetchAll();
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
                  Navigator.pushNamed(
                    context,
                    RecipeView.route,
                    arguments: {"isNew": true},
                  );
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
                  child: GridView.builder(
                      padding: EdgeInsets.only(left: 20, right: 20),
                      shrinkWrap: true,
                      gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                        crossAxisCount: 3,
                        crossAxisSpacing: 20,
                        mainAxisSpacing: 8,
                        childAspectRatio: 2,
                      ),
                      itemCount: snapshot.requireData.length,
                      scrollDirection: Axis.vertical,
                      itemBuilder: (BuildContext context, int index) {
                        return Padding(
                          padding: (index % 2) == 0
                              ? EdgeInsets.only(bottom: 10)
                              : EdgeInsets.only(top: 10),
                          child: Card(
                            shape: RoundedRectangleBorder(
                              borderRadius: BorderRadius.circular(15),
                            ),
                            child: InkWell(
                              borderRadius: BorderRadius.circular(15),
                              onTap: () {
                                Navigator.pushNamed(
                                  context,
                                  RecipeView.route,
                                  arguments: {
                                    "id": snapshot.requireData[index].id
                                  },
                                );
                              },
                              child: Container(
                                child: Text(snapshot.requireData[index].name),
                              ),
                            ),
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
