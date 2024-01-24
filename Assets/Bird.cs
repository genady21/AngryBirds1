using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.isKinematic = true;
    }

    public void Launch(Vector3 direction)
    {
        rigidbody2D.isKinematic = false;
        rigidbody2D.AddForce(direction,ForceMode2D.Impulse);
    }
}
