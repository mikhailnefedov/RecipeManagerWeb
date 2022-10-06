import 'package:flutter/material.dart';

class Header extends StatelessWidget implements PreferredSizeWidget {
  const Header({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return AppBar(
      centerTitle: true,
      title: InkWell(
        child: Center(
          widthFactor: 2,
          heightFactor: 2,
          child: Text('RecipeManagerWeb'),
        ),
        onTap: () {
          Navigator.pop(context);
          Navigator.pushNamed(context, "/");
        },
      ),
    );
  }

  @override
  Size get preferredSize => Size.fromHeight(kToolbarHeight);
}
