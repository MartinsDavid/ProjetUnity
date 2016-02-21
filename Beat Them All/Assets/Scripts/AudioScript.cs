using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioScript : MonoBehaviour {

	private GameObject sliderVolume;
	
	// Use this for initialization
	void Start () {

		sliderVolume = GameObject.Find ("SliderVolume");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeVolume()
	{
		AudioListener.volume = 	sliderVolume.GetComponent<Slider> ().value;
	}


}
