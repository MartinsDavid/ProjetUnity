using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour
{

	private HealthBarScript health;


    // 1 - Designer variables
    /// <summary>
    /// Damage inflicted
    /// </summary>
    public int damage = 10;

    /// <summary>
    /// Projectile damage player or enemies?
    /// </summary>
    public bool isEnemyShot = true;

    void Start()
    {
		health = GameObject.FindGameObjectWithTag ("Player").GetComponent<HealthBarScript> ();
        // 2 - Limited time to live to avoid any leak
        Destroy(gameObject, 4); // 4sec
    }
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			health.curHP -= damage;
			Destroy(gameObject);
			
		}
	}

}
