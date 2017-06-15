using UnityEngine;
// using System;

namespace MirrorJam
{

public class Maze
{
  public Hex[]  hexes;
  public Tile[] tiles;

  private int radius;

  public Maze(int _radius) {
    // TODO: if radius < 1, stop
    radius = _radius;
    if (radius < 0) { Debug.Break(); }

    int hex_count = 1;
    for (int i = 1; i < radius; i ++) { hex_count += 6 * i; }

    hexes = new Hex[hex_count];
    tiles = new Tile[hex_count * 6];
  }

  public void SpawnHexes() {
    for (int x = -radius; x <= radius; ++x) {
      for (int y = -radius; y <= radius; ++y) {
        for (int z = -radius; z <= radius; ++z) {
          SpawnHex(x,y,z);
        }
      }
    }
  }

  public void SpawnHex(int x, int y, int z) {
    Debug.LogFormat("x: {0} y: {1} z: {2}", x, y, z);
  }
}

}
