using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public Vector2 speed = new Vector2(3, 3);
    private Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -8f, 8.1f), Mathf.Clamp(transform.position.y, -3.5f, -0.5f));

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        movement = new Vector2(speed.x * inputX, speed.y * inputY);
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}
