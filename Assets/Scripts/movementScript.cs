using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour {

    public float force;
    public float xForce;
    public float yForce;

    public GameObject camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.rotation = Quaternion.Euler(0, camera.GetComponent<FPSController>().currentYRotation, 0);

        xForce = Input.GetAxis("Horizontal") * force;
        yForce = Input.GetAxis("Vertical") * force;

        transform.Translate(new Vector3(xForce, 0, yForce));	
	}
}
