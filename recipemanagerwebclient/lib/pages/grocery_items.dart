import 'package:flutter/material.dart';

import '../widgets/header.dart';
import '../widgets/navigation_drawer.dart';

class GroceryItems extends StatefulWidget {
  const GroceryItems({super.key});

  @override
  State<GroceryItems> createState() => _GroceryItemsState();
}

class _GroceryItemsState extends State<GroceryItems> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      drawer: NavigationDrawer(),
      appBar: Header(),
      body: Center(
        child: Text('Lebensmittel'),
      ),
    );
  }
}
