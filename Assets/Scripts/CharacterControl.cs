using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

    public Rigidbody2D rb;

    public float speed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 vel = new Vector2(0, 0); //buffer for character velocity

		//Detect which button is pressed -> set velocity based off buttons
        if (Input.GetButton("Up"))
        {
            vel.y += speed;
        }
        if (Input.GetButton("Down"))
        {
            vel.y -= speed;
        }
        if (Input.GetButton("Right"))
        {
            vel.x += speed;
        }
        if (Input.GetButton("Left"))
        {
            vel.x -= speed;
        }
        rb.velocity = vel;
	}
}
