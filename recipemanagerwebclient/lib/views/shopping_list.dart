import 'package:flutter/material.dart';

import '../widgets/header.dart';
import '../widgets/navigation_drawer.dart';

class ShoppingList extends StatefulWidget {
  static const route = '/shoppinglist';

  const ShoppingList({super.key});

  @override
  State<ShoppingList> createState() => _ShoppingListState();
}

class _ShoppingListState extends State<ShoppingList> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      drawer: NavigationDrawer(),
      appBar: Header(),
      body: Center(
        child: Text('Einkaufsliste'),
      ),
    );
  }
}
