using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private int hp;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Barier")) ;
        {
            hp--;
            if (hp <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
