﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	public float lifetime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// 1st way
		/*lifetime -= Time.deltaTime;
		if(lifetime < 0) {
			Destroy(gameObject);
		}*/

		// 2nd way
		Destroy(gameObject, lifetime);
	}
}