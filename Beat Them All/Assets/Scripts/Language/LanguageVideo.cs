using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LanguageVideo : MonoBehaviour {

	private GameObject titleVideo;
	private GameObject textFullScreen;
	private GameObject textQualityGraphics;
	private GameObject textAntiAliasing;
	private GameObject textBackVideo;

	// Use this for initialization
	void Start () {
	
		titleVideo = GameObject.Find ("TitleVideo");
		titleVideo.GetComponent<Text> ().text = Lang.Get("game.video");

		textQualityGraphics = GameObject.Find ("TextQualityGraphics");
		textQualityGraphics.GetComponent<Text> ().text = Lang.Get("game.qualityGraphics");

		textAntiAliasing = GameObject.Find ("TextAntiAliasing");
		textAntiAliasing.GetComponent<Text> ().text = Lang.Get("game.antiAliasing");

		textFullScreen = GameObject.Find ("TextFullScreen");
		textFullScreen.GetComponent<Text> ().text = Lang.Get("game.fullScreen");

		textBackVideo = GameObject.Find ("TextBackVideo");
		textBackVideo.GetComponent<Text> ().text = Lang.Get("game.back");

	}
}
