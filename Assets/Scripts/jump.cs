using UnityEngine;
using System.Collections;

public class jump : MonoBehaviour {
    bool active;
    float timer;
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        print((transform.position.y-(transform.localScale.y/2) - (hit.transform.position.y+transform.localScale.y/2)));
        if (hit.collider != null && (transform.position.y - (transform.localScale.y / 2) - (hit.transform.position.y + transform.localScale.y / 2)) < .1f)
        {
            if (Input.GetKey("space") && active == false)
                Jump();
        }
        if (active) {
            timer += Time.deltaTime;
            if (timer > .3f)
                active = false;
        }
        
	}
    
    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * 400f);
        active = true;
    }
}
