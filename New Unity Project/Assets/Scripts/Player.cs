using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	public GameObject kamera;
	public Transform [] locations;
	public Rigidbody2D rigb;

	public float moveSpeed = 10f;

	void FixedUpdate ()
	{
		float movementx = Input.GetAxis ("Horizontal") * Time.deltaTime * moveSpeed;
		float movementy = Input.GetAxis ("Vertical") * Time.deltaTime * moveSpeed;
		rigb.AddForce (new Vector2 (movementx, movementy), ForceMode2D.Impulse);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		switch (other.tag) 
		{
		case "ToLeft":
			//siirry vasemmalle
			break;
		case "ToRight":
			//siirry oikealle
			break;
		}
	}
}
