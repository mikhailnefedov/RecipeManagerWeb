import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/models/data_layer.dart';
import 'package:recipemanagerwebclient/widgets/popups/save_grocery_item_popup.dart';
import 'package:recipemanagerwebclient/widgets/tables/grocery_item_table.dart';

import '../gen_exports.dart';

class GroceryItemsView extends StatefulWidget {
  const GroceryItemsView({Key? key, required this.groceryItems})
      : super(key: key);

  final List<GroceryItem> groceryItems;

  @override
  _GroceryItemsViewState createState() => _GroceryItemsViewState();
}

class _GroceryItemsViewState extends State<GroceryItemsView> {
  late TextEditingController _searchController;
  late List<GroceryItem> _groceryItems;

  @override
  void initState() {
    super.initState();
    _searchController = TextEditingController(text: '');
    _groceryItems = widget.groceryItems;
  }

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: Center(
        child: Column(
          children: [
            SizedBox(
              height: 8,
            ),
            SizedBox(
              width: MediaQuery.of(context).size.width * 0.5,
              child: TextFormField(
                controller: _searchController,
                decoration: InputDecoration(
                  labelText: AppLocalizations.of(context)!.search,
                  prefixIcon: Icon(Icons.search),
                ),
                onChanged: (value) {
                  setState(() {});
                },
              ),
            ),
            SizedBox(
              height: 8,
            ),
            SizedBox(
              width: MediaQuery.of(context).size.width * 0.5,
              child: ElevatedButton.icon(
                icon: Icon(Icons.add),
                label: Text("Hinzufügen"),
                onPressed: () {
                  showDialog(
                    context: context,
                    builder: (context) => SaveGroceryItemPopup(),
                  ).then((value) {
                    GroceryItem groceryItem = value as GroceryItem;
                    setState(() {
                      _groceryItems.add(groceryItem);
                    });
                  });
                },
              ),
            ),
            SizedBox(
              height: 8,
            ),
            SizedBox(
              width: MediaQuery.of(context).size.width * 0.5,
              child: GroceryItemTable(
                items: _groceryItems
                    .where((element) =>
                        element.name.contains(_searchController.text))
                    .toList(),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
