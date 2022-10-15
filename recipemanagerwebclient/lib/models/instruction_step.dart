import 'package:json_annotation/json_annotation.dart';

part 'instruction_step.g.dart';

@JsonSerializable()
class InstructionStep {
  final int id;
  final String text;

  InstructionStep({
    this.id = 0,
    this.text = '',
  });

  factory InstructionStep.fromJson(Map<String, dynamic> json) =>
      _$InstructionStepFromJson(json);
}
