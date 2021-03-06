﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{
	public int leveltoload;
	public GameObject kamera;
	public Transform [] locations;
	public Rigidbody2D rigb;

	public float moveSpeed = 10f;

	bool hasItem = false;
	bool hasItem2 = false;
	public SpriteRenderer Item1;
	public SpriteRenderer Sprot;
	public Sprite replaceSprite;
	public Image ques;
	public Image excl;
	public Animator maattori;
	public Animator playerMaattori;

	float movementx;
	float movementy;


	void Update ()
	{
		if (movementx < -0.09f) 
		{
			playerMaattori.SetBool ("movingLeft", true);
			playerMaattori.SetBool ("movingRight", false);
			playerMaattori.SetBool ("ReturnX", false);
		}

		if (movementx > 0.09f) 
		{
			playerMaattori.SetBool ("movingLeft", false);
			playerMaattori.SetBool ("movingRight", true);
			playerMaattori.SetBool ("ReturnX", false);
		}

		if (movementx == 0) 
		{
			playerMaattori.SetBool ("movingLeft", false);
			playerMaattori.SetBool ("movingRight", false);
			playerMaattori.SetBool ("ReturnX", true);
		}

		////////////////////////////////////////////////

		if (movementy < -0.09f) 
		{
			playerMaattori.SetBool ("movingDown", true);
			playerMaattori.SetBool ("movingUp", false);
			playerMaattori.SetBool ("ReturnY", false);
		}

		if (movementy > 0.09f) 
		{
			playerMaattori.SetBool ("movingDown", false);
			playerMaattori.SetBool ("movingUp", true);
			playerMaattori.SetBool ("ReturnY", false);
		}

		if (movementy == 0) 
		{
			playerMaattori.SetBool ("movingDown", false);
			playerMaattori.SetBool ("movingUp", false);
			playerMaattori.SetBool ("ReturnY", true);
		}
	}

	void FixedUpdate ()
	{
		movementx = Input.GetAxis ("Horizontal") * Time.deltaTime * moveSpeed;
		movementy = Input.GetAxis ("Vertical") * Time.deltaTime * moveSpeed;
		rigb.AddForce (new Vector2 (movementx, movementy), ForceMode2D.Impulse);
	}

	void OnTriggerStay2D (Collider2D other)
	{
		Vector2 newPos = transform.position;
		Vector3 kameraPos = kamera.transform.position;

		switch (other.tag) {
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
			if (hasItem == true) 
			{
				excl.enabled = true;
			}
			if (hasItem == false) 
			{
				ques.enabled = true;
			}
			if (Input.GetKeyDown (KeyCode.E) && hasItem == true) 
			{
				maattori.SetBool ("Iscut", true);
				BoxCollider2D[] tempArr = other.GetComponents<BoxCollider2D> ();
				foreach (BoxCollider2D box in tempArr) 
				{
					box.enabled = false;
				}
				//Destroy (other.gameObject.GetComponent<BoxCollider2D> ());
				//other.GetComponent<BoxCollider2D> ().enabled = false;
			}
			break;

		case "Mach":
			excl.enabled = true;
			if (Input.GetKeyDown (KeyCode.E)) 
			{
				hasItem = true;
				Item1.sprite = replaceSprite;
				Destroy (other.gameObject.GetComponent<Collider2D> ());
			}
			break;

		case "TP":
			Application.LoadLevel (leveltoload);
			break;

		case "Coconut":
			excl.enabled = true;
			if (Input.GetKeyDown (KeyCode.E)) 
			{
				hasItem = true;
				Item1.enabled = false;
				Destroy (other.gameObject.GetComponent<Collider2D>());
			}
			break;

		case "PalmTree":
			if (hasItem == true) 
			{
				excl.enabled = true;
			}

			if (hasItem == false) 
			{
				ques.enabled = true;
			}

			if (Input.GetKeyDown (KeyCode.E) && hasItem == true) 
			{
				maattori.SetTrigger ("Healed");
				BoxCollider2D[] tempArr = other.GetComponents<BoxCollider2D> ();
				hasItem2 = true;
				foreach (BoxCollider2D box in tempArr) 
				{
					box.enabled = false;
				}
			}
			break;

		case "Altar":
			if (hasItem2 == true) 
			{
				excl.enabled = true;
			}

			if (hasItem2 == false) 
			{
				ques.enabled = true;
			}

			if (Input.GetKeyDown (KeyCode.E) && hasItem2 == true) 
			{
				BoxCollider2D tempArr = other.GetComponent<BoxCollider2D> ();
				tempArr.enabled = false;
				Sprot.sprite = replaceSprite;
				Application.LoadLevel (3);
			}
			break;
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		ques.enabled = false;
		excl.enabled = false;
	}
}
