using UnityEngine;

namespace MirrorJam
{

public class Hex
{
  public int     q;
  public int     r;
  public int     distance;
  public int     code;
  public HexType type;
  public Hex[]   neighs;

  public Hex(int q, int r) {
    this.q = q;
    this.r = r;
    this.distance = 0;
    this.code = 0;
    neighs = new Hex[6];
    type = HexType.Empty;
  }

}

}
