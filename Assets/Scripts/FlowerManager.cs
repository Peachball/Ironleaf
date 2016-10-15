using UnityEngine;
using System.Collections;

public class FlowerManager : MonoBehaviour {

	private DialogueManager dbox;

	private void select(){

	}

	/*
	 * Get the text should be in the dialogue box
	 */
	private string getResponse(){
		string response = @"You see a flower,
but you aren't sure what to do about it";
		return response;
	}

	// Initialization
	void Start () {
		GameObject d = GameObject.Find("DialogueBackground");
		dbox = d.GetComponent<DialogueManager>();
	}
	

	void OnTriggerStay2D(Collider2D c){
		if(c.gameObject.name == "Main Character"
				&& Input.GetButton("Interact")){
			dbox.setText(getResponse());
		}
	}

	void OnTriggerExit2D(Collider2D c){
		if(c.gameObject.name == "Main Character"){
			dbox.setText("");
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
