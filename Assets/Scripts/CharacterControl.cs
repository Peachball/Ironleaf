using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

    public Rigidbody2D rb;
	private Animator animator;

    public float speed;
    public float runSpeed;
	public bool disabled = false;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
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
		if (!disabled){
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
		}
        rb.velocity = vel;

		animator.SetFloat("VelX", rb.velocity.x);
	}
}
