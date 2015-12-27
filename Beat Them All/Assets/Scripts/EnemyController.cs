using UnityEngine;
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

    //Misc Controls
    public Transform enemyBody;
    public Transform enemyFeet;
    public Transform enemyWeapon;
    public SpriteRenderer enemySprite;
    public Animator enemyAnimator;

    private WeaponScript weapon;

    void Awake()
    {
        // Retrieve the weapon only once
        weapon = GetComponentInChildren<WeaponScript>();
    }

    void Start()
    {
        //Find the player
        playerBody = GameObject.Find("Player").transform;
        //Find attackPoints 1 and 2
        attackPoint1 = GameObject.Find("AttackPoint1").transform;
        attackPoint2 = GameObject.Find("AttackPoint2").transform;

    }

    void Update()
    {
        //Set the enemy sprite order equal to our enemy's feet Y position
        enemySprite.sortingOrder = -(int)enemyFeet.position.y;

        if (transform.position.x < playerBody.position.x)
        {
            enemyBody.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else if (transform.position.x > playerBody.position.x)
        {
            enemyBody.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

            // Auto-fire
            enemyWeapon = GetComponentInChildren<Transform>();

        if (enemyWeapon.position.y < playerBody.position.y + 0.5f && enemyWeapon.position.y > playerBody.position.y - 0.5f)
        {
            if (weapon != null && weapon.CanAttack)
            {
                weapon.Attack(true);
            }
        }

    }

    void FixedUpdate()
    {
        //Get the distances between our enemy and the attack points
        float attackDistance1 = Vector2.Distance(transform.position, attackPoint1.position);
        float attackDistance2 = Vector2.Distance(transform.position, attackPoint2.position);

        //Find the closest attack point, then move towards it
        if (attackDistance1 < attackDistance2)
        {
            if (attackDistance1 > 0.3f)
            {
                MoveInDirection(attackPoint1);
            }
            else
            {
                enemyAnimator.SetInteger("AnimState", 0);
            }
        }
        else if (attackDistance2 > 0.3f)
        {
            MoveInDirection(attackPoint2);
        }

        else
        {
            enemyAnimator.SetInteger("AnimState", 0);
        }
    }

    //Move towards the given attack point
    private void MoveInDirection(Transform tempTrans)
    {
        enemyBody.position += (tempTrans.position - enemyBody.position).normalized * moveSpeed * Time.deltaTime;

        enemyAnimator.SetInteger("AnimState", 1);
    }

    //Hit the enemy!
    public void HitEnemy()
    {
        enemyAnimator.SetTrigger("gotHit");
    }

}