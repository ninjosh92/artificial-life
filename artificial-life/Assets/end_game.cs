﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end_game : MonoBehaviour
{

    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Game_Over_Screen");
        }
    }
}
