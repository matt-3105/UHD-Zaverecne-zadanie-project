using System;
using System.Collections;
using System.Collections.Generic;using Newtonsoft.Json.Serialization;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{

    private bool levelCompleted = false;
    [SerializeField] private AudioSource winSound;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player" && !levelCompleted && GameObject.FindGameObjectWithTag("Coin") == null){
            winSound.Play();
            Invoke("CompleteLevel",1f);
            levelCompleted = true;
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
