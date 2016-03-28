using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LanguageLanguage : MonoBehaviour {

	private GameObject titleLanguage;
	private GameObject textBackLanguage;


	// Use this for initialization
	void Start () {
		titleLanguage = GameObject.Find ("TitleLanguage");	
		textBackLanguage = GameObject.Find ("TextBackLanguage");
		LoadText ();
	}


	public void LoadText()
	{
		titleLanguage.GetComponent<Text> ().text = Lang.Get("game.language");
		textBackLanguage.GetComponent<Text> ().text = Lang.Get("game.back");
	}

}
