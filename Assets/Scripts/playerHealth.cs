using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour {

    int hitPoints = 100;
    int maxHitPoints = 100;

	void Update () {
	    //if(hitPoints <= 0)
            //nextRound
	}

    public void takeDamage(int damage)
    {
        if (hitPoints > 0)
        {
            hitPoints -= damage;
        }
    }
}
