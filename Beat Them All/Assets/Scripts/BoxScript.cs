using UnityEngine;
using System.Collections;

public class BoxScript : MonoBehaviour {

    //hearth prefab 
    public Transform hearthPrefab;

    //Box attributes
    private int healthPoint;
    public Animator boxAnimator;

    //Sound
    public AudioClip destructedBoxSound;
	

    void Start()
    {
        healthPoint = Random.Range(1, 3);
    }
	
    //When our player hit the box
    public void HitBox(string attackName)
    {
        switch (attackName)
        {
            case "Punch":
                healthPoint -= 1;
                break;
            case "CrescentMoon":
                healthPoint -= 2;
                break;
        }
        if (healthPoint > 0)
            boxAnimator.SetTrigger("gotHit");
        else
        {
            AudioSource.PlayClipAtPoint(destructedBoxSound, transform.position);
            boxAnimator.SetTrigger("death");
        }
    }

    void DropHearth()
    {
        //Create a new hearth
        var hearth = Instantiate(hearthPrefab) as Transform;

        //Assign position
        hearth.position = transform.position;
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
