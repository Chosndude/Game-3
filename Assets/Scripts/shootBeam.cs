using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class shootBeam : NetworkBehaviour
{


    public GameObject beam;
    public float reload = .5f;
    float timer;
    bool shooting;
    public float Xdist = 10f;
    public float Ydist = 10f;
	float dir = 1;

    void Update()
    {
		
		if (!isLocalPlayer) {
			return;
		
		}
		if (gameObject.GetComponent<playerMovement> ().getDirection () == false)
			dir = -1;
		else
			dir = 1;
        if (!shooting && Input.GetKey("e"))
        {
			GameObject cur = (Instantiate (beam, new Vector3 (transform.position.x + Xdist * dir, transform.position.y + Ydist, transform.position.z), Quaternion.identity) as GameObject);
			Destroy (cur, 2);
			cur.GetComponent<beamMovement> ().updateDir (GetComponent<playerMovement> ().getDirection ());
			shooting = true;
        }
        else
            timer += Time.deltaTime;
        if (timer > reload)
        {
            shooting = false;
            timer = 0f;
        }
    }

}
