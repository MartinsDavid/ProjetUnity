using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LanguageSettings : MonoBehaviour {

	private GameObject titleSettings;
	private GameObject textLanguage;
	private GameObject textVideo;
	private GameObject textAudio;
	private GameObject textBackSettings;



	// Use this for initialization
	void Start () {
		Debug.Log ("START LANGUAGESETTINGS");


		titleSettings = GameObject.Find ("TitleSettings");
		textLanguage = GameObject.Find ("TextLanguage");
		textVideo = GameObject.Find ("TextVideo");
		textAudio = GameObject.Find ("TextAudio");
		textBackSettings = GameObject.Find ("TextBackSettings");
		LoadText ();
	}
	
	public void LoadText()
	{
		titleSettings.GetComponent<Text> ().text = Lang.Get ("game.settings");
		textLanguage.GetComponent<Text> ().text = Lang.Get("game.language");
		textVideo.GetComponent<Text> ().text = Lang.Get("game.video");
		textAudio.GetComponent<Text> ().text = Lang.Get("game.audio");
		textBackSettings.GetComponent<Text> ().text = Lang.Get("game.back");

	}


}
