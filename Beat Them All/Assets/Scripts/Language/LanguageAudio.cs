using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LanguageAudio : MonoBehaviour {

	private GameObject titleAudio;
	private GameObject textVolume;
	private GameObject textBackAudio;




	// Use this for initialization
	void Start () {
		titleAudio = GameObject.Find ("TitleAudio");
		textVolume = GameObject.Find ("TextVolume");
		textBackAudio = GameObject.Find ("TextBackAudio");
		LoadText ();	
	}

	public void LoadText()
	{
		titleAudio.GetComponent<Text> ().text = Lang.Get("game.audio");
		textVolume.GetComponent<Text> ().text = Lang.Get("game.volume");
		textBackAudio.GetComponent<Text> ().text = Lang.Get("game.back");
	}
}
