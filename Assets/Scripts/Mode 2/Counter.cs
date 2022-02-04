using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    private static int count = 0;
    public int Count
    {
        get
        {
            return count;
        }
    }

    GameManager2 gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager2>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

        if (!gameManager.GameIsOver)
        {
            if (gameObject.CompareTag(other.tag))
                count++;
            else if (other.CompareTag("Rotten"))
                count -= 5;
            CounterText.text = "Fruit Collected: " + Count;
        }
    }
}
