using UnityEngine;
using System.Collections;

public class shootGroundBeam : MonoBehaviour {


    public GameObject groundBeam;
    public float reload = .5f;
    float timer;
    bool shooting;
    public float Xdist2 = 2f;
    public float Ydist2 = -10f;
    
	void Update ()
    {
	    if (!shooting && Input.GetKey("r"))
        {
            Instantiate(groundBeam, new Vector3(transform.position.x + Xdist2, transform.position.y + Ydist2, transform.position.z), Quaternion.identity);
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
