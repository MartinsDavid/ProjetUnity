using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	public int points = 0;
	public GUISkin LabelSkin;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.skin = LabelSkin;
		GUI.Label (new Rect (40, 60, 300, 50), Lang.Get("game.score") + " : " + points);
	}



}
