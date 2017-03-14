using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Beam:MonoBehaviour{




	void OnCollisionEnter(Collision collision){
	
		var hit = collision.gameObject;
		var health = hit.GetComponent<Health> ();
		if (health != null) {
			health.TakeDamage (2);
		}
		Destroy (gameObject);
	}

}