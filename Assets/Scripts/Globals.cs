using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Contains various global variables relating to the game
public class Globals : MonoBehaviour {

	public static Dictionary<string, int> inventory = new Dictionary<string, int>();
	public static bool ready = false; // Signals when a certain scene is over
									  // and ready to be changed
    public static int trash_pieces = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
