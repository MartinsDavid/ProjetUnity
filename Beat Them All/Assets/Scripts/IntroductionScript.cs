using UnityEngine;
using System.Collections;

public class IntroductionScript : MonoBehaviour {


    public string level;

    void Start()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(7);
        Application.LoadLevel(level);
    }

}