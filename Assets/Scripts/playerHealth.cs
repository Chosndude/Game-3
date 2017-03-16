using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class playerHealth : NetworkBehaviour {
	[SyncVar]
    public int hitPoints = 100;
    int maxHitPoints = 100;

	void Update () {
	    //if(hitPoints <= 0)
            //nextRound
	}

    public void takeDamage(int damage)
	{	
		if (!isLocalPlayer) {
			return;
		}
        if (hitPoints > 0)
        {
            hitPoints -= damage;
        }
    }
}
