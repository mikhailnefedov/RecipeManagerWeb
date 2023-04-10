enum PortionUnit { Bun, Bread, Cake, Portion }

extension ParseToString on PortionUnit {
  String toShortString() {
    return this.toString().split('.').last;
  }
}
