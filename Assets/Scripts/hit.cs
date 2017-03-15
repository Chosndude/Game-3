using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class hit : NetworkBehaviour
{
    int attackDamage = 10;
    int jabDamage = 1;
    bool attacking;
    bool dealtDamage;
    bool inTrigger;
    public Animator anim;
    GameObject enemy;
    bool pos = true;
    void Update()
    {
        if (pos != gameObject.GetComponentInParent<playerMovement>().getDirection())
        {
            pos = gameObject.GetComponentInParent<playerMovement>().getDirection();
			transform.position = new Vector3(gameObject.transform.position.x + (gameObject.transform.position.x - transform.position.x), transform.position.y, transform.position.z);
        }
        else
			transform.position.Set(transform.position.x + 2, transform.position.y, transform.position.z);
            print(attacking);
        if (attacking == false && inTrigger && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > .75f)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("jab_right"))
            {
                enemy.GetComponent<updateHealth>().takeDamage(jabDamage);
                attacking = true;
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack_right"))
            {
                enemy.GetComponent<updateHealth>().takeDamage(attackDamage);
                attacking = true;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
		
        print("shit");
        if (other.CompareTag("Player"))
        {
            print("hell yeah");
            enemy = other.gameObject;
            inTrigger = true;
            print("ugh");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            inTrigger = false;
    }
    public void setAttack(bool t)
    {
        attacking = t;
    }
}

