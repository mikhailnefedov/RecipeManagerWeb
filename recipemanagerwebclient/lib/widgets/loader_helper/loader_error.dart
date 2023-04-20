import 'package:flutter/material.dart';

class LoaderError<T> extends StatelessWidget {
  const LoaderError({Key? key, required this.snapshot}) : super(key: key);

  final AsyncSnapshot<List<T>> snapshot;

  @override
  Widget build(BuildContext context) {
    return Center(child: Text('${snapshot.error}'));
  }
}
