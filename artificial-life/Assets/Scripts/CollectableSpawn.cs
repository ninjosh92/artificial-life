using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawn : MonoBehaviour {
    public GameObject[] Collectables;
    
    private int counter = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Collectables[counter] == null)
        {
            counter++;
            if (counter > 3) { counter = 3; }
        }
        else {
            Collectables[counter].GetComponent<SpriteRenderer>().enabled = true;
            Collectables[counter].GetComponent<BoxCollider2D>().enabled = true;
        }



       // for (int i = 0; i < 4; i++)
       // {
         //   if (i == counter)
          //  {
                //Collectables[counter].GetComponent<SpriteRenderer>().enabled = true;
           // }
       // }
        

    }
}
