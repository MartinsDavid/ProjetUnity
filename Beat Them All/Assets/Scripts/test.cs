using UnityEngine;
using System.Collections;

public class test : MonoBehaviour
{
    public Transform target;
    private GameObject enemy;
    private GameObject player;
    private float range;
    public float speed;


    // Use this for initialization
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        range = Vector2.Distance(enemy.transform.position, player.transform.position);
        if (range <= 15f)
        {
            Vector2 velocity = new Vector2((transform.position.x - player.transform.position.x) * speed, (transform.position.y - player.transform.position.y) * speed);
            GetComponent<Rigidbody2D>().velocity = -velocity;
        }
    }
}