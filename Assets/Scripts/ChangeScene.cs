using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*
 * A class for changing scenes/rooms
 */
public class ChangeScene : MonoBehaviour {

	//Startscene is for the House scene:
	//This script manages which scene appears first/how to change the scene, so
	//the first scene needs to be recorded
	//
	//Additionally, the startscene is also the current scene
    public GameObject startscene = null;


	// A callback for buttons (in button gameobjects, you can specify this
	//                         script and this function as a callback)
    public void onclick(string scene)
    {
        SceneManager.LoadScene(scene);
    }

#region changeroom function
	//Initialization code
	private void initscene(){
		GameObject[] rooms = GameObject.FindGameObjectsWithTag("room");
		foreach(GameObject r in rooms){
			r.transform.position = new Vector2(100, 100);
		}
	}

	// Function that changes the scene/room to another scene/room that is a
	// gameobject/prefab either in the scene, or store in the resources room
	// folder
    public void changeroom(string scene, GameObject character=null,
			float xspawn = 0, float yspawn = 0) // Dummy Values
    {
        GameObject[] rooms = GameObject.FindGameObjectsWithTag("room");
        GameObject g = null;
        foreach(GameObject r in rooms)
        {
            if(r.name == scene)
            {
                g = r;
            }
        }
		if(g == null){
			g = Instantiate(Resources.Load("Rooms/" + scene,
						typeof(GameObject))) as GameObject;
			g.name = g.name.Replace("(Clone)", "");
		}
        if(g != null)
        {
			SceneData d = g.GetComponent<SceneData>();
			if(character != null){
				if((xspawn == float.MaxValue || yspawn == float.MaxValue)){
					character.transform.position = new Vector2(d.xSpawn, d.ySpawn);
				}
				else{
					character.transform.position = new Vector2(xspawn, yspawn);
				}
			}
            if (startscene != null)
            {
                startscene.transform.position = new Vector3(100, 100, -20);
            }
            g.transform.position = new Vector3(0, 0, 0);
            startscene = g;
        }
    }
#endregion

	// Initialization
	void Start () {
		initscene();
	    if(startscene != null)
        {
            startscene.transform.position = new Vector3(0, 0, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
