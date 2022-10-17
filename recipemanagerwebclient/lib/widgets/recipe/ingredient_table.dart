import 'package:flutter/material.dart';

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
        DataTable(
          columns: const <DataColumn>[
            DataColumn(
              label: Text('Grocery'),
            ),
            DataColumn(
              label: Text("Amount"),
            ),
            DataColumn(
              label: Text("Measurement"),
            ),
            DataColumn(label: Text('Aktionen'))
          ],
          rows: _createRows(_recipe),
        ),
        IconButton(
          icon: Icon(Icons.add),
          onPressed: () {},
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
                onPressed: () {},
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
