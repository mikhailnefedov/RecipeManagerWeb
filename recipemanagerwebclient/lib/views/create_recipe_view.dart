import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:recipemanagerwebclient/api/http_helper.dart';
import 'package:recipemanagerwebclient/dtos/create_recipe.dart';

import '../api/request_urls.dart';
import '../models/data_layer.dart';
import '../widgets/header.dart';
import '../widgets/navigation_drawer.dart';

class CreateRecipeView extends StatefulWidget {
  static const route = '/createrecipe';

  const CreateRecipeView({Key? key}) : super(key: key);

  @override
  State<CreateRecipeView> createState() => _CreateRecipeViewState();
}

class _CreateRecipeViewState extends State<CreateRecipeView> {
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
  List<DataRow> dataRows = [];
  final sourceController = TextEditingController();
  final commentController = TextEditingController();
  RecipeCategory recipeCategory =
      RecipeCategory(id: 100, abbreviation: '', name: 'Placeholder');

  CreateRecipe newRecipe = CreateRecipe(ingredients: [], instructions: []);

  @override
  void initState() {
    super.initState();
    nameController.addListener(() => newRecipe.name = nameController.text);
    amountController.text = '0.0';
    amountController.addListener(
        () => newRecipe.amount = double.parse(amountController.text));
    timeController.text = '0';
    timeController
        .addListener(() => newRecipe.time = int.parse(timeController.text));
    sourceController
        .addListener(() => newRecipe.source = sourceController.text);
    commentController
        .addListener(() => newRecipe.comment = commentController.text);
    createDropDownMenu();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      drawer: NavigationDrawer(),
      appBar: Header(),
      floatingActionButton: IconButton(
        icon: Icon(Icons.save),
        onPressed: () {
          postRecipe();
        },
      ),
      body: SingleChildScrollView(
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
                value: recipeCategory,
                items: recipeCategories,
                onChanged: (value) {
                  setState(() {
                    recipeCategory = value!;
                  });
                },
              ),
              SizedBox(
                height: 16.0,
              ),
              Row(
                children: [
                  Expanded(
                    child: TextFormField(
                      keyboardType: TextInputType.number,
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
                    value: newRecipe.portionUnit,
                    items: portionUnits,
                    onChanged: (value) {
                      setState(() {
                        newRecipe.portionUnit = value!;
                      });
                    },
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
                    value: newRecipe.vegetarian,
                    onChanged: (value) {
                      setState(() {
                        newRecipe.vegetarian = !newRecipe.vegetarian;
                      });
                    },
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
                rows: dataRows,
              ),
              Divider(),
              Text('Anleitung:'),
              ListView.builder(
                shrinkWrap: true,
                itemCount: newRecipe.instructions.length,
                itemBuilder: (context, index) {
                  var textController = TextEditingController()
                    ..text = newRecipe.instructions[index].text;
                  textController.addListener(
                    () {
                      newRecipe.instructions[index].text = textController.text;
                    },
                  );
                  return TextFormField(controller: textController);
                },
              ),
              IconButton(
                onPressed: () {
                  setState(() {
                    newRecipe.instructions.add(CreateInstruction(text: ''));
                  });
                },
                icon: Icon(Icons.add),
              )
            ],
          ),
        ),
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

  Future<void> postRecipe() async {
    newRecipe.recipeCategoryId = recipeCategory.id;
    print(jsonEncode(newRecipe.toJson()));

    await http.post(
      Uri.parse(RequestURL.recipes),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: jsonEncode(newRecipe.toJson()),
    );
  }

  void createDropDownMenu() async {
    List<RecipeCategory> fetchedCategories =
        await HttpHelper.fetchRecipeCategories();
    setState(() {
      recipeCategories = fetchedCategories.map((e) {
        return DropdownMenuItem<RecipeCategory>(
          value: e,
          child: Text(e.name),
        );
      }).toList();
      recipeCategory = fetchedCategories[0];
    });
  }
}
