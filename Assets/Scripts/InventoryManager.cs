using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {

	public const int MAX_BODY_LINES = 11;
	private Text titletext;
	private Text bodytext;
	private int pointer = 0;
	private Dictionary<string, int> items;

	private CanvasGroup cg;

	// Use this for initialization
	void Start () {
		cg = GetComponent<CanvasGroup>();
		titletext = transform.Find("InventoryTitle").gameObject.GetComponent<Text>();
		bodytext = transform.Find("InventoryText").gameObject.GetComponent<Text>();
		setTitle("HI");
		items = Globals.inventory;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private string format_inventory_string(){
		string displaytext = "";
		List<string> keys = new List<string>(items.Keys);
		keys.Sort();
		foreach(string k in keys){
			displaytext += k + " : " + items[k];
		}
		if(displaytext == ""){
			return "You have no items in your inventory currently";
		}
		return displaytext;
	}

	public void setTitle(string t){
		titletext.text = t;
	}

	public void setBody(string t){
		bodytext.text = t;
	}

	public void show(){
		cg.alpha = 1f;
	}

	public void hide(){
		cg.alpha = 0f;
	}

	public void movePointerUp(){
		if(pointer < items.Count - 1){
			pointer++;
		}
	}

	public void movePointerDown(){
		if(pointer > 0){
			pointer--;
		}
	}

	public void reset(){
		pointer = 0;
	}

	public void updateText(){
		setTitle("Inventory");
		setBody(format_inventory_string());
	}
}
