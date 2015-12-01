using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

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
	public SpriteRenderer enemySprite;
	public Animator enemyAnimator;

	void Start(){
		//Find the player
		playerBody = GameObject.Find("Player").transform;
		//Find attackPoints 1 and 2
		attackPoint1 = GameObject.Find("AttackPoint1").transform;
		attackPoint2 = GameObject.Find("AttackPoint2").transform;
	}

	void Update(){

		//Set the enemy sprite order equal to our enemy's feet Y position
		enemySprite.sortingOrder = -(int)enemyFeet.position.y;

	}

    
	void FixedUpdate(){
		//Get the distances between our enemy and the attack points
		float attackDistance1 = Vector2.Distance(transform.position, attackPoint1.position);
		float attackDistance2 = Vector2.Distance(transform.position, attackPoint2.position);

		//Find the closest attack point, then move towards it
		if (attackDistance1 < attackDistance2){
			if (attackDistance1 > 0.1f){
				MoveInDirection(attackPoint1);
			}
		}
		else{
			if (attackDistance2 > 0.1f){
				MoveInDirection(attackPoint2);
			}
		}

	}

	//Move towards the given attack point
	void MoveInDirection(Transform tempTrans){

		if (transform.position.x < playerBody.position.x){
			enemyBody.rotation = Quaternion.Euler(new Vector3(0,0,0));
		}
		else if(transform.position.x > playerBody.position.x){
			enemyBody.rotation = Quaternion.Euler(new Vector3(0,0,0));
		}

		//Subtracting the attack point position by ours will give use a general direction
		Vector2 tempDir = tempTrans.position - transform.position;
		//Normalizing the general direction will given us the correct direction
		tempDir = tempDir.normalized;
		//Move towards the attack point
		transform.Translate (tempDir * moveSpeed * Time.deltaTime);
	}

	//Hit the enemy!
	public void HitEnemy(){

		enemyAnimator.SetTrigger("gotHit");
	}
}
