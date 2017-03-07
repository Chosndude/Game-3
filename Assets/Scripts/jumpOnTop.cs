using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpOnTop : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D c) {
		if (c.gameObject.CompareTag("Player") && c.contacts[0].normal.Equals(Vector2.up)) {
			print("Hit on Player 1");
		}
		else if (c.gameObject.CompareTag("Player2") && c.contacts[0].normal.Equals(Vector2.up)) {
			print("Hit on Player 2");
		}
	}
}
