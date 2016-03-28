using UnityEngine;
using System.Collections;

public class CreditsScript : MonoBehaviour {
	
	public GameObject credits;
	public int speed = 1;
	public string level;

	private Sprite spriteCredits;
	
	// Use this for initialization
	void Start () {
		spriteCredits = Resources.Load<Sprite> (Lang.Get("game.textCredits"));
		credits.GetComponent<SpriteRenderer> ().sprite = spriteCredits;

		StartCoroutine(waitFor());
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey ("escape"))
			Application.LoadLevel (level);

        credits.transform.Translate (Vector3.up * Time.deltaTime * speed);
	}
	
	IEnumerator waitFor()
	{
		yield return new WaitForSeconds (10);
		Application.LoadLevel (level);
    }

}