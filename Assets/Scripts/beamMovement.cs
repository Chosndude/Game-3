using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class beamMovement : NetworkBehaviour
{

    int damage = 1;
    public float Xspeed = 10f;
    Vector3 movement;
    float dir = 1;

    void Start()
    {
		if (gameObject.GetComponentInParent<playerMovement>().getDirection() == false)
            dir = -1;
    }
    void Update()
    {
        movement.x = dir * Xspeed * Time.deltaTime;
        transform.Translate(movement);
    }





    void OnTriggerEnter2D(Collider2D other)
    {

        {
            other.gameObject.GetComponent<updateHealth>().takeDamage(damage);
            Destroy(this.gameObject);
        }
 

    }
}
