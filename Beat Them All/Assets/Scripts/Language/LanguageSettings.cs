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

		titleSettings = GameObject.Find ("TitleSettings");
		titleSettings.GetComponent<Text> ().text = Lang.Get("game.settings");

		textLanguage = GameObject.Find ("TextLanguage");
		textLanguage.GetComponent<Text> ().text = Lang.Get("game.language");

		textVideo = GameObject.Find ("TextVideo");
		textVideo.GetComponent<Text> ().text = Lang.Get("game.video");

		textAudio = GameObject.Find ("TextAudio");
		textAudio.GetComponent<Text> ().text = Lang.Get("game.audio");

		textBackSettings = GameObject.Find ("TextBackSettings");
		textBackSettings.GetComponent<Text> ().text = Lang.Get("game.back");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
