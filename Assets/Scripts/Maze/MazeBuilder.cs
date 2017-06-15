using System.Collections;
using UnityEngine;
using MirrorJam;

public class MazeBuilder : MonoBehaviour
{
  public int radius = 1;

	public void Start ()
  {
    Maze maze = new Maze(radius);
    maze.SpawnHexes();

    //RenderMazeGraph(graph);
	}
}
