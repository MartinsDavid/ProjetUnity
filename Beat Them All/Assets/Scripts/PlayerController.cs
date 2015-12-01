using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Vector2 moving = new Vector2();

    public Transform playerBody;
    //private Animator animator;

	// Use this for initialization
	void Start () {
        //animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        moving.x = moving.y = 0;

        if (Input.GetKey("right")) {
            moving.x = 1;
            playerBody.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            //animator.SetInteger("AnimState", 1);

        }
        else if (Input.GetKey("left")) {
            moving.x = -1;
            playerBody.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            //animator.SetInteger("AnimState", 1);
        }

        if (Input.GetKey("up")) {
            moving.y = 1;
            //animator.SetInteger("AnimState", 1);
        }
        else if (Input.GetKey("down")) {
            moving.y = -1;
            //animator.SetInteger("AnimState", 1);
        }
    }
}
