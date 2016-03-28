using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LanguageScript : MonoBehaviour {

	GameObject lang;

	LanguageAudio languageAudio;
	LanguageLanguage languageLanguage;
	LanguageMenu languageMenu;
	LanguageSettings languageSettings;
	LanguageVideo languageVideo;

	public Toggle[] toggles;
	Toggle toggleChecked;


	// Use this for initialization
	void Start () {

		lang = GameObject.Find("(singleton) Lang");

		languageAudio = GameObject.Find ("AudioWindow").GetComponent<LanguageAudio>();
		languageLanguage = GameObject.Find ("LanguageWindow").GetComponent<LanguageLanguage>();	
		languageMenu = GameObject.Find ("MainMenu").GetComponent<LanguageMenu>();	
		languageSettings = GameObject.Find ("SettingsWindow").GetComponent<LanguageSettings>();
		languageVideo = GameObject.Find ("VideoWindow").GetComponent<LanguageVideo> ();

		foreach (Toggle tg in toggles)
		{
			tg.isOn = false;
			if(tg.name == lang.GetComponent<Lang>().language)
			{
				tg.isOn = true;
			}
		}
	}


	public void changeLanguage()
	{
		foreach (Toggle tg in toggles)
		{
			if(tg.isOn == true)
			{
				lang.GetComponent<Lang> ().LoadLanguage(tg.name);
			}
		}

		languageAudio.LoadText ();
		languageLanguage.LoadText ();
		languageMenu.LoadText ();
		languageSettings.LoadText ();
		languageVideo.LoadText ();

	}


}


