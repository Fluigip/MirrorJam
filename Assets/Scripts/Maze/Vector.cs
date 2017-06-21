using UnityEngine;

namespace MirrorJam
{

public class Vector
{
  public Hex src;
  public Hex dst;
  public int direction;

  public Vector(Hex src, Hex dst, int direction) {
    this.src = src;
    this.dst = dst;
    this.direction = direction;
  }
}

}
