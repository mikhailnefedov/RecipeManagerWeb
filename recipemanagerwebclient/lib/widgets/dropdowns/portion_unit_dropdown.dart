import 'package:flutter/material.dart';

import '../../models/portion_unit.dart';
import '../../models/recipe.dart';

class PortionUnitDropdown extends StatefulWidget {
  PortionUnit value;
  Recipe? recipe;

  PortionUnitDropdown({
    Key? key,
    required this.value,
    this.recipe,
  }) : super(key: key);

  @override
  _PortionUnitDropdownState createState() => _PortionUnitDropdownState();
}

class _PortionUnitDropdownState extends State<PortionUnitDropdown> {
  final List<DropdownMenuItem<PortionUnit>> _portionUnits =
      PortionUnit.values.map((e) {
    return DropdownMenuItem<PortionUnit>(
      value: e,
      child: Text(e.name),
    );
  }).toList();

  late PortionUnit _value;
  late Recipe? _recipe;

  @override
  void initState() {
    super.initState();
    _value = widget.value;
    _recipe = widget.recipe;
  }

  @override
  Widget build(BuildContext context) {
    return DropdownButton(
      value: _value,
      items: _portionUnits,
      onChanged: (value) {
        setState(() {
          _value = value!;
          _recipe!.portionUnit = value;
        });
      },
    );
  }
}
