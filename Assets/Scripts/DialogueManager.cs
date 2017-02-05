using UnityEngine;
using System.Collections;
using SimpleJSON;
using UnityEngine.UI;
using System.IO;
using System.Text;

// Handles things that involve the dialogue box
public class DialogueManager : MonoBehaviour {

    private Text textbox; //links to ui textbox

	private CanvasGroup cg;

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

	// Use this for initialization
	void Start () {
		cg = GetComponent<CanvasGroup>();
		textbox = GetComponentInChildren<Text>();
	}

    // Update is called once per frame
	void Update () {
	}

	/*
	 * Files are looked up in the "Assets/Dialogue" folder
	 *
	 * returns: string representing the text in the file
	 */
    public string loadDialogueFromFile(string filename)
    {
		string ps = System.IO.Path.DirectorySeparatorChar + "";
        var r = new StreamReader("Assets"+ps+"Dialogue" + ps + filename,
				Encoding.Default);
        return r.ReadToEnd();
    }

	public void hide(){
		cg.alpha = 0f;
	}

	public void show(){
		cg.alpha = 1f;
	}

#region helper methods
	//Set text of textbox
    public void setText(string text)
    {
        textbox.text = text;
    }
#endregion

#region Dialogue player
	/*Play lines with the appropriate timing based off of a json string
	 *
	 * Params:
	 *   lines: A json string representing the lines of dialogue + other
	 *          details(e.g. time)
	 *   delay: Amount of time to wait before playing said dialogue
	 *   		(Generally should be 0)
	*/
    public IEnumerator playLines(string lines, float delay=0.0f,
			string type="dialogue")
    {
		show();
        yield return new WaitForSeconds(delay);
        JSONNode parsed_dialogue = JSON.Parse(lines);
        for (int i = 0; i < parsed_dialogue.Count; i++)
        {
            string name = parsed_dialogue[i]["name"];
            string line = parsed_dialogue[i]["text"];
            float time = parsed_dialogue[i]["time"].AsFloat;

			      //Whether or not to wait for the user to click something to continue
			      //the dialogue
			      bool fast = parsed_dialogue[i]["fast"].AsBool;
			      if(!fast && i != 0){
				      while(!Input.GetButton("Interact")){
					      yield return null;
				      }
			      }
            yield return StartCoroutine(
					    playDialogue(lines: line, time: time, name: name));
        }
        yield return null;
    }

	/*
	 * Play one line of dialogue
	 *
	 * This method waits the appropriate amount of time between each character
	 * and appends the name to the dialogue line
	 */
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
            if (!Input.GetButton("Run"))
            {
              yield return new WaitForSeconds(time_bet_chars);
            }
        }
    }
#endregion

}
