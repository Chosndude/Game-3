using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class playerMovement : NetworkBehaviour {
	public Transform bulletSpawn;
	public GameObject beam;
    public float speed = 8f;
    float speedCopy;
    Vector3 movement;
    public Animator anim;
    bool direction;
    
    void Start()
    {
        speedCopy = speed;
    }

	void Update () {
		if (!isLocalPlayer) {
			return;
		}

        if (Input.GetKey("s"))
        {
            fastFall();
        }
        else
            movement.y = 0;

        float h = Input.GetAxisRaw("Horizontal");
        Move(h);

		if (Input.GetKeyDown("e"))
		{
			CmdShoot();
		}
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
        speedCopy = speed;
        speed = 0f;
    }

    public void defaultMovement()
    {
        speed = speedCopy;
    }
	[Command]
	public void CmdShoot(){
		var bullet = (GameObject)Instantiate(
			beam,new Vector3 (bulletSpawn.position.x + 2, bulletSpawn.position.y + 2, bulletSpawn.position.z),

			bulletSpawn.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

		// Spawn the bullet on the Clients
		NetworkServer.SpawnWithClientAuthority(bullet);
//		NetworkServer.Spawn(bullet);

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);


	}


}
