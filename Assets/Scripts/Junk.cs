using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junk : MonoBehaviour
{
    [SerializeField] private float dmg = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHP>().TakeDamage(dmg);

            OnDie();
        }
    }

    public void OnDie()
    {


        Destroy(gameObject);
    }
}
