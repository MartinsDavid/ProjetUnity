using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour
{

    // 1 - Designer variables

    /// <summary>
    /// Damage inflicted
    /// </summary>
    public int damage = 1;

    /// <summary>
    /// Projectile damage player or enemies?
    /// </summary>
    public bool isEnemyShot = true;

    void Start()
    {
        // 2 - Limited time to live to avoid any leak
        Destroy(gameObject, 4); // 4sec
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
