import 'package:json_annotation/json_annotation.dart';

part 'instruction_step.g.dart';

@JsonSerializable()
class InstructionStep {
  int id;
  String text;

  InstructionStep({
    this.id = 0,
    this.text = '',
  });

  factory InstructionStep.fromJson(Map<String, dynamic> json) =>
      _$InstructionStepFromJson(json);
  Map<String, dynamic> toJson() => _$InstructionStepToJson(this);
}
