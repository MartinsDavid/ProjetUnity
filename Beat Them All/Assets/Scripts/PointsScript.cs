﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointsScript : MonoBehaviour {

	private ScoreScript score;

	// Use this for initialization
	void Start ()
    {
		score = GameObject.FindGameObjectWithTag ("Player").GetComponent<ScoreScript> ();	
	}

    void Update()
    {

    }
	
	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			score.points += 1;
			Destroy(gameObject);

		}
	}

}
