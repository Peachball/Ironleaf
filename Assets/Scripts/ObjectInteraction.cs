using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectInteraction : MonoBehaviour {

	private bool inzone = false; // Indicator whether or not mc is within range
	private DialogueManager dbox;
	private CharacterControl cc;
	private bool scope = false;

	public string message;
	public string pickup = "Pick up?";
	public string leave = "Leave it";
	public bool pickupDefault = true;

	// Use this for initialization
	void Start () {
		dbox = GameObject.Find("DialogueBackground").GetComponent<DialogueManager>();
		cc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>();
	}

	private void leave_scope(){
		cc.disabled = false;
		dbox.setText("");
		dbox.hide();
		scope = false;
		pickupDefault = true;
	}

	
	// Update is called once per frame
	void Update () {
		if(scope && Input.GetButtonDown("Interact")){
			if(pickupDefault){
				Dictionary<string, int> inv = Globals.inventory;
				Debug.Log(inv);
				int itemcount;
				if(!inv.TryGetValue(gameObject.name, out itemcount)){
					inv.Add(gameObject.name, 1);
				}
				else{
					inv[gameObject.name]++;
				}
				leave_scope();
				Destroy(gameObject);
			}
			else{
				leave_scope();
			}
		}

		else if(inzone && Input.GetButtonDown("Interact")){
			dbox.setText(formatMessage(pickupDefault));
			dbox.show();
			cc.disabled = true;
			scope = true;
		}

		if(scope && (Input.GetButtonDown("Down") || Input.GetButtonDown("Up"))){
			pickupDefault = !pickupDefault;
			dbox.setText(formatMessage(pickupDefault));
		}

		if(scope && Input.GetButton("Run")){
			leave_scope();
		}
	}

    private bool isMainCharacter(Collider2D c)
    {
        return c.gameObject.tag == "Player";
    }

	
	private string formatMessage(bool p){
		string displaytext = message;
		displaytext += '\n';
		if (p) {
			displaytext += " > " + pickup + '\n' + "   " + leave;
		}
		else{
			displaytext += "   " + pickup + '\n' + " > " + leave;
		}
		return displaytext;
	}


    void OnTriggerEnter2D (Collider2D c)
    {
        if (isMainCharacter(c)) {
			inzone = true;
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
		if (isMainCharacter(c)){
			inzone = false;
			dbox.setText("");
			dbox.hide();
		}
    }
}
