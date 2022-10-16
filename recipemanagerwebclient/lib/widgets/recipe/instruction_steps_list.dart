import 'package:flutter/material.dart';

import '../../models/data_layer.dart';

class InstructionStepsList extends StatefulWidget {
  Recipe recipe;

  InstructionStepsList({Key? key, required this.recipe}) : super(key: key);

  @override
  State<InstructionStepsList> createState() => _InstructionStepsListState();
}

class _InstructionStepsListState extends State<InstructionStepsList> {
  late Recipe _recipe;

  @override
  void initState() {
    super.initState();
    _recipe = widget.recipe;
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Text('Anleitung:', style: Theme.of(context).textTheme.headline6),
        SizedBox(
          height: 16.0,
        ),
        ListView.builder(
          shrinkWrap: true,
          itemCount: _recipe.instructions.length,
          itemBuilder: (context, index) {
            var textController = TextEditingController()
              ..text = _recipe.instructions[index].text;
            textController.addListener(
              () {
                _recipe.instructions[index].text = textController.text;
              },
            );
            return Padding(
              padding: const EdgeInsets.fromLTRB(0.0, 0.0, 0.0, 4.0),
              child: TextField(
                controller: textController,
                maxLines: null,
                decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  suffixIcon: IconButton(
                    icon: Icon(Icons.delete),
                    splashRadius: 16.0,
                    onPressed: () {
                      setState(() {
                        _recipe.instructions.removeAt(index);
                      });
                    },
                  ),
                ),
              ),
            );
          },
        ),
        IconButton(
          onPressed: () {
            setState(() {
              _recipe.instructions.add(InstructionStep(text: ''));
            });
          },
          icon: Icon(Icons.add),
        )
      ],
    );
  }
}
