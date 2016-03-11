using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{

    //Player Variables
    private Transform playerBody;
    private Transform attackPoint3;
    private Transform attackPoint4;

    //Movement Controls
    public float moveSpeed;
    private Vector2 moveDirection;

    //Some attributes
    public int healthPoint;
    public int maxHealth;
    public bool isDead;
    public bool inFight;
    public bool rageMode;
    private bool onExeMode;

    //Boss Misc Controls
    public Transform enemyBody;
    public Transform enemyFeet;
    public SpriteRenderer enemySprite;
    public Animator enemyAnimator;

    //Cooldowns
    public float coolDownKick;
    private float kickRate;
    public float coolDownSphere;
    private float sphereRate;
    public float coolDownExe;
    private float exeRate;

    private bool CanKick
    {
        get{ return coolDownKick <= 0f; }
    }

    private bool CanShootSphere
    {
        get { return coolDownSphere <= 0f; }
    }

    private bool CanUseExe
    {
        get { return coolDownExe <= 0f; }
    }

    //AttackRayStart
    public Transform attackRayStart;
    private int damage;

    // Weapon 
    public Transform enemyWeapon;
    private WeaponScript weaponScript;

    // Spawner ID
    int spawnID;
    public Transform enemySpawner;

    // ----------------
    // END OF ATTRIBUTES DECLARATION
    // ----------------




    void Awake()
    {
        // Retrieve the weapon only once
        weaponScript = GetComponentInChildren<WeaponScript>();
    }

    // Use this for initialization
    void Start()
    {
        //Find the player
        playerBody = GameObject.Find("PlayerController").transform;

        //Find attackPoints 3 and 4
        attackPoint3 = GameObject.Find("AttackPoint3").transform;
        attackPoint4 = GameObject.Find("AttackPoint4").transform;
        
        //Find the Weapon
        enemyWeapon = GetComponentInChildren<Transform>();

        kickRate = coolDownKick;
        sphereRate = coolDownSphere;
        exeRate = coolDownExe;
    }

    // Update is called once per frame
    void Update()
    {
        //Set the enemy sprite order equal to our enemy's feet Y position
        enemySprite.sortingOrder = -(int)enemyFeet.position.y;

        if (transform.position.x < playerBody.position.x)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if (transform.position.x > playerBody.position.x)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }

        //Decrease cooldowns
        if (coolDownKick >= 0)
        {
            coolDownKick -= Time.deltaTime;
        }
        if (coolDownSphere >= 0)
        {
            coolDownSphere -= Time.deltaTime;
        }
        if (coolDownExe >= 0)
        {
            coolDownExe -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        // Choose a pattern to use if the boss isn't inFight or dead
        if (!isDead && !inFight)
        {
            if (!rageMode)
                PatternOne();
            else
                PatternTwo();
        }    
    }

    private void PatternOne()
    {
        if (!isDead && !inFight)
        {
            //Get the distances between our enemy and the attack points
            float attackDistance3 = Vector2.Distance(transform.position, attackPoint3.position);
            float attackDistance4 = Vector2.Distance(transform.position, attackPoint4.position);

            //Find the closest attack point, then move towards it or attack
            if (attackDistance3 < attackDistance4)
            {
                PatternOneDetails(attackDistance3, attackPoint3);
            }
            else
            {
                PatternOneDetails(attackDistance4,attackPoint4);
            }
        }
    }

    private void PatternOneDetails(float distance, Transform attackPoint)
    {
        if (CanKick)
        {
            enemyAnimator.SetTrigger("kick");
        }
        else if (CanShootSphere)
        {
            coolDownSphere += sphereRate;
            inFight = true;
            if (enemyWeapon.position.y < playerBody.position.y + 1f && enemyWeapon.position.y > playerBody.position.y - 1f)
            {
                
                if (weaponScript != null && weaponScript.CanAttack)
                {
                    enemyAnimator.SetTrigger("shootSphere");
                }
            }
        }
        else if (distance > 0.1f)
        {
            MoveInDirection(attackPoint);
        }
    }  

    private void PatternTwo()
    {
        if (!isDead && !inFight)
        {
            //Get the distances between our enemy and the attack points
            float attackDistance3 = Vector2.Distance(transform.position, attackPoint3.position);
            float attackDistance4 = Vector2.Distance(transform.position, attackPoint4.position);

            //Find the closest attack point, then move towards it or attack
            if (attackDistance3 < attackDistance4)
            {
                PatternTwoDetails(attackDistance3, attackPoint3);
            }
            else
            {
                PatternTwoDetails(attackDistance4, attackPoint4);
            }
        }
    }

    private void PatternTwoDetails(float distance, Transform attackPoint)
    {
        if(CanUseExe)
        {
            inFight = true;
            enemyAnimator.SetTrigger("AttackExe");
        }
        if (CanKick)
        {
            enemyAnimator.SetTrigger("kick");
            Attacking();
        }
        else if (CanShootSphere)
        {
            coolDownSphere += sphereRate;
            inFight = true;
            if (enemyWeapon.position.y < playerBody.position.y + 1f && enemyWeapon.position.y > playerBody.position.y - 1f)
            {
                if (weaponScript != null && weaponScript.CanAttack)
                {
                    enemyAnimator.SetTrigger("shootSphere");
                }
            }
        }
        else if (distance > 0.1f)
        {
            MoveInDirection(attackPoint);
        }
    }

    public void WeaponScriptAttack()
    {
        weaponScript.Attack(true);
    }

    // AttackExe Launch when the Boss_SpecialAttack animation start
    public void AttackExe()
    {
        coolDownExe += exeRate;
        onExeMode = true;
        transform.position += (playerBody.position - transform.position).normalized * moveSpeed * Time.deltaTime * 1.5f;
    }

    // This OnTriggerEnter2D method allow the AttackExe to deal damage to the player
    public void OnTriggerEnter2D(Collider2D target)
    {
        if(onExeMode)
            if(target.gameObject.tag == "Player")
                target.GetComponent<HealthBarScript>().Hit("AttackExe", 10);
        onExeMode = false;
    }

    //Move towards the given attack point
    private void MoveInDirection(Transform tempTrans)
    {
        transform.position += (tempTrans.position - transform.position).normalized * moveSpeed * Time.deltaTime;
        enemyAnimator.SetInteger("animState", 1);
    }

    //When our player hit the boss
    public void HitEnemy()
    {
        healthPoint -= 1;

        if (healthPoint <= 0)
        {
            isDead = true;
            enemyAnimator.SetTrigger("death");
        }
        else
        {
            inFight = true;
            enemyAnimator.SetTrigger("gotHit");
        }

        //Check the Boss's hp to change the pattern if the boss is "midLife"
        if (healthPoint == maxHealth/2)
            rageMode = true;
    }

    // This method is call at the end of all "fight" animation as gotHit or Kick animation and change the boolean value inFight to false
    public void StopFight()
    {
        inFight = false;
    }

    //When our player kill the enemy.  Call when the Dead animation is done
    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    //This is activatd via an event in the Boss_kick animation
    private void Attacking()
    {
        inFight = true;
        coolDownKick += kickRate;

        //Shot a ray out in the "right" direction.
        //As we are rotating our boss-body, we multiply Vector2.right by the rotation in order to get the correct "right" direction
        RaycastHit2D hit = Physics2D.Raycast(attackRayStart.position, enemyBody.rotation * Vector2.right, 2);
        
        //If our collider is not null, then...
        if (hit.collider != null)
        {
            //Get the difference between our Y position and the hit colliders Y position
            float yDifference = transform.position.y - hit.collider.transform.position.y;

            //If the difference isn't to far in either direction, then...
            if (yDifference < 0.85f && yDifference > -0.85f)
            {
                //Call the HealthBarScript script, and tell it that we hit the player ! 
                hit.collider.GetComponent<HealthBarScript>().Hit("Kick", 1);
            }
        }
    }
}
