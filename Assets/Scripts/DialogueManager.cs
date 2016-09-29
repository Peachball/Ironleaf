using UnityEngine;
using System.Collections;
using SimpleJSON;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class DialogueManager : MonoBehaviour {

    public Text textbox;

#region Dialogue format description
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
#endregion
    //Placeholder (dialogue should be loaded in dynamically from txt files later

	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
	void Update () {
	}

	/*
	 * Files are looked up in the "Assets/Dialogue" folder
	 */
    public string loadDialogueFromFile(string filename)
    {
		string ps = System.IO.Path.DirectorySeparatorChar + "";
        var r = new StreamReader("Assets"+ps+"Dialogue" + ps + filename,
				Encoding.Default);
        return r.ReadToEnd();
    }

#region helper methods
    private void setText(string text)
    {
        textbox.text = text;
    }
#endregion

#region Dialogue player
    public IEnumerator playLines(string lines, float delay=0.0f)
    {
		isplaying = true;
        yield return new WaitForSeconds(delay);
        JSONNode parsed_dialogue = JSON.Parse(lines);
        for (int i = 0; i < parsed_dialogue.Count; i++)
        {
            string name = parsed_dialogue[i]["name"];
            string line = parsed_dialogue[i]["text"];
            float time = parsed_dialogue[i]["time"].AsFloat;
            yield return StartCoroutine(playDialogue(lines: line, time: time, name: name));
        }
        yield return null;
		isplaying = false;
    }

    private IEnumerator playDialogue(string lines, float time, string name="")
    {
        float time_bet_chars = time / lines.Length;
        for(int i = 0; i <= lines.Length; i++)
        {
            string prefix = "";
            if(name != "")
            {
                prefix = name + " : ";
            }
            setText(prefix + lines.Substring(0, i));
            yield return new WaitForSeconds(time_bet_chars);
        }
    }
#endregion
}
