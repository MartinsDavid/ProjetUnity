using UnityEngine;
using System.Collections;

public class ShotScriptCrescentMoon : MonoBehaviour
{
    private HealthBarScript healthBar;
    public AudioClip enemyTouchedSound1;

    public Transform shot;
    private Vector2 shotAxisMove;

    // Projectile damage player or enemies?
    public bool isEnemyShot;

    void Start()
    {
        shotAxisMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //Checks to see which way our player is going and flips their facing direction
        if (shotAxisMove.x > 0)
        {
            shot.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else if (shotAxisMove.x < 0)
        {
            shot.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

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
            case "Box":
                target.gameObject.GetComponent<BoxScript>().HitBox("CrescentMoon");
                break;
        }
    }
}
