using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour
{

	private HealthBarScript healthBar;


    // 1 - Designer variables

    /// Damage inflicted
    public int damage;


    /// Projectile damage player or enemies?
    public bool isEnemyShot = true;

    void Start()
    {
		healthBar = GameObject.FindGameObjectWithTag ("Player").GetComponent<HealthBarScript> ();
        // 2 - Limited time to live to avoid any leak
        Destroy(gameObject, 4); // 4sec
    }

	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			healthBar.curHP -= damage;
			Destroy(gameObject);
		}
	}

}
