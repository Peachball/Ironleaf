using UnityEngine;
using System.Collections;
using SimpleJSON;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject textbox;
    private Text t;

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
    
    //Placeholder (dialogue should be loaded in dynamically from txt files later
    private string dialogue = @"
[
{
    name : 'A',
    text : HIIIIII,
    time : 1
},
{
    name : 'B',
    text : BYEEEEEE,
    time : 10
}
]
";

    private float start_time;
    private JSONNode parsed_dialogue;
    private int line_num = 0;

	// Use this for initialization
	void Start () {
        start_time = Time.time;
        parsed_dialogue = JSON.Parse(dialogue);
        t = textbox.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        float max_elapsed_time = parsed_dialogue[line_num]["time"].AsFloat;
        if (Time.time - start_time > max_elapsed_time) {
            //Change text of textbox to reflect dialogue
            t.text = parsed_dialogue[line_num]["text"];

            line_num++;
            start_time = Time.time;
        }
	}
}
