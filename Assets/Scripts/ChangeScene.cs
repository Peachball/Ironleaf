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
            Vector3 pos = g.transform.position;
            gameObject.transform.position = new Vector3(pos.x, pos.y, -10);
			if(character != null){
				if((xspawn == float.MaxValue || yspawn == float.MaxValue)){
					character.transform.position = new Vector2(d.xSpawn + pos.y, d.ySpawn + pos.x);
				}
				else{
					character.transform.position = new Vector2(pos.x + xspawn, pos.y + yspawn);
				}
			}
        }
        else
        {
            Debug.Log("Could not find room with name:");
        }
    }
#endregion

	// Initialization
	void Start () {
	    if(startscene != null)
        {
            startscene.transform.position = new Vector3(0, 0, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
