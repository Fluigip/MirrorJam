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
        hexes[r * size + q] = new Hex(r, q);
      }
    }
  }

  public Hex get(int q, int r) {
    if (Mathf.Abs(q + r - 2 * radius) > radius) { return null; }
    return hexes[r * size + q];
  }

  public void Dbg() {
    string str = "";
    for (int r = 0; r < size; ++r) {
      for (int q = 0; q < size; ++q) {
        // TODO: display hex type
        str += hexes[r * size + q] == null ? "0" : "1";
      }
      str += "\n";
    }
    Debug.Log(str);
  }
}

}
