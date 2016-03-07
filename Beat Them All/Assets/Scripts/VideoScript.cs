using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VideoScript : MonoBehaviour {


	private GameObject toggleFullScreen;
	private GameObject sliderQualityGraphics;
	private GameObject sliderAntiAliasing;

	// Use this for initialization
	void Start () {

		toggleFullScreen = GameObject.Find ("FullScreen");

		if (Screen.fullScreen)
			toggleFullScreen.GetComponent<Toggle>().isOn = true;
		else
			toggleFullScreen.GetComponent<Toggle>().isOn = false;

		sliderQualityGraphics = GameObject.Find ("SliderQualityGraphics");

		sliderAntiAliasing = GameObject.Find ("SliderAntiAliasing");
	}


	public void changeFullScreen()
	{
		Screen.fullScreen = toggleFullScreen.GetComponent<Toggle>().isOn;
	}

	public void changeGraphicsQuality()
	{
		QualitySettings.SetQualityLevel((int)sliderQualityGraphics.GetComponent<Slider> ().value);
	}

	public void changeAntiAliasing()
	{
		switch ((int)sliderAntiAliasing.GetComponent<Slider> ().value)
		{
			case 0 :
				QualitySettings.antiAliasing = 0;
				break;
			case 1 :
				QualitySettings.antiAliasing = 2;
				break;
			case 2 :
				QualitySettings.antiAliasing = 4;
				break;
			case 3 :
				QualitySettings.antiAliasing = 8;
				break;
		}
	}

}
