using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ObjectInteraction : Interaction{

	public string message;
	public string pickup = "Pick up?";
	public string leave = "Leave it";
	public bool pickupDefault = true;

	// Use this for initialization
	protected new void Start () {
        base.Start();
	}

	// Update is called once per frame
	protected new void Update () {
        base.Update();
        if (in_interaction)
        {
            if (Input.GetButtonDown("Interact"))
            {
                if (pickupDefault)
                {
                    Dictionary<string, int> inv = Globals.inventory;
                    int itemcount;
                    if (!inv.TryGetValue(gameObject.name, out itemcount))
                    {
                        inv.Add(gameObject.name, 1);
                    }
                    else
                    {
                        inv[gameObject.name]++;
                    }
                    stop_interaction();
                    Destroy(gameObject);
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

    protected override string init_text()
    {
        return formatMessage(pickupDefault);
    }
}
