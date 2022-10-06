import 'package:flutter/material.dart';

import '../recipe_category.dart';

class RecipeCategoryTable extends StatelessWidget {
  RecipeCategoryTable({Key? key, required List<RecipeCategory> categories})
      : _categories = categories,
        super(key: key);

  final List<RecipeCategory> _categories;

  @override
  Widget build(BuildContext context) {
    return DataTable(
      columns: const <DataColumn>[
        DataColumn(
          label: Expanded(
            child: Text(
              'Name',
              style: TextStyle(fontStyle: FontStyle.italic),
            ),
          ),
        ),
        DataColumn(
          label: Expanded(
            child: Text(
              'Abbreviation',
              style: TextStyle(fontStyle: FontStyle.italic),
            ),
          ),
        ),
      ],
      rows: _categories.map((e) => createRow(e)).toList(),
    );
  }

  DataRow createRow(RecipeCategory category) {
    return DataRow(
      cells: <DataCell>[
        DataCell(Text(category.name)),
        DataCell(Text(category.abbreviation)),
      ],
    );
  }
}
