using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LanguageMenu : MonoBehaviour {

	private GameObject textMenu;
	private GameObject textPlayGame;
	private GameObject textSettings;
	private GameObject textCredits;
	private GameObject textQuit;




	// Use this for initialization
	void Start () {
	
		textMenu = GameObject.Find ("TextMenu");	
		textPlayGame = GameObject.Find ("TextPlayGame");
		textSettings = GameObject.Find ("TextSettings");
		textCredits = GameObject.Find ("TextCredits");
		textQuit = GameObject.Find ("TextQuit");
		LoadText ();
	}
	
	public void LoadText()
	{
		textMenu.GetComponent<Text> ().text = Lang.Get("game.menu");
		textPlayGame.GetComponent<Text> ().text = Lang.Get("game.playGame");
		textSettings.GetComponent<Text> ().text = Lang.Get("game.settings");
		textCredits.GetComponent<Text> ().text = Lang.Get("game.credits");
		textQuit.GetComponent<Text> ().text = Lang.Get("game.quit");
	}


}
