using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    public float speed = 8f;
    Vector3 movement;
    public Animator anim;
    bool direction;

	void Update () {

        if (Input.GetKey("s"))
        {
            fastFall();
        }
        else
            movement.y = 0;

        float h = Input.GetAxisRaw("Horizontal");
        Move(h);
    }
    
    void Move(float h)
    {
        movement.x = h * speed * Time.deltaTime;

        if (movement.x > 0)
        {
            direction = true;
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        else if (movement.x < 0)
        {
            direction = false;
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        transform.Translate(movement);
    }

    public bool getDirection()
    {
        return direction;
    }

    void fastFall()
    {
        print(GetComponent<jump>().onGround());
        if (GetComponent<jump>().onGround() == false)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            movement.y = -.20f;
        }
        else
            movement.y = 0f;
    }

    public void freezeMovement()
    {
        speed = 0f;
    }

    public void defaultMovement()
    {
        speed = 8f;
    }
}
