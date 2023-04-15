import 'dart:convert';
import 'package:http/http.dart' as http;

import '../models/base_model.dart';

class WebClient {
  const WebClient();

  static const String host = "https://localhost:7287/api/";

  Future<dynamic> get(String route) async {
    final response = await http.get(Uri.parse(host + route));
    final dynamic jsonResponse = json.decode(response.body);
    return jsonResponse;
  }

  Future<dynamic> delete(String route) async {
    final response = await http.delete(Uri.parse(host + route));
    final dynamic jsonResponse = json.decode(response.body);
    return jsonResponse;
  }

  Future<dynamic> post(String route, BaseModel model) async {
    final response = await http.post(
      Uri.parse(host + route),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: jsonEncode(model.toJson()),
    );
    return json.decode(response.body);
  }

  Future<dynamic> update(String route, BaseModel model) async {
    final response = await http.put(
      Uri.parse(host + route),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: jsonEncode(model.toJson()),
    );
    return json.decode(response.body);
  }
}
