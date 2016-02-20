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

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(7);
        Application.LoadLevel(level);
    }

}