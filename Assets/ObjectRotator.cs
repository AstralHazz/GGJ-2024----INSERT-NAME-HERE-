using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    float rotatespeed = .04f;
    void Update()
    {
        transform.Rotate(0, rotatespeed, 0 * Time.deltaTime); //rotates 1 degrees per second around y axis of movement
    }
}
