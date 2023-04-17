import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/api/small_recipes_repository.dart';
import 'package:recipemanagerwebclient/models/small_recipe.dart';
import 'package:recipemanagerwebclient/views/recipes_view.dart';
import '../widgets/header.dart';
import '../widgets/navigation_drawer.dart';

class RecipesMain extends StatefulWidget {
  static const route = '/recipes';

  const RecipesMain({super.key});

  @override
  State<RecipesMain> createState() => _RecipesMainState();
}

class _RecipesMainState extends State<RecipesMain> {
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
      body: FutureBuilder<List<SmallRecipe>>(
        future: _recipes,
        builder: (context, snapshot) {
          if (snapshot.hasData) {
            return RecipesView(recipes: snapshot.requireData);
          } else if (snapshot.hasError) {
            return Text('${snapshot.error}');
          }
          return Center(child: const CircularProgressIndicator());
        },
      ),
    );
  }
}
