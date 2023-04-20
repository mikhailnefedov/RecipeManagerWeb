import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/api/small_recipes_repository.dart';
import 'package:recipemanagerwebclient/models/small_recipe.dart';
import 'package:recipemanagerwebclient/ui/recipe_list/recipe_list.dart';
import 'package:recipemanagerwebclient/widgets/loader_helper/loading.dart';
import '../../widgets/header.dart';
import '../../widgets/loader_helper/loader_error.dart';
import '../../widgets/navigation_drawer.dart';

class RecipesLoader extends StatefulWidget {
  static const route = '/recipes';

  const RecipesLoader({super.key});

  @override
  State<RecipesLoader> createState() => _RecipesLoaderState();
}

class _RecipesLoaderState extends State<RecipesLoader> {
  late SmallRecipeRepository _smallRecipeRepository;

  @override
  void initState() {
    super.initState();
    _smallRecipeRepository = SmallRecipeRepository();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      drawer: NavigationDrawer(),
      appBar: Header(),
      body: FutureBuilder<List<SmallRecipe>>(
        future: _smallRecipeRepository.fetchAll(),
        builder: (context, snapshot) {
          if (snapshot.hasData) {
            return RecipeList(recipes: snapshot.requireData);
          } else if (snapshot.hasError) {
            return LoaderError<SmallRecipe>(snapshot: snapshot);
          }
          return Loading();
        },
      ),
    );
  }
}
