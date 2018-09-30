using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenResetTimer : MonoBehaviour
{
    public float duration = 15f;
    private float timer = 0f;
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= duration)
        {
            SceneManager.LoadScene("MenuScene");
        }
	}
}
