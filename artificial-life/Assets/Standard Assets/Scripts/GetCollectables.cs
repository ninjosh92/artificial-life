using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCollectables : MonoBehaviour {

    public int totalToken = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    { //

        if (collision.gameObject.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
            totalToken++;
        }
        
    }
}
