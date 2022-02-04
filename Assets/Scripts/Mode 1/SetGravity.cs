using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGravity : MonoBehaviour
{
    private float gravityMultiplier = 0.1f;
    private float increaseInterval = 10;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityMultiplier;
        InvokeRepeating("IncreaseGravity", increaseInterval, increaseInterval);
    }

    void IncreaseGravity()
    {
        gravityMultiplier += 0.1f;
    }
}
