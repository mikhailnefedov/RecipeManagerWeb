import 'package:flutter/material.dart';

import 'package:http/http.dart' as http;
import 'package:recipemanagerwebclient/api/request_urls.dart';
import 'package:recipemanagerwebclient/gen_exports.dart';
import '../../api/recipe_category_repository.dart';
import '../../models/recipe_category.dart';
import '../popups/save_recipe_category_popup.dart';

class RecipeCategoryTable extends StatefulWidget {
  RecipeCategoryTable({Key? key, required this.categories}) : super(key: key);

  final List<RecipeCategory> categories;

  @override
  State<RecipeCategoryTable> createState() => _RecipeCategoryTableState();
}

class _RecipeCategoryTableState extends State<RecipeCategoryTable> {
  late List<RecipeCategory> _categories;
  int _sortColumnIndex = 1;
  bool _isAscending = false;

  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    _categories = widget.categories;
    return LayoutBuilder(
      builder: (context, constraints) => PaginatedDataTable(
        header: Text(AppLocalizations.of(context)!.recipeCategories),
        showFirstLastButtons: true,
        columns: [
          DataColumn(
            label: Row(
              children: [
                Text(AppLocalizations.of(context)!.name),
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
          DataColumn(label: Text(AppLocalizations.of(context)!.abbreviation)),
          DataColumn(label: Text(AppLocalizations.of(context)!.actions))
        ],
        source: _DataSource(context, constraints, _categories),
      ),
    );
  }

  DataRow createRow(RecipeCategory category) {
    return DataRow(
      cells: <DataCell>[
        DataCell(Text(category.name)),
        DataCell(Text(category.abbreviation)),
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

  Future<void> deleteCategory(RecipeCategory category) async {
    await http.delete(
      Uri.parse("${RequestURL.recipeCategories}/${category.id}"),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
    );

    setState(() {
      _categories.remove(category);
    });
  }
}

class _DataSource extends DataTableSource {
  _DataSource(
    this.context,
    this.constraints,
    List<RecipeCategory> recipeCategories,
  ) {
    _data = recipeCategories;
    _recipeCategoryRepository = RecipeCategoryRepository();
  }

  final BuildContext context;
  final BoxConstraints constraints;
  late List<RecipeCategory> _data;
  late RecipeCategoryRepository _recipeCategoryRepository;

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
                maxWidth: constraints.maxWidth * 0.4,
                minWidth: constraints.maxWidth * 0.4),
            child: Text(
              currentData.name,
              overflow: TextOverflow.ellipsis,
            ),
          ),
        ),
        DataCell(
          ConstrainedBox(
            constraints: BoxConstraints(
                maxWidth: constraints.maxWidth * 0.1,
                minWidth: constraints.maxWidth * 0.1),
            child: Text(
              currentData.abbreviation,
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
                          SaveRecipeCategoryPopup(recipeCategory: currentData),
                    ).then((value) => notifyListeners());
                  },
                ),
                IconButton(
                  icon: Icon(Icons.delete),
                  color: Colors.red,
                  splashRadius: 20.0,
                  onPressed: () async {
                    await _recipeCategoryRepository.deleteById(currentData.id);
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
