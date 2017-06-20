using UnityEngine;
// using System;

namespace MirrorJam
{

public class Hex
{
  public int     q;
  public int     r;
  public int     d;
  public Hex[]   neighs;
  public HexType type;

  public Hex(int q, int r) {
    this.q = q;
    this.r = r;
    this d = 0;
    neighs = new Hex[6];
    type = HexType.Empty;
  }

}

}
