import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

import 'package:recipemanagerwebclient/api/request_urls.dart';
import '../../models/grocery_item.dart';

class GroceryItemTable extends StatefulWidget {
  GroceryItemTable({Key? key, required this.items}) : super(key: key);

  final List<GroceryItem> items;

  @override
  State<GroceryItemTable> createState() => _GroceryItemTableState();
}

class _GroceryItemTableState extends State<GroceryItemTable> {
  late List<GroceryItem> _items;
  int _currentSortColumn = 0;
  bool _isAscending = false;

  @override
  void initState() {
    super.initState();
    _items = widget.items;
    _items = _items.take(10).toList();
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
                _items.sort((a, b) => a.name.compareTo(b.name));
              } else {
                _isAscending = true;
                _items.sort((a, b) => b.name.compareTo(a.name));
              }
            });
          }),
        ),
        DataColumn(
          label: Text("Kategorie"),
        ),
        DataColumn(
          label: Text(""),
        )
      ],
      rows: _items.map((e) => createRow(e)).toList(),
    );
  }

  DataRow createRow(GroceryItem item) {
    return DataRow(
      cells: <DataCell>[
        DataCell(Text(item.name)),
        DataCell(Text(item.groceryCategoryName)),
        DataCell(IconButton(
          icon: Icon(Icons.delete),
          color: Colors.red,
          splashRadius: 20.0,
          onPressed: () {
            deleteCategory(item);
          },
        ))
      ],
    );
  }

  Future<void> deleteCategory(GroceryItem item) async {
    await http.delete(
      Uri.parse("${RequestURL.groceryItems}/${item.id}"),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
    );

    setState(() {
      _items.remove(item);
    });
  }
}
