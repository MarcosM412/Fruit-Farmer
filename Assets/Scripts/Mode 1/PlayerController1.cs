using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public GameObject redBucket;
    public GameObject greenBucket;
    public GameObject yellowBucket;

    private float timer = 0;
    private float waitTime = 0.25f;

    private Vector3 offset = new Vector3(0, -0.5f, 0); // bucket position offset from player

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Spawn buckets based on arrow keys and timer
        Timer();
        if(!gameManager.GameIsOver)
            SpawnBuckets();
    }

    void Timer()
    {
        if (timer < waitTime)
            timer += Time.deltaTime;
    }

    void SpawnBuckets()
    {
        // Spawns red with left arrow
        if (Input.GetKeyDown(KeyCode.LeftArrow) && timer >= waitTime)
        {
            Instantiate(redBucket, transform.position + offset, redBucket.transform.rotation);
            timer = 0;
        }
        // Spawns green with up arrow
        else if (Input.GetKeyDown(KeyCode.UpArrow) && timer >= waitTime)
        {
            Instantiate(greenBucket, transform.position + offset, greenBucket.transform.rotation);
            timer = 0;
        }
        // Spawns yellow with right arrow
        else if (Input.GetKeyDown(KeyCode.RightArrow) && timer >= waitTime)
        {
            Instantiate(yellowBucket, transform.position + offset, yellowBucket.transform.rotation);
            timer = 0;
        }
    }
}
