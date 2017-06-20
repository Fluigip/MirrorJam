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

  public bool contains(int q, int r) {
    if (q < 0 || q >= size || r < 0 || r >= size) { return false; }
    if (Mathf.Abs(q + r - 2 * radius) > radius) { return false; }
    return true;
  }

  public Hex get(int q, int r) {
    if (!contains(q,r)) { return null; }
    return hexes[r * size + q];
  }

  public bool set(int q, int r, Hex hex) {
    if (!contains(q,r)) { return false; }
    hexes[r * size + q] = hex;
    return true;
  }

}

}
