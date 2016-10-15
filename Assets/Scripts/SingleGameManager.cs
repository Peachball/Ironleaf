using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

// Plays cutscenes and changes scenes accordingly
public class SingleGameManager : MonoBehaviour{

	// Called when gameobject is loaded
	void Awake(){
		// Keep gameobject alive even when scene changes
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start(){
	}

#region startgame
	public void startgame(){
		StartCoroutine(rungame());
	}

	private IEnumerator rungame(){
		//Play first cutscene + wait until it's done
		SceneManager.LoadScene("Scenes/1stCutscene");
		yield return null;

		//Find the dialogue box to play dialogue from
		GameObject d = null;
		d = GameObject.Find("DialogueBackground");
		DialogueManager dm = d.GetComponent<DialogueManager>();

		//Load the dialogue
		string cutscenedialogue = dm.loadDialogueFromFile(
				"1stCutsceneDialogue.txt");
		//Play the dialogue
		yield return StartCoroutine(dm.playLines(cutscenedialogue));

		//Play first scene + wait for interaction to occur
		SceneManager.LoadScene("Scenes/House");
		yield return null;
	}
#endregion
}
