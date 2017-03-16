﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class jump : NetworkBehaviour {
    bool active;
    float timer;
    Vector3 local;

    void Start()
    {
        local = transform.localScale;
    }

	void Update () {
		if (!isLocalPlayer) {
			return;
		}
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        //print((transform.position.y-(transform.localScale.y/2) - (hit.transform.position.y+transform.localScale.y/2)));
        if (hit.collider != null && (transform.position.y - (local.y / 2) - (hit.transform.position.y + local.y / 2)) < .1f)
        {
            if (Input.GetKey("space") && active == false)
                Jump();
        }
        if (active) {
            timer += Time.deltaTime;
            if (timer > .2f &&
                hit.collider != null && (transform.position.y - (transform.localScale.y / 2) - (hit.transform.position.y + transform.localScale.y / 2)) < .3f)
            {
                print("therewego");
                active = false;
                timer = 0f;
            }
        }
        
	}
    
    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * 500f);
        active = true;
    }

    public bool onGround()
    {
        return !active;
    }
}
