using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform explosition;
    [SerializeField] private float dmg = 1;
    [SerializeField] private int scorePoint = 100;
    [SerializeField] private GameObject[] itemPrefabs;
    private Player player;

    private void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
    }

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
        Instantiate(explosition, transform.position, Quaternion.identity);

        SpawnItem();
        player.Score += scorePoint;

        Destroy(gameObject);
    }

    private void SpawnItem()
    {
        int rand = UnityEngine.Random.Range(0, 100);

        if (rand <= 10)
        {
            Instantiate(itemPrefabs[0], transform.position, Quaternion.identity);
        }
        else if (rand <= 20)
        {
            Instantiate(itemPrefabs[1], transform.position, Quaternion.identity);
        }
        else if (rand <= 30)
        {
            Instantiate(itemPrefabs[2], transform.position, Quaternion.identity);
        }
    }
}
