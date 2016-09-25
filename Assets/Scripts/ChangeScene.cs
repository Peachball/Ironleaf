using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public GameObject startscene = null;

    public void onclick(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void changeroom(string scene)
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
        if(g != null)
        {
            if (startscene != null)
            {
                startscene.transform.position = new Vector3(100, 100, -20);
            }
            g.transform.position = new Vector3(0, 0, 0);
            startscene = g;
        }
    }
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
