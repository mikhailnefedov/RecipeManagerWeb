import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/api/http_helper.dart';

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
  final nameController = TextEditingController();
  List<DropdownMenuItem<RecipeCategory>> recipeCategories = [];
  final amountController = TextEditingController();
  List<DropdownMenuItem<PortionUnit>> portionUnits =
      PortionUnit.values.map((e) {
    return DropdownMenuItem<PortionUnit>(
      value: e,
      child: Text(e.name),
    );
  }).toList();
  final timeController = TextEditingController();
  bool vegetarian = true;
  final sourceController = TextEditingController();
  final commentController = TextEditingController();

  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    Map arguments = ModalRoute.of(context)?.settings.arguments as Map;
    int recipeId = arguments["id"];

    return Scaffold(
      drawer: NavigationDrawer(),
      appBar: Header(),
      body: FutureBuilder<Recipe>(
        future: HttpHelper.fetchRecipe(recipeId),
        builder: (context, snapshot) {
          if (snapshot.hasData) {
            fillControllers(snapshot.requireData);

            return SingleChildScrollView(
              child: Center(
                child: Column(
                  children: [
                    SizedBox(
                      height: 16.0,
                    ),
                    TextField(
                      decoration: InputDecoration(
                        border: OutlineInputBorder(),
                        labelText: 'Name',
                      ),
                      controller: nameController,
                    ),
                    SizedBox(
                      height: 16.0,
                    ),
                    DropdownButton(
                      value: snapshot.requireData.recipeCategory,
                      items: recipeCategories,
                      onChanged: (value) {},
                    ),
                    SizedBox(
                      height: 16.0,
                    ),
                    Row(
                      children: [
                        Expanded(
                          child: TextFormField(
                            decoration: InputDecoration(
                              border: OutlineInputBorder(),
                              labelText: 'Amount',
                            ),
                            controller: amountController,
                          ),
                        ),
                        SizedBox(
                          width: 16.0,
                        ),
                        DropdownButton(
                          value: snapshot.requireData.portionUnit,
                          items: portionUnits,
                          onChanged: (value) {},
                        ),
                      ],
                    ),
                    SizedBox(height: 16.0),
                    TextFormField(
                      decoration: InputDecoration(
                        border: OutlineInputBorder(),
                        labelText: 'Time',
                      ),
                      controller: timeController,
                    ),
                    Row(
                      children: [
                        Checkbox(
                          value: vegetarian,
                          onChanged: (value) {},
                        ),
                        Text('vegetarian'),
                      ],
                    ),
                    SizedBox(height: 16.0),
                    TextFormField(
                      decoration: InputDecoration(
                        border: OutlineInputBorder(),
                        labelText: 'Source',
                      ),
                      controller: sourceController,
                    ),
                    SizedBox(height: 16.0),
                    TextFormField(
                      decoration: InputDecoration(
                        border: OutlineInputBorder(),
                        labelText: 'Comment',
                      ),
                      controller: commentController,
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
                    Text('Anleitung:'),
                    ListView.builder(
                      shrinkWrap: true,
                      itemCount: snapshot.requireData.instructions.length,
                      itemBuilder: (context, index) {
                        var textController = TextEditingController()
                          ..text =
                              snapshot.requireData.instructions[index].text;
                        return TextFormField(controller: textController);
                      },
                    ),
                  ],
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

  void fillControllers(Recipe recipe) {
    nameController.text = recipe.name;
    recipeCategories.add(DropdownMenuItem<RecipeCategory>(
      value: recipe.recipeCategory,
      child: Text(recipe.recipeCategory.name),
    ));
    amountController.text = "${recipe.amount}";
    timeController.text = "${recipe.time}";
    vegetarian = recipe.vegetarian;
    sourceController.text = recipe.source;
    commentController.text = recipe.comment;
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
