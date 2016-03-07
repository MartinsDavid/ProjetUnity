<<<<<<< HEAD
﻿using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    //Player Variables
    private Transform playerBody;
    private Transform attackPoint1;
    private Transform attackPoint2;

    //Movement Controls
    public float moveSpeed;
    private Vector2 moveDirection;
    public int healthPoint;
    public bool isDead;
    public bool inFight;

    //Misc Controls
    public Transform enemyBody;
    public Transform enemyFeet;
    public SpriteRenderer enemySprite;
    public Animator enemyAnimator;

    // Weapon 
    public Transform enemyWeapon;
    private WeaponScript weaponScript;

    // Spawner ID
    int spawnID;
    public Transform enemySpawner;

	public AudioClip destructedDroidSound;


    void Awake()
    {

        // Retrieve the weapon only once
        weaponScript = GetComponentInChildren<WeaponScript>();
    }

    void Start()
    {

        //Find the player
        playerBody = GameObject.Find("PlayerController").transform;
        //Find attackPoints 1 and 2
        attackPoint1 = GameObject.Find("AttackPoint1").transform;
        attackPoint2 = GameObject.Find("AttackPoint2").transform;
        //Find the Weapon
        enemyWeapon = GetComponentInChildren<Transform>();
        //Find the spawner
        enemySpawner = GameObject.FindWithTag("Spawner").transform;

    }

    void Update()
    {

        //Set the enemy sprite order equal to our enemy's feet Y position
        enemySprite.sortingOrder = -(int)enemyFeet.position.y;

        if (transform.position.x < playerBody.position.x)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else if (transform.position.x > playerBody.position.x)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        if (!inFight)
        {
            inFight = true;
            // Auto-fire
            enemyWeapon = GetComponentInChildren<Transform>();

            if (enemyWeapon.position.y < playerBody.position.y + 1f && enemyWeapon.position.y > playerBody.position.y - 1f)
            {
                if (weaponScript != null && weaponScript.CanAttack)
                {
                    enemyAnimator.SetTrigger("attack");
                    weaponScript.Attack(true);
                }
            }

            inFight = false;
        }
    }

    void FixedUpdate()
    {
        if (!isDead && !inFight)
        {
            //Get the distances between our enemy and the attack points
            float attackDistance1 = Vector2.Distance(transform.position, attackPoint1.position);
            float attackDistance2 = Vector2.Distance(transform.position, attackPoint2.position);

            //Find the closest attack point, then move towards it
            if (attackDistance1 < attackDistance2)
            {
                if (attackDistance1 > 0.1f)
                {
                    MoveInDirection(attackPoint1);
                }
                else
                {
                    enemyAnimator.SetInteger("animState", 0);
                }
            }
            else
            {
                if (attackDistance2 > 0.1f)
                {
                    MoveInDirection(attackPoint2);
                }
                else
                {
                    enemyAnimator.SetInteger("animState", 0);
                }
            }
        }
    }

    //Move towards the given attack point
    void MoveInDirection(Transform tempTrans)
    {

        transform.position += (tempTrans.position - transform.position).normalized * moveSpeed * Time.deltaTime;

        enemyAnimator.SetInteger("animState", 1);
    }

    //When our player hit the enemy
    public void HitEnemy()
    {
        healthPoint -= 1;
        
        if (healthPoint <= 0)
        {
			AudioSource.PlayClipAtPoint (destructedDroidSound, transform.position);
            isDead = true;
            enemyAnimator.SetTrigger("death");
            enemySpawner.SendMessage("killEnemy", spawnID);
        }
        else
        {
            inFight = true;
            enemyAnimator.SetTrigger("gotHit");
        }
    }

    public void StopFight()
    {
        inFight = false;
    }

    //When our player kill the enemy
    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    // Applies the spawner's ID to the enemy.    It's cal from the script SpawnerEnemy.cs
    public void setName(int sID)
    {
        spawnID = sID;
    }


}
=======
﻿using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    //Player Variables
    private Transform playerBody;
    private Transform attackPoint1;
    private Transform attackPoint2;

    //Movement Controls
    public float moveSpeed;
    private Vector2 moveDirection;
    public int healthPoint;
    public bool isDead;
    public bool inFight;

    //Misc Controls
    public Transform enemyBody;
    public Transform enemyFeet;
    public SpriteRenderer enemySprite;
    public Animator enemyAnimator;

    // Weapon 
    public Transform enemyWeapon;
    private WeaponScript weaponScript;

    // Spawner ID
    int spawnID;
    public Transform enemySpawner;


    void Awake()
    {
        // Retrieve the weapon only once
        weaponScript = GetComponentInChildren<WeaponScript>();
    }

    void Start()
    {
        //Find the player
        playerBody = GameObject.Find("PlayerController").transform;
        //Find attackPoints 1 and 2
        attackPoint1 = GameObject.Find("AttackPoint1").transform;
        attackPoint2 = GameObject.Find("AttackPoint2").transform;
        //Find the Weapon
        enemyWeapon = GetComponentInChildren<Transform>();
        //Find the spawner
        enemySpawner = GameObject.FindWithTag("Spawner").transform;

    }

    void Update()
    {

        //Set the enemy sprite order equal to our enemy's feet Y position
        enemySprite.sortingOrder = -(int)enemyFeet.position.y;

        if (transform.position.x < playerBody.position.x)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else if (transform.position.x > playerBody.position.x)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        if (!inFight)
        {
            inFight = true;
            // Auto-fire
            enemyWeapon = GetComponentInChildren<Transform>();

            if (enemyWeapon.position.y < playerBody.position.y + 1f && enemyWeapon.position.y > playerBody.position.y - 1f)
            {
                if (weaponScript != null && weaponScript.CanAttack)
                {
                    enemyAnimator.SetTrigger("attack");
                    weaponScript.Attack(true);
                }
            }

            inFight = false;
        }
    }

    void FixedUpdate()
    {
        if (!isDead && !inFight)
        {
            //Get the distances between our enemy and the attack points
            float attackDistance1 = Vector2.Distance(transform.position, attackPoint1.position);
            float attackDistance2 = Vector2.Distance(transform.position, attackPoint2.position);

            //Find the closest attack point, then move towards it
            if (attackDistance1 < attackDistance2)
            {
                if (attackDistance1 > 0.1f)
                {
                    MoveInDirection(attackPoint1);
                }
                else
                {
                    enemyAnimator.SetInteger("animState", 0);
                }
            }
            else
            {
                if (attackDistance2 > 0.1f)
                {
                    MoveInDirection(attackPoint2);
                }
                else
                {
                    enemyAnimator.SetInteger("animState", 0);
                }
            }
        }
    }

    //Move towards the given attack point
    void MoveInDirection(Transform tempTrans)
    {

        transform.position += (tempTrans.position - transform.position).normalized * moveSpeed * Time.deltaTime;

        enemyAnimator.SetInteger("animState", 1);
    }

    //When our player hit the enemy
    public void HitEnemy()
    {
        healthPoint -= 1;
        
        if (healthPoint <= 0)
        {
            isDead = true;
            enemyAnimator.SetTrigger("death");
            enemySpawner.SendMessage("killEnemy", spawnID);
        }
        else
        {
            inFight = true;
            enemyAnimator.SetTrigger("gotHit");
        }
    }

    public void StopFight()
    {
        inFight = false;
    }

    //When our player kill the enemy
    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    // Applies the spawner's ID to the enemy.    It's cal from the script SpawnerEnemy.cs
    public void setName(int sID)
    {
        spawnID = sID;
    }


}
>>>>>>> dbc12d700f562b4449651262e82db110034c8b46
