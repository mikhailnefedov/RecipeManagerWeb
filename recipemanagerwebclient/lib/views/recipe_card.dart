import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/models/data_layer.dart';
import 'package:recipemanagerwebclient/views/recipe_view.dart';

class RecipeCard extends StatelessWidget {
  RecipeCard({Key? key, required this.recipe}) : super(key: key);

  SmallRecipe recipe;

  @override
  Widget build(BuildContext context) {
    return Card(
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(15),
      ),
      child: InkWell(
        borderRadius: BorderRadius.circular(15),
        onTap: () {
          Navigator.pushNamed(
            context,
            RecipeView.route,
            arguments: {"id": recipe.id},
          );
        },
        child: Container(
          child: Column(
            children: [
              Padding(
                padding: const EdgeInsets.only(top: 5),
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Expanded(
                      child: Text(
                        recipe.name,
                        softWrap: true,
                        maxLines: 2,
                        textAlign: TextAlign.center,
                        style: Theme.of(context).textTheme.headlineSmall,
                      ),
                    ),
                  ],
                ),
              ),
              Divider(),
              Expanded(
                child: GridView.count(
                  crossAxisCount: 2,
                  childAspectRatio: 4.0,
                  children: [
                    Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        Icon(Icons.category),
                        Text(recipe.recipeCategory.name),
                      ],
                    ),
                    Center(
                      child: Text(
                          "${recipe.amount} ${recipe.portionUnit.toShortString()}"),
                    ),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        Icon(recipe.vegetarian ? Icons.check : Icons.close),
                        Text("vegetarisch"),
                      ],
                    ),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        Icon(Icons.timelapse),
                        Text(_convertToTimeString(recipe.time)),
                      ],
                    ),
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }

  String _convertToTimeString(int time) {
    int min = time % 60;
    int hours = (time - min) / 60 as int;
    return "$hours:${min}h";
  }
}
