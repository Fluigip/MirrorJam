using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloner : MonoBehaviour {

  private Plane plane;
  private Vector3 normal;

	public void Start () {
    Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
    normal = (mesh.normals[0] + mesh.normals[1]) / 2;
	}
	
	public void Update ()
  {
    // TODO: track updates of mirrored objects
  }

  public void OnTriggerEnter(Collider collided)
  {
    GameObject otherGO = collided.gameObject;
    Vector3 pos = collided.transform.position;
    Vector3 projection = Vector3.ProjectOnPlane(pos, normal);
    Vector3 mirrored = 2 * projection - pos;

    Instantiate(otherGO, mirrored, collided.transform.rotation);
    // TODO: link the two object 
  }

  public void OnTriggerExit(Collider other)
  {
    GameObject otherGO = other.gameObject;
    Debug.Log("C Salio el objeto");
    // TODO: remove mirrored object
  }
}
