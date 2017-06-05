using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    private Transform playerPos;
    private Rigidbody fplayer;

    // Use this for initialization
    public void Start () {

        playerPos = GetComponent<Transform>();
        fplayer = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	public void Update () {
		
	}

    public void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        fplayer.MovePosition(movement * Time.fixedDeltaTime * speed + playerPos.position);
    }
}
