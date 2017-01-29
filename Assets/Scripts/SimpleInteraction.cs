using UnityEngine;
using System.Collections;

public class SimpleInteraction : MonoBehaviour {

    public string message;
    private DialogueManager dbox;

	// Use this for initialization
	void Start () {
        GameObject d = GameObject.Find("DialogueBackground");
        dbox = d.GetComponent<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D c){
		if(c.gameObject.name == "Main Character"
				&& Input.GetButton("Interact")){
            dbox.setText(message);
			dbox.show();
		}
	}

	void OnTriggerExit2D(Collider2D c){
		if(c.gameObject.name == "Main Character"){
			dbox.setText("");
			dbox.hide();
		}
	}
}
