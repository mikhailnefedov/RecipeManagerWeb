import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:recipemanagerwebclient/api/grocery_item_repository.dart';

import 'package:recipemanagerwebclient/api/request_urls.dart';
import 'package:recipemanagerwebclient/widgets/popups/save_grocery_item_popup.dart';
import '../../models/grocery_item.dart';

class GroceryItemTable extends StatefulWidget {
  GroceryItemTable({Key? key, required this.items}) : super(key: key);

  final List<GroceryItem> items;

  @override
  State<GroceryItemTable> createState() => _GroceryItemTableState();
}

class _GroceryItemTableState extends State<GroceryItemTable> {
  late List<GroceryItem> _items;
  int _sortColumnIndex = 1;
  bool _isAscending = false;

  @override
  Widget build(BuildContext context) {
    _items = widget.items;
    return LayoutBuilder(
      builder: (context, constraints) => PaginatedDataTable(
          header: Text('Lebensmittel'),
          showFirstLastButtons: true,
          columns: [
            DataColumn(
              label: Row(
                children: [
                  Text("Name"),
                  _sortColumnIndex == 0
                      ? _isAscending
                          ? Icon(Icons.arrow_upward)
                          : Icon(Icons.arrow_downward)
                      : Icon(Icons.sort),
                ],
              ),
              onSort: (columnIndex, _) {
                setState(() {
                  _sortColumnIndex = columnIndex;
                  _isAscending = !_isAscending;
                  _isAscending
                      ? _items.sort((a, b) => a.name.compareTo(b.name))
                      : _items.sort((a, b) => b.name.compareTo(a.name));
                });
              },
            ),
            DataColumn(label: Text("Kategorie")),
            DataColumn(label: Text("Aktionen"))
          ],
          source: _DataSource(context, constraints, _items)),
    );
  }
}

class _DataSource extends DataTableSource {
  _DataSource(
    this.context,
    this.constraints,
    List<GroceryItem> groceryItems,
  ) {
    _data = groceryItems;
    _groceryItemRepository = GroceryItemRepository();
  }

  final BuildContext context;
  final BoxConstraints constraints;
  late List<GroceryItem> _data;
  late GroceryItemRepository _groceryItemRepository;

  @override
  DataRow? getRow(int index) {
    final currentData = _data[index];
    return DataRow.byIndex(
      index: index,
      color: MaterialStateProperty.resolveWith<Color>(
        (Set<MaterialState> states) {
          if (index % 2 == 0) return Colors.grey.withOpacity(0.1);
          return Colors.grey.withOpacity(0.0);
        },
      ),
      cells: [
        DataCell(
          ConstrainedBox(
            constraints: BoxConstraints(
                maxWidth: constraints.maxWidth * 0.3,
                minWidth: constraints.maxWidth * 0.3),
            child: Text(
              currentData.name,
              overflow: TextOverflow.ellipsis,
            ),
          ),
        ),
        DataCell(
          ConstrainedBox(
            constraints: BoxConstraints(
                maxWidth: constraints.maxWidth * 0.3,
                minWidth: constraints.maxWidth * 0.3),
            child: Text(
              currentData.groceryCategoryName,
              overflow: TextOverflow.ellipsis,
            ),
          ),
        ),
        DataCell(
          ConstrainedBox(
            constraints: BoxConstraints(
              maxWidth: constraints.maxWidth * 0.2,
              minWidth: constraints.maxWidth * 0.2,
            ),
            child: Row(
              children: [
                IconButton(
                  icon: Icon(Icons.edit),
                  splashRadius: 20.0,
                  onPressed: () async {
                    showDialog(
                      context: context,
                      builder: (context) =>
                          SaveGroceryItemPopup(groceryItem: currentData),
                    ).then((value) => notifyListeners());
                  },
                ),
                IconButton(
                  icon: Icon(Icons.delete),
                  color: Colors.red,
                  splashRadius: 20.0,
                  onPressed: () async {
                    await _groceryItemRepository.deleteById(currentData.id);
                    _data.remove(currentData);
                    notifyListeners();
                  },
                ),
              ],
            ),
          ),
        )
      ],
    );
  }

  @override
  bool get isRowCountApproximate => false;

  @override
  int get rowCount => _data.length;

  @override
  int get selectedRowCount => 0;
}
