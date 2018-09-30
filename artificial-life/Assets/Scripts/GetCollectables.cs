using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCollectables : MonoBehaviour {

    public int totalToken = 0;

    public AudioClip[] sounds;
    public AudioSource audioSrc;

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

        if (collision.gameObject.CompareTag("Guard"))
        {
            Destroy(collision.gameObject);
            playsound(0);
        }

    }

    private void playsound(int index)
    {
        audioSrc.clip = sounds[index];
        audioSrc.Play();
    }
}
