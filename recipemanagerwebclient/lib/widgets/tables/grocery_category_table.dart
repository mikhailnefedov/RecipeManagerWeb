import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:recipemanagerwebclient/api/grocery_category_repository.dart';

import 'package:recipemanagerwebclient/api/request_urls.dart';
import '../../models/grocery_category.dart';
import '../popups/save_grocery_category_popup.dart';

class GroceryCategoryTable extends StatefulWidget {
  GroceryCategoryTable({Key? key, required this.categories}) : super(key: key);

  List<GroceryCategory> categories;

  @override
  State<GroceryCategoryTable> createState() => _GroceryCategoryTableState();
}

class _GroceryCategoryTableState extends State<GroceryCategoryTable> {
  late List<GroceryCategory> _categories;
  int _sortColumnIndex = 1;
  bool _isAscending = false;

  @override
  Widget build(BuildContext context) {
    _categories = widget.categories;
    return LayoutBuilder(
      builder: (context, constraints) => PaginatedDataTable(
          header: Text('Lebensmittelkategorien'),
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
                      ? _categories.sort((a, b) => a.name.compareTo(b.name))
                      : _categories.sort((a, b) => b.name.compareTo(a.name));
                });
              },
            ),
            DataColumn(label: Text("Aktionen"))
          ],
          source: _DataSource(context, constraints, _categories)),
    );
  }
}

class _DataSource extends DataTableSource {
  _DataSource(
    this.context,
    this.constraints,
    List<GroceryCategory> groceryCategories,
  ) {
    _data = groceryCategories;
    _groceryCategoryRepository = GroceryCategoryRepository();
  }

  final BuildContext context;
  final BoxConstraints constraints;
  late List<GroceryCategory> _data;
  late GroceryCategoryRepository _groceryCategoryRepository;

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
                maxWidth: constraints.maxWidth * 0.6,
                minWidth: constraints.maxWidth * 0.6),
            child: Text(
              currentData.name,
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
                      builder: (context) => SaveGroceryCategoryPopup(
                          groceryCategory: currentData),
                    ).then((value) => notifyListeners());
                  },
                ),
                IconButton(
                  icon: Icon(Icons.delete),
                  color: Colors.red,
                  splashRadius: 20.0,
                  onPressed: () async {
                    await _groceryCategoryRepository.deleteById(currentData.id);
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
