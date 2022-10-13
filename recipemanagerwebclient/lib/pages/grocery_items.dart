import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/api/http_helper.dart';
import 'package:recipemanagerwebclient/widgets/tables/grocery_item_table.dart';

import '../models/grocery_item.dart';
import '../widgets/header.dart';
import '../widgets/navigation_drawer.dart';
import '../widgets/popups/create_grocery_item_popup.dart';

class GroceryItems extends StatefulWidget {
  const GroceryItems({super.key});

  @override
  State<GroceryItems> createState() => _GroceryItemsState();
}

class _GroceryItemsState extends State<GroceryItems> {
  late Future<List<GroceryItem>> items;

  @override
  void initState() {
    super.initState();
    items = HttpHelper.fetchGroceryItems();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      drawer: NavigationDrawer(),
      appBar: Header(),
      body: Column(
        children: [
          SizedBox(
            height: 16,
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: [
              ElevatedButton.icon(
                icon: Icon(Icons.add),
                label: Text("Lebensmittel hinzufügen"),
                onPressed: () {
                  showDialog(
                    context: context,
                    builder: (context) => CreateGroceryItemPopup(),
                  );
                },
              ),
            ],
          ),
          Divider(),
          FutureBuilder<List<GroceryItem>>(
            future: items,
            builder: (context, snapshot) {
              if (snapshot.hasData) {
                return GroceryItemTable(
                  items: snapshot.requireData,
                );
              } else if (snapshot.hasError) {
                return Text('${snapshot.error}');
              }
              return const CircularProgressIndicator();
            },
          ),
          Divider(),
          Text('TODO: Better Pagination/Scrolling necessary')
        ],
      ),
    );
  }
}
