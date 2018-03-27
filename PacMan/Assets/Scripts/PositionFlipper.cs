using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFlipper : MonoBehaviour
{
    
    public Transform newPos;
    void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 position = other.attachedRigidbody.position;
        position[0] = -(other.attachedRigidbody.position.x);
        if (other.CompareTag("Player"))
        {
            other.attachedRigidbody.position = position;
        }
    }
}
