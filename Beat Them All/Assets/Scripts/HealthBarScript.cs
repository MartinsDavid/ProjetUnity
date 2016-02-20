using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class HealthBarScript : MonoBehaviour
{

    public float currentHP;
    public float maxHP;

    public Texture2D HPBarTexture;
    public float HPBarLenght;
    public float PercentOfHP;

    public string scene;
    //private Animator animator;

    //private bool playerIsDead = false;

    private NewPlayerController playerController;
    
    void Awake()
    {
        playerController = GetComponent<NewPlayerController>();
    }

   /* void Start()
    {
        animator = GetComponent<Animator>();
    }*/
    
    void OnGUI()
    {

        if (currentHP > 0)
        {
            GUI.DrawTexture(new Rect(30, 30, HPBarLenght, 20), HPBarTexture);
        }
    }
    
    void Update()
    {
        PercentOfHP = currentHP / maxHP;
        HPBarLenght = PercentOfHP * 400;

        if (currentHP <= 0 && !playerController.isDead)
        {
            PlayerDies();
        }
    }

    void PlayerDies()
    {
        playerController.isDead = true;
        playerController.myAnimator.SetTrigger("death");

        GameObject go = new GameObject("ClickToContinue");
        ClickToContinue script = go.AddComponent<ClickToContinue>();
        script.scene = SceneManager.GetActiveScene().name;
        go.AddComponent<DisplayRestartText>();

    }

}
