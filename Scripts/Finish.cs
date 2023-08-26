using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    private AudioSource FinishLevel;
    private bool levelCompleted = false;

    private void Start()
    {
      FinishLevel = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !levelCompleted)
        {
            FinishLevel.Play();
            levelCompleted = true;
            Invoke(nameof(CompleteLevel), 2f);
        }
        if (collision.gameObject.name == "Virtual Guy" && !levelCompleted)
        {
            FinishLevel.Play();
            levelCompleted = true;
            Invoke(nameof(CompleteLevel), 2f);
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
