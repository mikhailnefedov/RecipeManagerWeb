import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/api/grocery_item_repository.dart';
import 'package:recipemanagerwebclient/widgets/tables/grocery_item_table.dart';

import '../models/grocery_item.dart';
import '../widgets/header.dart';
import '../widgets/navigation_drawer.dart';
import '../widgets/popups/save_grocery_item_popup.dart';
import 'grocery_items_view.dart';

class GroceryItems extends StatefulWidget {
  static const route = '/groceryitems';

  const GroceryItems({super.key});

  @override
  State<GroceryItems> createState() => _GroceryItemsState();
}

class _GroceryItemsState extends State<GroceryItems> {
  late GroceryItemRepository _groceryItemRepository;
  late Future<List<GroceryItem>> _groceryItems;

  @override
  void initState() {
    super.initState();
    _groceryItemRepository = GroceryItemRepository();
    _groceryItems = _groceryItemRepository.fetchAll();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      drawer: NavigationDrawer(),
      appBar: Header(),
      body: FutureBuilder<List<GroceryItem>>(
        future: _groceryItems,
        builder: (context, snapshot) {
          if (snapshot.hasData) {
            return GroceryItemsView(
              groceryItems: snapshot.requireData,
            );
          } else if (snapshot.hasError) {
            return Text('${snapshot.error}');
          }
          return Center(
            child: const CircularProgressIndicator(),
          );
        },
      ),
    );
  }
}
