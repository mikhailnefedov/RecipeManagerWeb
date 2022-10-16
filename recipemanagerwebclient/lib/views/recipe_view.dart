import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/api/http_helper.dart';
import 'package:recipemanagerwebclient/widgets/recipe/instruction_steps_list.dart';
import 'package:recipemanagerwebclient/widgets/recipe/recipe_header.dart';

import '../models/data_layer.dart';
import '../widgets/header.dart';
import '../widgets/navigation_drawer.dart';

class RecipeView extends StatefulWidget {
  static const route = '/recipe';

  const RecipeView({Key? key}) : super(key: key);

  @override
  State<RecipeView> createState() => _RecipeViewState();
}

class _RecipeViewState extends State<RecipeView> {
  List<DropdownMenuItem<RecipeCategory>> recipeCategories = [];
  List<DropdownMenuItem<PortionUnit>> portionUnits =
      PortionUnit.values.map((e) {
    return DropdownMenuItem<PortionUnit>(
      value: e,
      child: Text(e.name),
    );
  }).toList();

  late Recipe _recipe;

  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    //Map arguments = ModalRoute.of(context)?.settings.arguments as Map;
    //int recipeId = arguments["id"];

    int recipeId = 1;

    return Scaffold(
      drawer: NavigationDrawer(),
      appBar: Header(),
      floatingActionButton: IconButton(
          icon: Icon(Icons.save),
          onPressed: () {
            print(_recipe.toJson());
          }),
      body: FutureBuilder<Recipe>(
        future: HttpHelper.fetchRecipe(recipeId),
        builder: (context, snapshot) {
          if (snapshot.hasData) {
            _recipe = snapshot.requireData;
            return SingleChildScrollView(
              child: Center(
                child: Padding(
                  padding: const EdgeInsets.fromLTRB(8.0, 16.0, 8.0, 0.0),
                  child: Column(
                    children: [
                      RecipeHeader(
                        recipe: snapshot.requireData,
                      ),
                      DataTable(
                        columns: const <DataColumn>[
                          DataColumn(
                            label: Text('Lebensmittel'),
                          ),
                          DataColumn(
                            label: Text("Menge"),
                          ),
                          DataColumn(
                            label: Text("Einheit"),
                          ),
                        ],
                        rows: snapshot.requireData.ingredients
                            .map((e) => createRow(e))
                            .toList(),
                      ),
                      Divider(),
                      InstructionStepsList(recipe: _recipe),
                    ],
                  ),
                ),
              ),
            );
          } else {
            return CircularProgressIndicator();
          }
        },
      ),
    );
  }

  DataRow createRow(Ingredient ingredient) {
    return DataRow(
      cells: <DataCell>[
        DataCell(Text(ingredient.groceryName)),
        DataCell(Text('${ingredient.amount}')),
        DataCell(Text(ingredient.measurement.name)),
      ],
    );
  }
}
