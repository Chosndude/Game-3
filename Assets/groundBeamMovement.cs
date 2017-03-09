using UnityEngine;
using System.Collections;

public class groundBeamMovement : MonoBehaviour
{

    int damage = 5;
    public float Yspeed = 0f;
    Vector3 movement;
    void Start()
    {
        Destroy(this.gameObject, 4);
    }
    void Update()
    {
        movement.y = Yspeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
