using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class shootBeam : NetworkBehaviour
{

    public GameObject beam;
    public float reload = .5f;
    float timer;
    bool shooting=false;
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
		if (!shooting && Input.GetKeyDown("e"))
        {
			CmdShoot ();
//			Shoot ();
        }
        else
            timer += Time.deltaTime;
        if (timer > reload)
        {
            shooting = false;
            timer = 0f;
        }
    }

	[Command]
	void CmdShoot(){
		{
			if (isServer) {
				GameObject cur = ((GameObject)Instantiate (beam, new Vector3 (transform.position.x + Xdist * dir, transform.position.y + Ydist, transform.position.z), Quaternion.identity));
			NetworkServer.Spawn (cur);
				Destroy (cur, 2);
				cur.GetComponent<beamMovement> ().updateDir (GetComponent<playerMovement> ().getDirection ());
				shooting = true;
			}
		}
	}


//	void Shoot(){
//		GameObject cur = ((GameObject)Instantiate (beam, new Vector3 (transform.position.x + Xdist * dir, transform.position.y + Ydist, transform.position.z), Quaternion.identity));
//		Destroy (cur, 2);
//		cur.GetComponent<beamMovement> ().updateDir (GetComponent<playerMovement> ().getDirection ());
//		shooting = true;
//	}
}
