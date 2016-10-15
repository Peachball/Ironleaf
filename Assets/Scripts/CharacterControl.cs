using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

    public Rigidbody2D rb;

    public float speed;
    public float runSpeed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 vel = new Vector2(0, 0); //buffer for character velocity
        float movespeed;
		//Detect which button is pressed -> set velocity based off buttons
        if (Input.GetButton("Run"))
        {
          movespeed = runSpeed;
        }
        else
        {
          movespeed = speed;
        }
        if (Input.GetButton("Up"))
        {
            vel.y += movespeed;
        }
        if (Input.GetButton("Down"))
        {
          vel.y -= movespeed;
        }
        if (Input.GetButton("Right"))
        {
          vel.x += movespeed;
        }
        if (Input.GetButton("Left"))
        {
          vel.x -= movespeed;
        }
        rb.velocity = vel;
	}
}
