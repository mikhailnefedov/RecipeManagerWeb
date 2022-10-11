import 'dart:js';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class NavigationDrawer extends StatelessWidget {
  const NavigationDrawer({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Drawer(
      child: Material(
        color: Theme.of(context).primaryColor,
        child: ListView(
          padding: EdgeInsets.symmetric(horizontal: 20),
          children: <Widget>[
            SizedBox(height: 16),
            buildMenuItem(
              context: context,
              text: 'Rezepte',
              route: '/recipes',
            ),
            SizedBox(height: 16),
            buildMenuItem(
              context: context,
              text: 'Einkaufsliste',
              route: '/shoppinglist',
            ),
            SizedBox(height: 16),
            buildMenuItem(
              context: context,
              text: 'Rezeptkategorien',
              route: '/recipecategories',
            ),
            SizedBox(height: 16),
            buildMenuItem(
              context: context,
              text: 'Lebensmittel',
              route: '/groceryitems',
            ),
            SizedBox(height: 16),
            buildMenuItem(
              context: context,
              text: 'Lebensmittelkategorien',
              route: '/grocerycategories',
            )
          ],
        ),
      ),
    );
  }

  Widget buildMenuItem(
      {required BuildContext context,
      required String text,
      required String route}) {
    const color = Colors.white;
    const hovorColor = Colors.white10;

    return ListTile(
      title: Text(
        text,
        style: TextStyle(
          color: color,
          fontSize: 20.0,
        ),
      ),
      hoverColor: hovorColor,
      onTap: () {
        Navigator.of(context).pop();
        Navigator.pushNamed(context, route);
      },
    );
  }
}
