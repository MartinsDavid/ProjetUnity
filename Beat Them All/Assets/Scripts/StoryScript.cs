using UnityEngine;
using System.Collections;

public class StoryScript : MonoBehaviour {
	
	public GameObject story;
	public GameObject title;
	public int speed = 1;
	public string level;

	private Sprite spriteStory;
	
	// Use this for initialization
	void Start()
	{
		spriteStory = Resources.Load<Sprite> (Lang.Get("game.story"));
		story.GetComponent<SpriteRenderer> ().sprite = spriteStory;


		StartCoroutine(LoadLevel());
	}
	
	// Update is called once per frame
	void Update()
	{
		
		if (Input.GetKey ("escape"))
		{
			Application.LoadLevel (level);
			DPLoadScreen.Instance.LoadLevel ("NewMainScene", true, level);
		}


		title.transform.Translate(Vector3.forward * Time.deltaTime * speed);
		story.transform.Translate(Vector3.up * Time.deltaTime * speed /16);
		story.transform.Translate(Vector3.forward * Time.deltaTime * speed /48);	
		
	}
	
	IEnumerator LoadLevel()
	{
		yield return new WaitForSeconds(30);
		DPLoadScreen.Instance.LoadLevel("NewMainScene", true, level);
	}
	
}
