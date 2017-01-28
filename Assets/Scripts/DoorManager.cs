using UnityEngine;
using System.Collections;

// Manages the behavior of doors
public class DoorManager : MonoBehaviour {

    public string nextscene;
    public ChangeScene scenemanager;

	// Spawn location after going through door
	public float xspawn;
	public float yspawn;

	// GameObject of main character
	private GameObject mc;

	//Handles when someone walks into door
    void OnCollisionEnter2D(Collision2D c)
    {
		if(scenemanager != null && c.gameObject.name == "Main Character"){
			scenemanager.changeroom(
					nextscene,
					character: mc,
					xspawn: xspawn,
					yspawn: yspawn);
		}
    }

	// Use this for initialization
	void Start () {
		mc = GameObject.Find("Main Character");
		if(scenemanager == null){
			scenemanager = GameObject.Find("Main Camera")
				.GetComponent<ChangeScene>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
