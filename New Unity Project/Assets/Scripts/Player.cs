using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	public GameObject kamera;
	public Transform [] locations;
	public Rigidbody2D rigb;

	public float moveSpeed = 10f;

	bool hasMachete = false;
	public SpriteRenderer machete;
	public Sprite replaceSprite;
	public Animator maattori;

	void FixedUpdate ()
	{
		float movementx = Input.GetAxis ("Horizontal") * Time.deltaTime * moveSpeed;
		float movementy = Input.GetAxis ("Vertical") * Time.deltaTime * moveSpeed;
		rigb.AddForce (new Vector2 (movementx, movementy), ForceMode2D.Impulse);
	}

	void OnTriggerStay2D (Collider2D other)
	{
		Vector2 newPos = transform.position;
		Vector3 kameraPos = kamera.transform.position;

		switch (other.tag) 
		{
		case "Left":
			newPos = locations [0].position;
			transform.position = newPos; 

			kameraPos.x = locations [0].position.x;
			kameraPos.y = locations [0].position.y;
			kamera.transform.position = kameraPos;
			break;

		case "Middle":
			newPos = locations [1].position;
			transform.position = newPos; 

			kameraPos.x = locations [1].position.x;
			kameraPos.y = locations [1].position.y;
			kamera.transform.position = kameraPos;
			break;

		case "Right":
			newPos = locations [2].position;
			transform.position = newPos; 

			kameraPos.x = locations [2].position.x;
			kameraPos.y = locations [2].position.y;
			kamera.transform.position = kameraPos;
			break;
		case "Vines":
			if (Input.GetKeyDown (KeyCode.E) && hasMachete == true) 
			{
				maattori.SetBool ("Iscut", true);
				other.GetComponent<BoxCollider2D> ().enabled = false;
			}
			break;
		case "Mach":
			if (Input.GetKeyDown (KeyCode.E)) 
			{
				hasMachete = true;
				machete.sprite = replaceSprite;
			}
			break;
		}
	}
}
