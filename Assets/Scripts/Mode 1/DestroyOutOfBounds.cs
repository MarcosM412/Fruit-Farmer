using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float xLimit = -30;
    private float yLimit = -10;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < xLimit || transform.position.y < yLimit)
            Destroy(gameObject);
    }
}
