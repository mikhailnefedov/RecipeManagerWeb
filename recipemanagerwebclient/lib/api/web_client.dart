import 'dart:convert';
import 'package:http/http.dart' as http;

class WebClient {
  const WebClient();

  static const String _host = "https://localhost:7287/api/";

  Future<dynamic> get(String route) async {
    final response = await http.get(Uri.parse(_host + route));
    final dynamic jsonResponse = json.decode(response.body);
    return jsonResponse;
  }

  Future<dynamic> delete(String route) async {
    final response = await http.delete(Uri.parse(_host + route));
    final dynamic jsonResponse = json.decode(response.body);
    return jsonResponse;
  }
}
