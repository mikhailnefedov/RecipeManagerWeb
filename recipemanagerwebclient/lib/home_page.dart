import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/widgets/navigation_drawer.dart';

import 'widgets/header.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      drawer: NavigationDrawer(),
      appBar: Header(),
      body: Center(
        child: Text(
          'Home Page',
        ),
      ),
    );
  }
}
