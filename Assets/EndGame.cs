using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

    public Text t;
    public Text smallt;

	// Use this for initialization
	void Start () {
		if (Globals.trash_pieces > 0) {
            t.text = "You finished the game...\n\nBUT YOU LOST\n\n";
            smallt.text = "(You should pick up trash, even if it's not yours)";
        }
        else {
            t.text = "You finished the game...\n\nAND YOU WON";
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
