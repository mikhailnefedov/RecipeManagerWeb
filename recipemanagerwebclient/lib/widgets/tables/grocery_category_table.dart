import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

import 'package:recipemanagerwebclient/api/request_urls.dart';
import '../../models/grocery_category.dart';

class GroceryCategoryTable extends StatefulWidget {
  GroceryCategoryTable({Key? key, required this.categories}) : super(key: key);

  final List<GroceryCategory> categories;

  @override
  State<GroceryCategoryTable> createState() => _GroceryCategoryTableState();
}

class _GroceryCategoryTableState extends State<GroceryCategoryTable> {
  late List<GroceryCategory> _categories;
  int _currentSortColumn = 0;
  bool _isAscending = false;

  @override
  void initState() {
    super.initState();
    _categories = widget.categories;
  }

  @override
  Widget build(BuildContext context) {
    return DataTable(
      sortColumnIndex: _currentSortColumn,
      sortAscending: _isAscending,
      columns: <DataColumn>[
        DataColumn(
          label: Text('Name'),
          onSort: ((columnIndex, _) {
            setState(() {
              _currentSortColumn = columnIndex;
              if (_isAscending == true) {
                _isAscending = false;
                _categories.sort((a, b) => a.name.compareTo(b.name));
              } else {
                _isAscending = true;
                _categories.sort((a, b) => b.name.compareTo(a.name));
              }
            });
          }),
        ),
        DataColumn(
          label: Text(""),
        )
      ],
      rows: _categories.map((e) => createRow(e)).toList(),
    );
  }

  DataRow createRow(GroceryCategory category) {
    return DataRow(
      cells: <DataCell>[
        DataCell(Text(category.name)),
        DataCell(IconButton(
          icon: Icon(Icons.delete),
          color: Colors.red,
          splashRadius: 20.0,
          onPressed: () {
            deleteCategory(category);
          },
        ))
      ],
    );
  }

  Future<void> deleteCategory(GroceryCategory category) async {
    await http.delete(
      Uri.parse("${RequestURL.groceryCategories}/${category.id}"),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
    );

    setState(() {
      _categories.remove(category);
    });
  }
}
