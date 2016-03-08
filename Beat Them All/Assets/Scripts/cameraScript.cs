using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour
{

    private GameObject toFollow;

    void Start()
    {
        toFollow = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = toFollow.transform.position.x;
        transform.position = pos;
    }
}