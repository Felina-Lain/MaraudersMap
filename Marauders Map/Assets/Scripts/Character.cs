﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rank
{

	Ghost = -1,
	Teacher = 0,
	StudentGryffindor = 1,
	StudentSlytherin = 2,
	StudentRavenclaw = 3,
	StudentHufflepuff = 4

}

public class Character : MonoBehaviour {
	
	public Rank rank_type;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void WalkingAround(){


	}
}
