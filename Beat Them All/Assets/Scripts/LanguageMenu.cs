using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LanguageMenu : MonoBehaviour {

	private GameObject textMenu;
	private GameObject textPlayGame;
	private GameObject textSettings;
	private GameObject textCredits;
	private GameObject textQuit;

	private GameObject textLanguage;
	private GameObject textBack;


	// Use this for initialization
	void Start () {
	
		textMenu = GameObject.Find ("TextMenu");
		textMenu.GetComponent<Text> ().text = Lang.Get("game.menu");
		
		textPlayGame = GameObject.Find ("TextPlayGame");
		textPlayGame.GetComponent<Text> ().text = Lang.Get("game.playGame");

		textSettings = GameObject.Find ("TextSettings");
		textSettings.GetComponent<Text> ().text = Lang.Get("game.settings");

		textCredits = GameObject.Find ("TextCredits");
		textCredits.GetComponent<Text> ().text = Lang.Get("game.credits");

		textQuit = GameObject.Find ("TextQuit");
		textQuit.GetComponent<Text> ().text = Lang.Get("game.quit");
		/*
		textLanguage = GameObject.Find ("TextLanguage");
		textLanguage.GetComponent<Text> ().text = Lang.Get("game.language");

		textBack = GameObject.Find ("TextBack");
		textBack.GetComponent<Text> ().text = Lang.Get("game.back");
		*/


	}
	
	// Update is called once per frame
	void Update () {

	}


}
