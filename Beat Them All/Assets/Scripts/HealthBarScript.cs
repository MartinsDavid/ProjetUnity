using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {

	public float curHP = 100.0f;
	public float maxHP = 100.0f;

	public Texture2D HPBarTexture;
	public float HPBarLenght;
	public float PercentOfHP;

	public string scene;
	private Animator animator;

	private bool playedIsDead = false;


	void Start()
	{
		animator = GetComponent<Animator>();
	}



	void OnGUI () {

		if (curHP > 0)
		{
			GUI.DrawTexture(new Rect(30,30, HPBarLenght, 20), HPBarTexture);

		}

	}


	void Update () {

		PercentOfHP = curHP / maxHP;
		HPBarLenght = PercentOfHP * 400;

		// A ENLEVER !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		if (Input.GetKeyDown ("h"))
		{
			curHP -= 10;
		}

		if (curHP <= 0 && !playedIsDead)
		{
			PlayerDies();
		}
	
	}

	void PlayerDies()
	{
		playedIsDead = true;
		animator.SetInteger("AnimState", 4);

		GameObject go = new GameObject ("ClickToContinue");
		ClickToContinue script = go.AddComponent<ClickToContinue> ();
		script.scene = Application.loadedLevelName;
		go.AddComponent<DisplayRestartText> ();

	}
	
}
