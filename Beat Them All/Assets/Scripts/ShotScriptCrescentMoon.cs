using UnityEngine;
using System.Collections;

public class ShotScriptCrescentMoon : MonoBehaviour
{
    private HealthBarScript healthBar;
    public AudioClip enemyTouchedSound1;

    // Projectile damage player or enemies?
    public bool isEnemyShot;

    void Start()
    {
        // 2 - Limited time to live to avoid any leak
        Destroy(gameObject, 8); // 4sec
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        switch (target.gameObject.tag)
        {
            case "Enemy":
                target.gameObject.GetComponent<EnemyController>().HitEnemy("CrescentMoon");
                AudioSource.PlayClipAtPoint(enemyTouchedSound1, transform.position);
                break;

            case "Boss":
                target.gameObject.GetComponent<BossController>().HitEnemy("CrescentMoon");
                AudioSource.PlayClipAtPoint(enemyTouchedSound1, transform.position);
                Destroy(gameObject);
                break;
        }
    }
}
