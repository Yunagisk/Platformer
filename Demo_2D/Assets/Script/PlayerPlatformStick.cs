using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private List<Rigidbody2D> riders = new List<Rigidbody2D>();
    private Vector3 lastPos;
    void Start()
    {
        lastPos = transform.position;
    }
    void FixedUpdate()
    {
        Vector3 deltaPos = transform.position - lastPos;
        foreach (Rigidbody2D rider in riders)
        {
            if (rider != null)
            {
                rider.position += (Vector2)deltaPos;
            }
        }
        lastPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rb = other.attachedRigidbody;
        if (rb != null && !riders.Contains(rb))
        {
            riders.Add(rb);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Rigidbody2D rb = other.attachedRigidbody;
        if (rb != null && riders.Contains(rb))
        {
            riders.Remove(rb);
        }
    }
}
