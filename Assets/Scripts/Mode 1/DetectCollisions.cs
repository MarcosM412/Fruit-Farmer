using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectCollisions : MonoBehaviour
{ 
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // gameObject is fruit
        // other is bucket

        Destroy(gameObject);

        if (!gameManager.GameIsOver)
        {
            if (gameObject.CompareTag(other.tag))
            {
                gameManager.IncreaseCount();
            }
            else if (gameObject.CompareTag("Rotten"))
            {
                gameManager.GameOver();
            }
        }
    }
}
