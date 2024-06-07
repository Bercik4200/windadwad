using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_down : MonoBehaviour
{
    // Speed at which the object will move down
    public float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        // Calculate the movement vector
        Vector3 movement = Vector3.down * (speed * Time.deltaTime);

        // Move the GameObject down
        transform.Translate(movement);
    }
}