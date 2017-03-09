using UnityEngine;
using System.Collections;

public class playerAttack : MonoBehaviour {

    Animator anim;
    public hit h;
	// Use this for initialization
	void Start () {
	    anim = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (anim.GetInteger("attacking") == 0 && Input.GetKey("q"))
        {
            print("anim");
            anim.SetInteger("attacking", 2);
            GetComponent<playerMovement>().freezeMovement();
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.1f && (anim.GetCurrentAnimatorStateInfo(0).IsName("attack_right") || anim.GetCurrentAnimatorStateInfo(0).IsName("attack_left")))
        {
            anim.SetInteger("attacking", 0);
            h.setAttack(false);
            GetComponent<playerMovement>().defaultMovement();
        }

    }
}
