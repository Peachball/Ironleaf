using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : Interaction {

	public bool pickupDefault = true;
	private string pickup = "Dispose";
	private string leave = "Don't do anything";
	// Use this for initialization
	void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update();
        if (in_interaction){
            if (Input.GetButtonDown("Interact"))
            {
                if (pickupDefault)
                {
                    Dictionary<string, int> inv = Globals.inventory;
                    int itemcount;
                    if (!inv.TryGetValue("Trash", out itemcount))
                    {
                        // Trash value does not exist, so don't do anything
                    }
                    else
                    {
                        inv["Trash"] = 0;
                    }
                    stop_interaction();
                }
                else
                {
                    stop_interaction();
                }
            }
            if (Input.GetButton("Run"))
            {
                stop_interaction();
            }
            if ((Input.GetButtonDown("Down") || Input.GetButtonDown("Up")))
            {
                pickupDefault = !pickupDefault;
                set_text(formatMessage(pickupDefault));
            }
        }
	}

    protected override string init_text(){
        return formatMessage(pickupDefault);
    }

	private string formatMessage(bool p){
		string displaytext = "Dispose of trash?";
		displaytext += '\n';
		if (p) {
			displaytext += " > " + pickup + '\n' + "   " + leave;
		}
		else{
			displaytext += "   " + pickup + '\n' + " > " + leave;
		}
		return displaytext;
	}
}
