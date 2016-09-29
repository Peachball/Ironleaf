using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public GameObject startscene = null;

    public void onclick(string scene)
    {
        SceneManager.LoadScene(scene);
    }

#region changeroom function
    public void changeroom(string scene, GameObject character=null,
			float xspawn=float.MaxValue, float yspawn=float.MaxValue)
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
				if(!(xspawn == float.MaxValue || yspawn == float.MaxValue)){
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

	// Use this for initialization
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
