import 'package:flutter/material.dart';
import 'package:recipemanagerwebclient/models/data_layer.dart';

class MeasurementDropdown extends StatefulWidget {
  Ingredient ingredient;

  MeasurementDropdown({
    Key? key,
    required this.ingredient,
  }) : super(key: key);

  @override
  _MeasurementDropdownState createState() => _MeasurementDropdownState();
}

class _MeasurementDropdownState extends State<MeasurementDropdown> {
  final List<DropdownMenuItem<MeasurementUnit>> _measurementUnits =
      MeasurementUnit.values.map((e) {
    return DropdownMenuItem<MeasurementUnit>(
      value: e,
      child: Text(e.name),
    );
  }).toList();

  late Ingredient _ingredient;

  @override
  void initState() {
    super.initState();
    _ingredient = widget.ingredient;
  }

  @override
  Widget build(BuildContext context) {
    return DropdownButton(
      value: _ingredient.measurement,
      items: _measurementUnits,
      onChanged: (value) {
        setState(() {
          _ingredient.measurement = value!;
        });
      },
    );
  }
}
