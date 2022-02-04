using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    private static int Count = 0;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

        if (gameObject.tag == other.tag)
            Count++;
        else if (other.tag == "Rotten")
            Count -= 5;
        CounterText.text = "Fruit Collected: " + Count;
    }
}
