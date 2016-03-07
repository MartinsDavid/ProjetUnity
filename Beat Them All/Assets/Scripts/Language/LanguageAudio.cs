﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LanguageAudio : MonoBehaviour {

	private GameObject titleAudio;
	private GameObject textVolume;
	private GameObject textBackAudio;




	// Use this for initialization
	void Start () {

		titleAudio = GameObject.Find ("TitleAudio");
		titleAudio.GetComponent<Text> ().text = Lang.Get("game.audio");

		textVolume = GameObject.Find ("TextVolume");
		textVolume.GetComponent<Text> ().text = Lang.Get("game.volume");
		
		textBackAudio = GameObject.Find ("TextBackAudio");
		textBackAudio.GetComponent<Text> ().text = Lang.Get("game.back");
	
	}
}