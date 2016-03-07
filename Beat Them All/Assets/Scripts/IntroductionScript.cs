using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroductionScript : MonoBehaviour {


    public string level;

	private GameObject textIntroduction;

    void Start()
    {
		textIntroduction = GameObject.Find ("TextIntroduction");
		textIntroduction.GetComponent<Text> ().text = Lang.Get("game.introduction");

        StartCoroutine(LoadLevel());
    }

	
	// Update is called once per frame
	void Update()
	{	
		if (Input.GetKey ("escape"))
		{
			Application.LoadLevel (level);
		}	
	}

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(7);
        Application.LoadLevel(level);
    }

}