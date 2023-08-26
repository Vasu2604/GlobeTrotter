using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IteamCollector : MonoBehaviour
{
    private int Apples = 0;
    [SerializeField] private Text AppleText;
    [SerializeField] private AudioSource ItemCollectionSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            ItemCollectionSound.Play();
            Destroy(collision.gameObject);
            Apples++;
            AppleText.text = "Iteams:" + Apples;

        }
    }
}
