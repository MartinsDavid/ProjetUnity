using UnityEngine;
using System.Collections;

public class Random : MonoBehaviour {

    public Sprite[] sprites;
    public string resourceName;

	// Use this for initialization
	void Start () {
        if (resourceName != "")
        {
            sprites = Resources.LoadAll<Sprite>(resourceName);
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
