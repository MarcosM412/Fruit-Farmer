using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    float horizontalInput;
    [SerializeField] float speed = 10;
    [SerializeField] GameObject redBox;
    [SerializeField] GameObject greenBox;
    [SerializeField] GameObject yellowBox;
    

    // Update is called once per frame
    void Update()
    {
        // Moves plaayer left and right with arrow keys
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime * speed);

        // Keeps player in bounds
        if (transform.position.z < -16.5 || transform.position.z > 16.4)
            transform.Translate(Vector3.forward * -horizontalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Alpha1) && !redBox.activeInHierarchy)
        {
            redBox.SetActive(true);
            greenBox.SetActive(false);
            yellowBox.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && !greenBox.activeInHierarchy)
        {
            redBox.SetActive(false);
            greenBox.SetActive(true);
            yellowBox.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && !yellowBox.activeInHierarchy)
        {
            redBox.SetActive(false);
            greenBox.SetActive(false);
            yellowBox.SetActive(true);
        }
    }
}
