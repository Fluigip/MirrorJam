using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MirrorJam;

public class MazeBuilder : MonoBehaviour
{
  public int seed = 0;
  public int radius = 1;
  public int loops = 3;

  private Maze maze;
  private Hex start;
  private Hex goal;

  public void Start ()
  {
    if (seed > 0) { Random.InitState(seed); }
    maze = new Maze(radius);

    SpawnHexes();
    CreateMesh();
    SetStart();
    Backtrack();
    // AddLoops();
    SetGoal();
    DebugMaze();

    // TODO: instantiate it
    // GameObject go = new GameObject("Maze");
	}

  private void SpawnHexes() {
    for (int r = 0; r < maze.size; ++r) {
      for (int q = 0; q < maze.size; ++q) {
        if (Mathf.Abs(q + r - 2 * maze.radius) > maze.radius) { continue; }
        maze.Set(q, r, new Hex(q, r));
      }
    }
  }

  private void CreateMesh() {
    for (int r = 0; r < maze.size; ++r) {
      for (int q = 0; q < maze.size; ++q) {
        Hex hex = maze.Get(q, r);
        if(hex == null) { continue; }

        ConnectNeigh(hex, q + 1, r, 0);
        ConnectNeigh(hex, q + 1, r - 1, 1);
        ConnectNeigh(hex, q, r - 1, 2);
        ConnectNeigh(hex, q - 1, r, 3);
        ConnectNeigh(hex, q - 1, r + 1, 4);
        ConnectNeigh(hex, q, r + 1, 5);
      }
    }
  }

  private void ConnectNeigh(Hex hex, int q, int r, int idx) {
    Hex aux = maze.Get(q, r);
    if( aux == null) { return; }
    hex.neighs[idx] = aux;
  }

  private void SetStart() {
    int q, r;
    do {
      q = Random.Range(0, maze.size);
      r = Random.Range(0, maze.size);
    } while (!maze.Contains(q, r));
    Hex hex = maze.Get(q, r);
    hex.type = HexType.Start;
    start = hex;
  }

  private void Backtrack() {
    List<Hex> extended = new List<Hex>();
    Stack<Vector> stack = new Stack<Vector>();

    stack.Push(new Vector(null, start, 0));
    while(stack.Count > 0) {
      Vector v = stack.Pop();
      if (extended.Contains(v.dst)) { continue; }
      extended.Add(v.dst);

      DebugMaze();

      v.dst.code += 1 << ((v.direction + 3)  % 6);
      if(v.src != null) {
        v.dst.distance = v.src.distance + 1;
        v.src.code += 1 << v.direction;
      }

      int offset = Random.Range(0, 6);
      for (int i = 0; i < 6; ++i) {
        int idx = (i + offset) % 6;
        Hex neigh = v.dst.neighs[idx];
        if (neigh == null || extended.Contains(neigh)) { continue; }
        stack.Push(new Vector(v.dst, neigh, idx));
      }
    }

    DebugMaze();
  }

  private void SetGoal() {
    Hex target = start;
    for (int r = 0; r < maze.size; ++r) {
      for (int q = 0; q < maze.size; ++q) {
        Hex hex = maze.hexes[r * maze.size + q];
        if(hex == null || hex.distance <= target.distance) { continue; }
        target = hex;
      }
    }
    target.type = HexType.Goal;
    goal = target;
  }

  public void DebugMaze() {
    string str = "";
    for (int r = 0; r < maze.size; ++r) {
      for (int q = 0; q < maze.size; ++q) {
        Hex hex = maze.hexes[r * maze.size + q];
        if(hex == null) { str += " 00"; continue; }

        // int code = 0;
        // if(hex.neighs[0] != null) { code += 1; }
        // if(hex.neighs[1] != null) { code += 2; }
        // if(hex.neighs[2] != null) { code += 4; }
        // if(hex.neighs[3] != null) { code += 8; }
        // if(hex.neighs[4] != null) { code += 16; }
        // if(hex.neighs[5] != null) { code += 32; }

        switch(hex.type) {
          case HexType.Start:  str += "S"; break;
          case HexType.Goal: str += "G"; break;
          default: str += " "; break;
        }

        str += hex.code.ToString("00");
      }
      str += "\n\n";
    }
    Debug.Log(str);
  }
}
