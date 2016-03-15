using UnityEngine;
using System.Collections;

public class ShotScriptLaser : MonoBehaviour
{
    private HealthBarScript healthBar;

    public AudioClip playerTouchedSound1;
    public AudioClip playerTouchedSound2;
    public AudioClip playerTouchedSound3;

    /// Projectile damage player or enemies?
    public bool isEnemyShot = true;

    void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthBarScript>();
        // 2 - Limited time to live to avoid any leak
        Destroy(gameObject, 4); // 4sec
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            healthBar.HitPlayer("Laser");
            switch (Random.Range(0, 3) % 3)
            {
                case 0:
                    AudioSource.PlayClipAtPoint(playerTouchedSound1, transform.position);
                    break;
                case 1:
                    AudioSource.PlayClipAtPoint(playerTouchedSound2, transform.position);
                    break;
                case 2:
                    AudioSource.PlayClipAtPoint(playerTouchedSound3, transform.position);
                    break;
            }
            Destroy(gameObject);
        }
    }

}
