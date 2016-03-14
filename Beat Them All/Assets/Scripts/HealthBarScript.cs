using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HealthBarScript : MonoBehaviour {

    // GameObject attributes
    public float curHP;
    public float maxHP;
    private Animator animator;
    private bool playedIsDead = false;

    //Player controller script
    private PlayerController playerController;

    // UI attributes
    public Texture2D HPBarTexture;
    public float HPBarLenght;
    public float PercentOfHP;

    //Audio
    public AudioClip deathSound;	
	
	void Start()
	{
		animator = GetComponent<Animator>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }

    void OnGUI ()
    {	
		if (curHP > 0)
		{
			GUI.DrawTexture(new Rect(30,30, HPBarLenght, 20), HPBarTexture);
        }
    }

	void Update () {
		
		PercentOfHP = curHP / maxHP;
		HPBarLenght = PercentOfHP * 400;
		
		if (curHP <= 0 && !playedIsDead)
		{
			PlayerDies();
		}
		
	}
	
	void PlayerDies()
	{
		AudioSource.PlayClipAtPoint (deathSound, transform.position);

        playedIsDead = true;
        animator.SetTrigger("death");

        GameObject go = new GameObject("ClickToContinue");
        ClickToContinue script = go.AddComponent<ClickToContinue>();
        script.scene = SceneManager.GetActiveScene().name; ;
        go.AddComponent<DisplayRestartText>();

    }

    //When the boss hit the player
    public void Hit(string attackName, int damage)
    {
        playerController.isAttacking = true;
        curHP -= damage;
        switch (attackName)
        {
            case "Kick":
                animator.SetTrigger("gotHit");
                break;
            case "Sphere":
                animator.SetTrigger("gotHit");
                break;
            case "AttackExe":
                animator.SetTrigger("gotHit");
                break;
        }


    }

}
