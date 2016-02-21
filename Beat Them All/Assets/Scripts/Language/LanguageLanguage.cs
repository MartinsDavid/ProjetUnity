using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LanguageLanguage : MonoBehaviour {

	private GameObject titleLanguage;
	private GameObject textBackLanguage;


	// Use this for initialization
	void Start () {
	
		titleLanguage = GameObject.Find ("TitleLanguage");
		titleLanguage.GetComponent<Text> ().text = Lang.Get("game.language");
		
		textBackLanguage = GameObject.Find ("TextBackLanguage");
		textBackLanguage.GetComponent<Text> ().text = Lang.Get("game.back");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
