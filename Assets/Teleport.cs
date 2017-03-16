using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    float timer;
    float reload = 10f;
    bool teleported;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (timer > 0)
        {
            timer += Time.deltaTime;
        }
        if(timer > reload)
        {
            timer = 0f;
        }
        if(timer==0 && Input.GetKey("t"))
        {
            GetComponent<playerMovement>().freezeMovement();
            timer += Time.deltaTime;
        }
        else if (timer > 0f && timer <=1f && transform.localScale != new Vector3(.1f, .1f, 1f))
        {
            if(transform.localScale!=new Vector3(.1f,.1f,1f))
                transform.localScale -= new Vector3(.05f,.05f,0f);
        }
        else if(timer > 4f && transform.localScale != new Vector3(1f, 1f, 1f))
        {
            if (!teleported)
            {

            }
            if (transform.localScale != new Vector3(1f, 1f, 1f))
                transform.localScale += new Vector3(.05f,.05f,0f);
        }
        else
        {
            GetComponent<playerMovement>().defaultMovement();
        }
	}
}
