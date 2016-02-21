using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VideoScript : MonoBehaviour {


	private GameObject toggleFullScreen;
	private GameObject sliderQualityGraphics;

	// Use this for initialization
	void Start () {

		toggleFullScreen = GameObject.Find ("FullScreen");

		if (Screen.fullScreen)
			toggleFullScreen.GetComponent<Toggle>().isOn = true;
		else
			toggleFullScreen.GetComponent<Toggle>().isOn = false;

		sliderQualityGraphics = GameObject.Find ("SliderQualityGraphics");


	}


	public void changeFullScreen()
	{
		Screen.fullScreen = toggleFullScreen.GetComponent<Toggle>().isOn;
	}

	public void changeGraphicsQuality()
	{
		QualitySettings.SetQualityLevel((int)sliderQualityGraphics.GetComponent<Slider> ().value);
	}

}
