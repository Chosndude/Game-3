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
        if (anim.GetInteger("attacking") == 0)
        {
            if (Input.GetKey("q")) {
                anim.SetInteger("attacking", 2);
                GetComponent<playerMovement>().freezeMovement();
            }
            else if (Input.GetKey("t"))
            {
                anim.SetInteger("attacking", 1);
            }
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.1f)
        {
            print("now");
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack_right") || anim.GetCurrentAnimatorStateInfo(0).IsName("jab_right"))
            {
                h.setAttack(false);
                anim.SetInteger("attacking", 0);
                GetComponent<playerMovement>().defaultMovement();
            }
        }

    }
}
