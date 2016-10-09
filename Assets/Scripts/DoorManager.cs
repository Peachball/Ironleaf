using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour {

    public string nextscene;
    public ChangeScene scenemanager;
	public float xspawn;
	public float yspawn;
	
	private GameObject mc;

    void OnCollisionEnter2D(Collision2D c)
    {
		if(scenemanager != null){
			scenemanager.changeroom(nextscene, mc);
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
