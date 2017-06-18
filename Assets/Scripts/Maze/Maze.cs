using UnityEngine;
using System;

namespace MirrorJam
{

public class Maze
{
  public Hex[]  hexes;

  private int radius;
  private int size;

  public Maze(int radius) {
    if (radius < 0) { Debug.Break(); }
    this.radius = radius;

    size = 2 * radius + 1;
    hexes = new Hex[size * size];
  }

  public void SpawnHexes() {
    for (int r = 0; r < size; ++r) {
      for (int q = 0; q < size; ++q) {
        if (Mathf.Abs(q + r - 2 * radius) > radius) { continue; }
        hexes[r * size + q] = new Hex(q, r);
      }
    }
  }

  public void BuildGraph() {
    for (int r = 0; r < size; ++r) {
      for (int q = 0; q < size; ++q) {
        Hex hex = get(q, r);
        if(hex == null) { continue; }

        ConnectNeighs(hex, q + 1, r, 0);
        ConnectNeighs(hex, q + 1, r - 1, 1);
        ConnectNeighs(hex, q, r - 1, 2);
        ConnectNeighs(hex, q - 1, r, 3);
        ConnectNeighs(hex, q - 1, r + 1, 4);
        ConnectNeighs(hex, q, r + 1, 5);
      }
    }
  }

  public Hex get(int q, int r) {
    if (q < 0 || q >= size || r < 0 || r >= size) { return null; }
    if (Mathf.Abs(q + r - 2 * radius) > radius) { return null; }
    return hexes[r * size + q];
  }

  public void Dbg() {
    string str = "";
    for (int r = 0; r < size; ++r) {
      for (int q = 0; q < size; ++q) {
        Hex hex = hexes[r * size + q];
        if(hex == null) { str += " 00"; continue; }

        int code = 0;
        if(hex.neighs[0] != null) { code += 1; }
        if(hex.neighs[1] != null) { code += 2; }
        if(hex.neighs[2] != null) { code += 4; }
        if(hex.neighs[3] != null) { code += 8; }
        if(hex.neighs[4] != null) { code += 16; }
        if(hex.neighs[5] != null) { code += 32; }

        str += code.ToString(" 00");
      }
      str += "\n\n";
    }
    Debug.Log(str);
  }

  private void ConnectNeighs(Hex hex, int q, int r, int idx) {
    Hex aux = get(q, r);
    if( aux != null) {
      hex.neighs[idx] = aux;
    }
  }
}

}
