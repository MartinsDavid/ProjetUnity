using UnityEngine;
using System.Collections;

public class CreditsScript : MonoBehaviour {
	
	public GameObject texte;
	public int speed = 1;
	public string level;
	
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey ("escape"))
			Application.LoadLevel (level);

		texte.transform.Translate (Vector3.up * Time.deltaTime * speed);
	}
	
	IEnumerator waitFor()
	{
		yield return new WaitForSeconds (5);
		Application.LoadLevel (level);
	}
	
}