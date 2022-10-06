import 'package:flutter/material.dart';
import '../widgets/header.dart';
import '../widgets/navigation_drawer.dart';

class Recipes extends StatefulWidget {
  const Recipes({super.key});

  @override
  State<Recipes> createState() => _RecipesState();
}

class _RecipesState extends State<Recipes> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      drawer: NavigationDrawer(),
      appBar: Header(),
      body: Center(
        child: Text('Rezepte'),
      ),
    );
  }
}
