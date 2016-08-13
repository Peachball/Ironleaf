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
        rb.velocity = new Vector2(0, 0);
        if (Input.GetButton("Up"))
        {
            rb.velocity = new Vector2(0, speed);
        }
        if (Input.GetButton("Down"))
        {
            rb.velocity = new Vector2(0, -speed);
        }
        if (Input.GetButton("Right"))
        {
            rb.velocity = new Vector2(speed, 0);
        }
        if (Input.GetButton("Left"))
        {
            rb.velocity = new Vector2(-speed, 0);
        }

	}
}
