using System.Collections;
using UnityEngine;
using MirrorJam;

public class MazeBuilder : MonoBehaviour
{
  public int seed = 0;
  public int radius = 1;
  public int loops = 3;

  public void Start ()
  {
    GameObject go = new GameObject("Maze");
    Maze maze = new Maze(radius);

    if (seed > 0) { Random.InitState(seed); }

    SpawnHexes(maze);
    BuildMesh(maze);
    PickStart(maze);
    Backtrack(maze);
    // AddLoops(maze);
    // PickFinish(maze);
    DebugMaze(maze);
	}

  private void SpawnHexes(Maze maze) {
    for (int r = 0; r < maze.size; ++r) {
      for (int q = 0; q < maze.size; ++q) {
        if (Mathf.Abs(q + r - 2 * maze.radius) > maze.radius) { continue; }
        maze.set(q, r, new Hex(q, r));
      }
    }
  }

  private void BuildMesh(Maze maze) {
    for (int r = 0; r < maze.size; ++r) {
      for (int q = 0; q < maze.size; ++q) {
        Hex hex = maze.get(q, r);
        if(hex == null) { continue; }

        ConnectNeighs(maze, hex, q + 1, r, 0);
        ConnectNeighs(maze, hex, q + 1, r - 1, 1);
        ConnectNeighs(maze, hex, q, r - 1, 2);
        ConnectNeighs(maze, hex, q - 1, r, 3);
        ConnectNeighs(maze, hex, q - 1, r + 1, 4);
        ConnectNeighs(maze, hex, q, r + 1, 5);
      }
    }
  }

  private void ConnectNeighs(Maze maze, Hex hex, int q, int r, int idx) {
    Hex aux = maze.get(q, r);
    if( aux != null) {
      hex.neighs[idx] = aux;
    }
  }

  private void PickStart(Maze maze) {
    int q, r;
    do {
      q = Random.Range(0, maze.size);
      r = Random.Range(0, maze.size);
    } while (!maze.contains(q, r));
    Hex hex = maze.get(q, r);
    hex.type = HexType.Start;
  }

  private void Backtrack(int seed) {
    // TODO: GENERATE MAZE
  }

  public void DebugMaze(Maze maze) {
    string str = "";
    for (int r = 0; r < maze.size; ++r) {
      for (int q = 0; q < maze.size; ++q) {
        Hex hex = maze.hexes[r * maze.size + q];
        if(hex == null) { str += " 00"; continue; }

        int code = 0;
        if(hex.neighs[0] != null) { code += 1; }
        if(hex.neighs[1] != null) { code += 2; }
        if(hex.neighs[2] != null) { code += 4; }
        if(hex.neighs[3] != null) { code += 8; }
        if(hex.neighs[4] != null) { code += 16; }
        if(hex.neighs[5] != null) { code += 32; }

        switch(hex.type) {
          case HexType.Start:  str += "S"; break;
          case HexType.Finish: str += "F"; break;
          default: str += " "; break;
        }

        str += code.ToString("00");
      }
      str += "\n\n";
    }
    Debug.Log(str);
  }
}
