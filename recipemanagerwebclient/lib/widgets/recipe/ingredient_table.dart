import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/widgets/popups/ingredient_popup.dart';
import 'package:recipemanagerwebclient/widgets/recipe/ingredient_importer.dart';

import '../../gen_exports.dart';
import '../../models/data_layer.dart';

class IngredientTable extends StatefulWidget {
  Recipe recipe;
  IngredientTable({Key? key, required this.recipe}) : super(key: key);

  @override
  _IngredientTableState createState() => _IngredientTableState();
}

class _IngredientTableState extends State<IngredientTable> {
  late Recipe _recipe;

  @override
  void initState() {
    super.initState();
    _recipe = widget.recipe;
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Text(AppLocalizations.of(context)!.ingredients,
            style: Theme.of(context).textTheme.headline6),
        ElevatedButton.icon(
          icon: Icon(Icons.data_object),
          label: Text(AppLocalizations.of(context)!.addMultipleIngredients),
          onPressed: () async {
            var newIngredient = await showDialog<List<Ingredient>>(
              context: context,
              barrierDismissible: false,
              builder: (context) => IngredientImporter(),
            ).then((value) {
              setState(() {
                _recipe.ingredients.addAll(value!);
              });
            });
          },
        ),
        DataTable(
          columns: <DataColumn>[
            DataColumn(
              label: Text(AppLocalizations.of(context)!.ingredient),
            ),
            DataColumn(
              label: Text(AppLocalizations.of(context)!.amount),
            ),
            DataColumn(
              label: Text(AppLocalizations.of(context)!.measurement),
            ),
            DataColumn(label: Text(AppLocalizations.of(context)!.actions))
          ],
          rows: _createRows(_recipe),
        ),
        IconButton(
          icon: Icon(Icons.add),
          onPressed: () async {
            var newIngredient = await showDialog<Ingredient>(
              context: context,
              barrierDismissible: false,
              builder: (context) => IngredientPopup(),
            );
            setState(() {
              _recipe.ingredients.add(newIngredient!);
            });
          },
        ),
      ],
    );
  }

  List<DataRow> _createRows(Recipe recipe) {
    var ingredientList = _recipe.ingredients.map((e) => _createRow(e)).toList();
    return ingredientList;
  }

  DataRow _createRow(Ingredient ingredient) {
    return DataRow(
      cells: <DataCell>[
        DataCell(Text(ingredient.groceryName)),
        DataCell(Text('${ingredient.amount}')),
        DataCell(Text(ingredient.measurement.name)),
        DataCell(
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              IconButton(
                icon: Icon(Icons.edit),
                splashRadius: 16.0,
                onPressed: () async {
                  var updatedIngredient = await showDialog(
                    context: context,
                    builder: (context) => IngredientPopup(
                      ingredient: ingredient,
                    ),
                  );
                  setState(() {
                    ingredient = updatedIngredient;
                  });
                },
              ),
              IconButton(
                icon: Icon(Icons.delete),
                splashRadius: 16.0,
                onPressed: () {
                  setState(() {
                    _recipe.ingredients.remove(ingredient);
                  });
                },
              ),
            ],
          ),
        ),
      ],
    );
  }
}
