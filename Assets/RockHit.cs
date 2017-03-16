using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class RockHit : NetworkBehaviour {
    Animator anim;
    int damage = 15;
    bool hit;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > .95f && anim.GetCurrentAnimatorStateInfo(0).IsName("break"))
        {
            print("this");
            Destroy(this.gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Platform")&& !hit)
        {
            hit = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().gravityScale = .5f;
            anim.SetInteger("hit", 1);
        }
        if (other.CompareTag("Player") && !hit)
        {
            hit = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().gravityScale = .5f;
            anim.SetInteger("hit", 1);
            other.GetComponent<updateHealth>().takeDamage(damage);
        }
    }
}
