using UnityEngine;
using System.Collections;

public class beamMovement : MonoBehaviour
{

    int damage = 1;
    public float Xspeed = 10f;
    Vector3 movement;
    float dir = 1;

    void Start()
    {
        print(GameObject.FindWithTag("Player").GetComponent<playerMovement>().getDirection());
        if (GameObject.FindWithTag("Player").GetComponent<playerMovement>().getDirection() == false)
            dir = -1;
    }
    void Update()
    {
        movement.x = dir * Xspeed * Time.deltaTime;
        transform.Translate(movement);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player2"))
        {
            other.gameObject.GetComponent<updateHealth>().takeDamage(damage);
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Boundary"))
        {
            Destroy(this.gameObject);
        }
    }
}
