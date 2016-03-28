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
		textQualityGraphics = GameObject.Find ("TextQualityGraphics");
		textAntiAliasing = GameObject.Find ("TextAntiAliasing");
		textFullScreen = GameObject.Find ("TextFullScreen");
		textBackVideo = GameObject.Find ("TextBackVideo");
		LoadText ();
	}

	public void LoadText()
	{
		titleVideo.GetComponent<Text> ().text = Lang.Get("game.video");
		textQualityGraphics.GetComponent<Text> ().text = Lang.Get("game.qualityGraphics");
		textAntiAliasing.GetComponent<Text> ().text = Lang.Get("game.antiAliasing");
		textFullScreen.GetComponent<Text> ().text = Lang.Get("game.fullScreen");
		textBackVideo.GetComponent<Text> ().text = Lang.Get("game.back");
	}
}
