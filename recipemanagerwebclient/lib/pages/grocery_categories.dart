import 'package:flutter/material.dart';

import '../widgets/header.dart';
import '../widgets/navigation_drawer.dart';

class GroceryCategories extends StatefulWidget {
  const GroceryCategories({super.key});

  @override
  State<GroceryCategories> createState() => _GroceryCategoriesState();
}

class _GroceryCategoriesState extends State<GroceryCategories> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      drawer: NavigationDrawer(),
      appBar: Header(),
      body: Center(
        child: Text('Lebensmittelkategorien'),
      ),
    );
  }
}
