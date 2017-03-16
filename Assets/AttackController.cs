using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class AttackController : NetworkBehaviour {

    public GameObject rock;
    public float Xdist = 2f;
    public float Ydist = 5f;
    float dir = 1;
    float reload = 2f;
    float timer;
    bool shot;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }
        if (!GetComponent<playerMovement>().getDirection())
            dir = -1;
        else
            dir = 1;
        if (shot)
        {
            timer += Time.deltaTime;
            if (timer > reload)
            {
                timer = 0f;
                shot = false;
            }
        }
        if (!shot && Input.GetKey("r"))
        {
            shot = true;
            Instantiate(rock, new Vector3(transform.position.x, transform.position.y+10f, transform.position.z), Quaternion.identity);
        }
	}
}
