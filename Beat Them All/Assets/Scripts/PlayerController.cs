using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    public Vector2 moving = new Vector2();
    bool keyWasHandled = false;
    bool ManettesHandled = false;
    public Transform playerBody;
    private Animator animator;
    public float gJump = -2.5f;

    static float deplacementHorizontal = 0;
    static float deplacementVertical = 0;
    delegate void DeplacementDelegate(Vector2 moving, bool keyWasHandled, Transform playerBody, Animator animator);
    DeplacementDelegate handler = null;



    private bool attacking = false;
    private float attackTimer = 0;
    private float attackCd = 0.8f;
    public Collider2D attackTrigger;
    private Animator anim;


    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }


    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        string[] manettes = Input.GetJoystickNames();

        if (manettes[0].ToLower().Contains("playstation"))
        {
            // Instantiate the delegate.
            handler = deplacementDelegateManettePlaystation(moving, keyWasHandled, playerBody, animator);
        }
        else if (manettes[0].ToLower().Contains("xbox"))
        {
            // Instantiate the delegate.
            handler = deplacementDelegateManetteXbox(moving, keyWasHandled, playerBody, animator);
        }
        else
        {
            // Instantiate the delegate.
            handler = deplacementsDelegateClavier(moving, keyWasHandled, playerBody, animator);
        }
    }


    private DeplacementDelegate deplacementsDelegateClavier(Vector2 moving, bool keyWasHandled, Transform playerBody, Animator animator)
    {
        //deplacementsClavier(this.moving, this.keyWasHandled, this.playerBody, this.animator);
        moving.x = moving.y = 0;

        if (Input.GetKeyDown("right") || Input.GetKeyDown(KeyCode.D))
        {
            moving.x = 1;
            playerBody.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            animator.SetInteger("AnimState", 1);
            //keyWasHandled = true;
        }
        else if (Input.GetKeyDown("left") || Input.GetKeyDown(KeyCode.Q))
        {
            moving.x = -1;
            playerBody.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            animator.SetInteger("AnimState", 1);
            // keyWasHandled = true;
        }

        if (Input.GetKeyDown("up") || Input.GetKeyDown(KeyCode.Z))
        {
            moving.y = 1;
            animator.SetInteger("AnimState", 1);
            //keyWasHandled = true;
        }

        else if (Input.GetKeyDown("down") || Input.GetKeyDown(KeyCode.S))
        {
            moving.y = -1;
            animator.SetInteger("AnimState", 1);
            //keyWasHandled = true;
        }

        if (Input.GetKeyUp("right") || Input.GetKeyUp("left") || Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.D))
        {
            animator.SetInteger("AnimState", 0);
        }

        if (Input.GetKeyUp("up") || Input.GetKeyUp("down") || Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.S))
        {
            animator.SetInteger("AnimState", 0);
        }

        if (Input.GetKeyDown("space") && keyWasHandled == false)
        {
            animator.SetInteger("AnimState", 2);
            // transform.Translate(0, 0.2f, 0);
            keyWasHandled = true;

        }
        if (Input.GetKeyUp("space"))
        {
            animator.SetInteger("AnimState", 0);
            keyWasHandled = false;
        }

        //Attaque du joueur
        if (Input.GetKeyDown("f") && !attacking)
        {
            attacking = true;
            attackTimer = attackCd;

            attackTrigger.enabled = true;
        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
            anim.SetBool("Attacking", attacking);
        }


        return handler;
    }

    private DeplacementDelegate deplacementDelegateManettePlaystation(Vector2 moving, bool keyWasHandled, Transform playerBody, Animator animator)
    {
        //deplacementManettePlaystation(this.moving, this.keyWasHandled, this.playerBody, this.animator);
        moving.x = moving.y = 0;

        deplacementHorizontal = Input.GetAxis("Horizontal");
        if (deplacementHorizontal >= 0)
        {
            moving.x = 1;
            playerBody.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            animator.SetInteger("AnimState", 1);
            //keyWasHandled = true;
        }
        else if (deplacementHorizontal < 0)
        {
            moving.x = -1;
            playerBody.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            animator.SetInteger("AnimState", 1);
            // keyWasHandled = true;
        }

        deplacementVertical = Input.GetAxis("Vertical");
        if (deplacementVertical > 0)
        {
            moving.y = 1;
            animator.SetInteger("AnimState", 1);
            //keyWasHandled = true;
        }

        else if (deplacementVertical <= 0)
        {
            moving.y = -1;
            animator.SetInteger("AnimState", 1);
            //keyWasHandled = true;
        }

        if (deplacementHorizontal == 0)
        {
            animator.SetInteger("AnimState", 0);
        }

        if (deplacementVertical == 0)
        {
            animator.SetInteger("AnimState", 0);
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton2) && keyWasHandled == false)
        {
            animator.SetInteger("AnimState", 2);
            // transform.Translate(0, 0.2f, 0);
            keyWasHandled = true;

        }
        if (Input.GetKeyUp(KeyCode.JoystickButton2))
        {
            animator.SetInteger("AnimState", 0);
            keyWasHandled = false;
        }
        return handler;
    }

    private DeplacementDelegate deplacementDelegateManetteXbox(Vector2 moving, bool keyWasHandled, Transform playerBody, Animator animator)
    {
        //deplacementManetteXbox(this.moving, this.keyWasHandled, this.playerBody, this.animator);
        moving.x = moving.y = 0;

        deplacementHorizontal = Input.GetAxis("Horizontal");
        if (deplacementHorizontal >= 0)
        {
            moving.x = 1;
            playerBody.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            animator.SetInteger("AnimState", 1);
            //keyWasHandled = true;
        }
        else if (deplacementHorizontal < 0)
        {
            moving.x = -1;
            playerBody.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            animator.SetInteger("AnimState", 1);
            // keyWasHandled = true;
        }

        deplacementVertical = Input.GetAxis("Vertical");
        if (deplacementVertical > 0)
        {
            moving.y = 1;
            animator.SetInteger("AnimState", 1);
            //keyWasHandled = true;
        }

        else if (deplacementVertical <= 0)
        {
            moving.y = -1;
            animator.SetInteger("AnimState", 1);
            //keyWasHandled = true;
        }

        if (deplacementHorizontal == 0)
        {
            animator.SetInteger("AnimState", 0);
        }

        if (deplacementVertical == 0)
        {
            animator.SetInteger("AnimState", 0);
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton0) && keyWasHandled == false)
        {
            animator.SetInteger("AnimState", 2);
            // transform.Translate(0, 0.2f, 0);
            keyWasHandled = true;

        }
        if (Input.GetKeyUp(KeyCode.JoystickButton0))
        {
            animator.SetInteger("AnimState", 0);
            keyWasHandled = false;
        }
        return handler;
    }


    //public void deplacementsClavier(Vector2 moving, bool keyWasHandled, Transform playerBody, Animator animator)
    //{
    //    moving.x = moving.y = 0;

    //    if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
    //    {
    //        moving.x = 1;
    //        playerBody.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    //        animator.SetInteger("AnimState", 1);
    //        //keyWasHandled = true;
    //    }
    //    else if (Input.GetKey("left") || Input.GetKey(KeyCode.Q))
    //    {
    //        moving.x = -1;
    //        playerBody.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    //        animator.SetInteger("AnimState", 1);
    //        // keyWasHandled = true;
    //    }

    //    if (Input.GetKey("up") || Input.GetKey(KeyCode.Z))
    //    {
    //        moving.y = 1;
    //        animator.SetInteger("AnimState", 1);
    //        //keyWasHandled = true;
    //    }

    //    else if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
    //    {
    //        moving.y = -1;
    //        animator.SetInteger("AnimState", 1);
    //        //keyWasHandled = true;
    //    }

    //    if (Input.GetKeyUp("right") || Input.GetKeyUp("left") || Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.D))
    //    {
    //        animator.SetInteger("AnimState", 0);
    //    }

    //    if (Input.GetKeyUp("up") || Input.GetKeyUp("down") || Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.S))
    //    {
    //        animator.SetInteger("AnimState", 0);
    //    }

    //    if (Input.GetKey("space") && keyWasHandled == false)
    //    {
    //        animator.SetInteger("AnimState", 2);
    //        // transform.Translate(0, 0.2f, 0);
    //        keyWasHandled = true;

    //    }
    //    if (Input.GetKeyUp("space"))
    //    {
    //        animator.SetInteger("AnimState", 0);
    //        keyWasHandled = false;
    //    }
    //}

    //public void deplacementManettePlaystation(Vector2 moving, bool keyWasHandled, Transform playerBody, Animator animator)
    //{
    //    moving.x = moving.y = 0;

    //    deplacementHorizontal = Input.GetAxis("Horizontal");
    //    if (deplacementHorizontal >= 0)
    //    {
    //        moving.x = 1;
    //        playerBody.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    //        animator.SetInteger("AnimState", 1);
    //        //keyWasHandled = true;
    //    }
    //    else if (deplacementHorizontal < 0)
    //    {
    //        moving.x = -1;
    //        playerBody.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    //        animator.SetInteger("AnimState", 1);
    //        // keyWasHandled = true;
    //    }

    //    deplacementVertical = Input.GetAxis("Vertical");
    //    if (deplacementVertical > 0)
    //    {
    //        moving.y = 1;
    //        animator.SetInteger("AnimState", 1);
    //        //keyWasHandled = true;
    //    }

    //    else if (deplacementVertical <= 0)
    //    {
    //        moving.y = -1;
    //        animator.SetInteger("AnimState", 1);
    //        //keyWasHandled = true;
    //    }

    //    if (deplacementHorizontal == 0)
    //    {
    //        animator.SetInteger("AnimState", 0);
    //    }

    //    if (deplacementVertical == 0)
    //    {
    //        animator.SetInteger("AnimState", 0);
    //    }

    //    if (Input.GetKey(KeyCode.JoystickButton2) && keyWasHandled == false)
    //    {
    //        animator.SetInteger("AnimState", 2);
    //        // transform.Translate(0, 0.2f, 0);
    //        keyWasHandled = true;

    //    }
    //    if (Input.GetKeyUp(KeyCode.JoystickButton2))
    //    {
    //        animator.SetInteger("AnimState", 0);
    //        keyWasHandled = false;
    //    }
    //}

    //public void deplacementManetteXbox(Vector2 moving, bool keyWasHandled, Transform playerBody, Animator animator)
    //{
    //    moving.x = moving.y = 0;

    //    deplacementHorizontal = Input.GetAxis("Horizontal");
    //    if (deplacementHorizontal >= 0)
    //    {
    //        moving.x = 1;
    //        playerBody.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    //        animator.SetInteger("AnimState", 1);
    //        //keyWasHandled = true;
    //    }
    //    else if (deplacementHorizontal < 0)
    //    {
    //        moving.x = -1;
    //        playerBody.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    //        animator.SetInteger("AnimState", 1);
    //        // keyWasHandled = true;
    //    }

    //    deplacementVertical = Input.GetAxis("Vertical");
    //    if (deplacementVertical > 0)
    //    {
    //        moving.y = 1;
    //        animator.SetInteger("AnimState", 1);
    //        //keyWasHandled = true;
    //    }

    //    else if (deplacementVertical <= 0)
    //    {
    //        moving.y = -1;
    //        animator.SetInteger("AnimState", 1);
    //        //keyWasHandled = true;
    //    }

    //    if (deplacementHorizontal == 0)
    //    {
    //        animator.SetInteger("AnimState", 0);
    //    }

    //    if (deplacementVertical == 0)
    //    {
    //        animator.SetInteger("AnimState", 0);
    //    }

    //    if (Input.GetKey(KeyCode.JoystickButton0) && keyWasHandled == false)
    //    {
    //        animator.SetInteger("AnimState", 2);
    //        // transform.Translate(0, 0.2f, 0);
    //        keyWasHandled = true;

    //    }
    //    if (Input.GetKeyUp(KeyCode.JoystickButton0))
    //    {
    //        animator.SetInteger("AnimState", 0);
    //        keyWasHandled = false;
    //    }
    //}


    // Update is called once per frame
    void Update()
    {
        // Call the delegate.
        //handler(moving, keyWasHandled, playerBody, animator);

        if (Input.GetJoystickNames().ToString().ToLower().Contains("playstation"))
        {
            // Instantiate the delegate.
            handler = deplacementDelegateManettePlaystation(moving, keyWasHandled, playerBody, animator);
        }
        else if (Input.GetJoystickNames().ToString().ToLower().Contains("xbox"))
        {
            // Instantiate the delegate.
            handler = deplacementDelegateManetteXbox(moving, keyWasHandled, playerBody, animator);
        }
        else
        {
            // Instantiate the delegate.
            handler = deplacementsDelegateClavier(moving, keyWasHandled, playerBody, animator);
        }
    }



    //XBOX CONTROLLER

    //Buttons (Key or Mouse Button) 
    //Axis (Joystick Axis) 

    //joystick button 0 = A  X axis = Left analog X  
    //joystick button 1 = B  Y axis = Left analog Y  
    //joystick button 2 = X  3rd axis = LT/RT  
    //joystick button 3 = Y  4th axis = Right analog X  
    //joystick button 4 = L  5th axis = Right analog Y  
    //joystick button 5 = R  6th axis = Dpad X  
    //joystick button 6 = Back  7th axis = Dpad Y  
    //joystick button 7 = Home  
    //joystick button 8 = Left analog press  
    //joystick button 9 = Right analog press  



    //PS3 CONTROLLER

    //Buttons (Key or Mouse Button) 
    //Axis (Joystick Axis) 

    //joystick button 0 = Square  X Axis = LeftAnalogX  
    //joystick button 1 = X  Y Axis = LeftAnalogY  
    //joystick button 2 = Circle  3rd Axis = RightAnalogX  
    //joystick button 3 = Triangle  4th Axis = RightAnalogY  
    //joystick button 4 = L1  5th Axis = Dpad X  
    //joystick button 5 = R1  6th Axis = Dpad Y  
    //joystick button 6 = L2  
    //joystick button 7 = R2  
    //joystick button 8 = Select  
    //joystick button 9 = Right analog press  
    //joystick button 10 = (to be updated)  
    //joystick button 11 = (to be updated)  
    //joystick button 12 = Home 

}