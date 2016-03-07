using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {
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

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
