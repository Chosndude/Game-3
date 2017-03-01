using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    public float speed = 8f;
    Vector3 movement;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxisRaw("Horizontal");
        Move(h);
    }
    
    void Move(float h)
    {
        movement.x = h * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}
