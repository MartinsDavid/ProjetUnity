using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

    public GameObject[] menuElement;
    private bool menuOpen = false;
    
    public AudioClip quitSound;
    public AudioClip highlightedButtonSound;


	// Use this for initialization
	void Start () {
        initMenu();	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonUp("Pause"))
        {
            switchState();
        }
	
	}

    //Met tous les éléments du menu Pause non visibles.
    void initMenu()
    {
        for (int i = 0; i < menuElement.Length; i++)
        {
            menuElement[i].SetActive(false);
        }
    }

    //Change l'état visible ou non visible du menu Pause.
    void switchState()
    {
        menuOpen = !menuOpen;
        for (int i = 0; i < menuElement.Length; i++)
            menuElement[i].SetActive(menuOpen);
    }

    public void Resume()
    {
        switchState();
    }


    public void Quit()
    {
        AudioSource.PlayClipAtPoint (quitSound, transform.position);
		Application.Quit ();
    }
}
