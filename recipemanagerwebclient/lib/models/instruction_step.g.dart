// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'instruction_step.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

InstructionStep _$InstructionStepFromJson(Map<String, dynamic> json) =>
    InstructionStep(
      id: json['id'] as int? ?? 0,
      text: json['text'] as String? ?? '',
    );

Map<String, dynamic> _$InstructionStepToJson(InstructionStep instance) =>
    <String, dynamic>{
      'id': instance.id,
      'text': instance.text,
    };
