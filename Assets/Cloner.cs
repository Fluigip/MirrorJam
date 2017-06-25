using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloner : MonoBehaviour {

    private Plane plane;
    private Vector3 normal;


	// Use this for initialization
	public void Start () {

        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;

        normal = (mesh.normals[0] + mesh.normals[1]) / 2;

        Debug.Log(normal);

        //mesh.normals[0];
	}
	
	// Update is called once per frame
	public void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        GameObject otherGO = other.gameObject;

        Debug.Log("C Entro el objeto");

        Vector3 pos = other.transform.position;       
        
   
        //Debug.Log(pos);

        //Reflejar bola
        Instantiate(otherGO,-normal * 5,Quaternion.identity);

    }

    public void OnTriggerExit(Collider other)
    {
        GameObject otherGO = other.gameObject;

        Debug.Log("C Salio el objeto");

    }

}
