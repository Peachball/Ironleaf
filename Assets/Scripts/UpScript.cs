using UnityEngine;
using System.Collections;

public class UpScript : MonoBehaviour {

    public Vector2 end_pos;
    public float moveSpeed = 10;
    public float stopSpeed = 0;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 cur_pos = transform.position;
        moveSpeed = end_pos.y - cur_pos.y + 0.1f;

        if ( cur_pos.y < end_pos.y)
        {
            rb.velocity = new Vector2(0, moveSpeed);
        }
        else
        {
            rb.velocity = new Vector2(0, stopSpeed);
        }
    }
}
