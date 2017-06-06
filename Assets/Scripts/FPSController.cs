using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour {

    public float xRotation;
    public float yRotation;
    public float lookSensitivity = 2f;
    public float currentXRotation;
    public float currentYRotation;
    public float xRotationV;
    public float yRotationV;
    public float lookSmoothDamp = 0.1f;

	// Use this for initialization
	public void Start () {    

	}
	
	// Update is called once per frame
	public void Update () {

        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
        yRotation += Input.GetAxis("Mouse X") * lookSensitivity;        

        xRotation = Mathf.Clamp(xRotation, -90, 90);

        currentXRotation = Mathf.SmoothDamp(currentXRotation, xRotation, ref xRotationV, lookSmoothDamp);
        currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationV, lookSmoothDamp);


        transform.rotation = Quaternion.Euler(currentXRotation,currentYRotation, 0);  

	}

   
}
