using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SingleGameManager : MonoBehaviour{
	void Awake(){
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
		GameObject d = null;
		yield return new WaitForSeconds(0.05f);
		d = GameObject.Find("Canvas");
		DialogueManager dm = d.GetComponent<DialogueManager>();
		string cutscenedialogue = dm.loadDialogueFromFile(
				"1stCutsceneDialogue.txt");
		yield return StartCoroutine(dm.playLines(cutscenedialogue));

		//Play first scene + wait for interaction to occur
		SceneManager.LoadScene("Scenes/House");

		yield return null;
	}
#endregion
}
