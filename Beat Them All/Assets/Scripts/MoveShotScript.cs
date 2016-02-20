using UnityEngine;
using System.Collections;

public class MoveShotScript : MonoBehaviour
{

    // 1 - Designer variables

    // Object speed
    private Vector2 speed = new Vector2(8,8);

    // Moving direction
    public Vector2 direction = new Vector2(-1, 0);

    private Vector2 movement;

    void Update()
    {
        // Movement
        movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
    }

    void FixedUpdate()
    {
        // Apply movement to the rigidbody
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}
