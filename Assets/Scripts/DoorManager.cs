using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour {

    public string nextscene;
    public ChangeScene scenemanager;

    void OnCollisionEnter2D(Collision2D c)
    {
        scenemanager.changeroom(nextscene);
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
