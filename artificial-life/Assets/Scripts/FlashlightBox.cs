﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    { //

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
           
        }


    }
}
