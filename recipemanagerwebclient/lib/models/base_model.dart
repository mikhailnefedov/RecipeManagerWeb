import 'package:equatable/equatable.dart';

abstract class BaseModel {
  static convertFromJson(Map<String, dynamic> json) {}
  Map<String, dynamic> toJson();
  const BaseModel();
}
