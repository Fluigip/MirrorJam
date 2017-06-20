using UnityEngine;
using System;

namespace MirrorJam
{

public class Maze
{
  public int    radius;
  public int    size;
  public Hex[]  hexes;

  public Maze(int radius) {
    if (radius < 0) { Debug.Break(); }
    this.radius = radius;

    size = 2 * radius + 1;
    hexes = new Hex[size * size];
  }

  public bool Contains(int q, int r) {
    if (q < 0 || q >= size || r < 0 || r >= size) { return false; }
    if (Mathf.Abs(q + r - 2 * radius) > radius) { return false; }
    return true;
  }

  public Hex Get(int q, int r) {
    if (!Contains(q,r)) { return null; }
    return hexes[r * size + q];
  }

  public bool Set(int q, int r, Hex hex) {
    if (!Contains(q,r)) { return false; }
    hexes[r * size + q] = hex;
    return true;
  }

}

}
