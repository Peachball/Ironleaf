using UnityEngine;
using System.Collections;
using System;

public class CharacterControl : MonoBehaviour {

    public Rigidbody2D rb;
	public InventoryManager iv;

	private Animator animator;
    private int cur_dir; // Current direction character is walking in

    public float speed;
    public float runSpeed;
	public bool disabled = false;
    public bool trackCamera = false;
	private bool checking_inventory = false;
    private GameObject camera;

	// Use this for initialization
	void Start () {
		animator = GetComponentInChildren<Animator>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        if (trackCamera)
        {
            camera.transform.position = new Vector3(
                transform.position.x, transform.position.y, -10);
        }
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
		if((!checking_inventory) && Input.GetButtonDown("Inventory") && !disabled){
			checking_inventory = true;
			disabled = true;
			iv.reset();
			iv.updateText();
			iv.show();
		}

		else if(checking_inventory){
			if(Input.GetButtonDown("Inventory") || Input.GetButtonDown("Run")){
				iv.hide();
				checking_inventory = false;
				disabled = false;
			}
			if(Input.GetButtonDown("Up")){
				iv.movePointerUp();
			}
			if(Input.GetButtonDown("Down")){
				iv.movePointerDown();
			}
		}

        rb.velocity = vel;

        animator.SetInteger("prev_state", cur_dir);
        if(rb.velocity.magnitude != 0){
            if(Math.Abs(rb.velocity.y) >= Math.Abs(rb.velocity.x)){
                cur_dir = (rb.velocity.y > 0) ? 2 : 0;
            }
            else{
                cur_dir = (rb.velocity.x > 0) ? 1 : 3;
            }
        }
        animator.SetInteger("direction", cur_dir);
	}
}
