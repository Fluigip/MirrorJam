using UnityEngine;
// using System;

namespace MirrorJam
{

public class Hex
{
  public int   q;
  public int   r;
  public Hex[] neighs;

  public Hex(int q, int r) {
    this.q = q;
    this.r = r;
    neighs = new Hex[6];
  }

}

}
