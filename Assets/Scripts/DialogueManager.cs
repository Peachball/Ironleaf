using UnityEngine;
using System.Collections;
using SimpleJSON;

public class DialogueManager : MonoBehaviour {

    public GameObject textbox;
    /*
        The dialogue will be formatted as a json list representing the speech of two people

        e.g.
        [
        {
            name : 'name of person talking',
            text : 'what person is saying',
            time : 'how long it takes for the text to be rendered to the screen'
        }
        ]
    */
    private string dialogue = @"
[
{
    name : 'A',
    text : 'HIIIIII',
    time : 10
},
{
    name : 'B',
    text : 'BYEEEEEE',
    time : 10
}
]
";

    private float start_time;
    private JSONNode parsed_dialogue;

	// Use this for initialization
	void Start () {
        start_time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void playDialogue()
    {

    }
}
