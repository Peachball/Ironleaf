using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour {

    public string nextscene;
    public ChangeScene scenemanager;
	
	private GameObject mc;

    void OnCollisionEnter2D(Collision2D c)
    {
        scenemanager.changeroom(nextscene, mc);
    }

	// Use this for initialization
	void Start () {
		mc = GameObject.Find("Main Character");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
