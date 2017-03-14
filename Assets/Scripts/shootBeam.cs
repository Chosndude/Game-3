using UnityEngine;
using System.Collections;

public class shootBeam : MonoBehaviour
{


    public GameObject beam;
    public float reload = .5f;
    float timer;
    bool shooting;
    public float Xdist = 0f;
    public float Ydist = 2f;

    void Update()
    {
        if (!shooting && Input.GetKey("e"))
        {
			
			Destroy(Instantiate(beam, new Vector3(transform.position.x + Xdist, transform.position.y + Ydist, transform.position.z), Quaternion.identity) as GameObject, 2);
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
