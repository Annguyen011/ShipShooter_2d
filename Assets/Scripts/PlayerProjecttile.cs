using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjecttile : MonoBehaviour
{
    [SerializeField] float dmg = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHP>().TakeDamage(dmg);

            Destroy(gameObject);
        }
        if (collision.CompareTag("Boss"))
        {
            collision.GetComponent<BossHP>().TakeDamage(dmg);

            Destroy(gameObject);
        }
    }
}
