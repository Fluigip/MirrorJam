using UnityEngine;
// using System;

namespace MirrorJam
{

public class Hex
{
  public int   q;
  public int   r;
  public Hex[] neighbours;

  public Hex(int q, int r) {
    this.q = q;
    this.r = r;
    neighbours = new Hex[6];
  }

}

}
