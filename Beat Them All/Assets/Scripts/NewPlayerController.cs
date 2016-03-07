using UnityEngine;
using System.Collections;

public class NewPlayerController : MonoBehaviour {


	public AudioClip punchSound1;
	public AudioClip punchSound2;
	public AudioClip punchSound3;
	public AudioClip jumpSound;

    //Player Controls
    public Transform playerBody;
    public Transform playerFeet;
    public SpriteRenderer playerSprite;
    public Transform attackRayStart;

    //Animation Controls
    public Animator myAnimator;

    //Movement Controls
    public float moveSpeed;
    private Vector2 playerAxisMove;
    public bool isJumping;
    public bool isAttacking;
    public bool isDead;


	


    // Update is called once per frame
    void Update()
    {

        playerSprite.sortingOrder = -(int)playerFeet.position.y;

        //-----------------------
        //Movement Section
        //-----------------------

        //As long as we are not attacking and we are not dead, we can move.
        if (!isAttacking && !isDead)
        {

            //This will clamp how far up/down/left/right we can go in LOCAL space
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -25, 25), Mathf.Clamp(transform.position.y, -10, -3));

            //Grab our movement axis
            playerAxisMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            //Move our player around
            transform.Translate(playerAxisMove * moveSpeed * Time.deltaTime);

            //Checks to see which way our player is going and flips their facing direction
            if (playerAxisMove.x > 0)
            {
                playerBody.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }
            else if (playerAxisMove.x < 0)
            {
                playerBody.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }

            //Checks to see if our player is moving
            //If they are, activate the "walking" variable
            if (Mathf.Abs(playerAxisMove.x) > 0 || Mathf.Abs(playerAxisMove.y) > 0)
            {
                myAnimator.SetBool("isWalking", true);
            }
            else
            {
                myAnimator.SetBool("isWalking", false);
            }
        }

        //-----------------------
        //Button Detect Section
        //-----------------------

        //Did we jump?
        if (Input.GetButtonDown("Jump") && !isJumping && !isAttacking)
        {
            isJumping = true;
            myAnimator.SetTrigger("jumped");
			AudioSource.PlayClipAtPoint (jumpSound, transform.position);
        }

        //Did we attack?
        if (Input.GetButtonDown("Fire1") && !isJumping && !isAttacking)
        {
            isAttacking = true;
            myAnimator.SetTrigger("attacked");
        }

    }

    //This is activated via an event in the Player_Jump animation
    void JumpCompleted()
    {
        isJumping = false;
    }

    //This is activated via an event in the Player_Attack animation
    void AttackCompleted()
    {
        isAttacking = false; ;
    }

    //This is activatd via an event in the Player_Attack animation
    void Attacking()
    {
		switch (Random.Range(0,3) % 3) {
		case 0:
			AudioSource.PlayClipAtPoint (punchSound1, transform.position);
			break;
		case 1 :
			AudioSource.PlayClipAtPoint (punchSound2, transform.position);
			break;
		case 2 :
			AudioSource.PlayClipAtPoint (punchSound3, transform.position);
			break;
		}
	

        //Shot a ray out in the "right" direction.
        //As we are rotating our player-body, we multiply Vector2.right by the rotation in order to get the correct "right" direction
        RaycastHit2D hit = Physics2D.Raycast(attackRayStart.position, playerBody.rotation * Vector2.right, 2);

        //If our collider is not null, then...
        if (hit.collider != null)
        {

            //Get the difference between our Y position and the hit colliders Y position
            float yDifference = transform.position.y - hit.collider.transform.position.y;

            //If the difference isn't to far in either direction, then...
            if (yDifference < 0.85f && yDifference > -0.85f)
            {

                //Call the enemy script, and tell it that we hit them !
                hit.collider.GetComponent<EnemyController>().HitEnemy();
            }
        }
    }
}
