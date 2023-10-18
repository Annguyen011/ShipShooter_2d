using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public float MaxHealth => maxHealth;
    public float CurHealth { get => curHealth; set { curHealth = value; } }

    [SerializeField] private float maxHealth;
    private float curHealth;

    private Player player;
    private SpriteRenderer sprite;

    private void Awake()
    {
        player = GetComponent<Player>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        curHealth = maxHealth;
    }

    public void TakeDamage(float dmg)
    {
        curHealth -= dmg;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        if (curHealth <= 0)
        {
            player.OnDie();
        }
    }

    private IEnumerator HitColorAnimation()
    {
        sprite.color = Color.red;

        yield return new WaitForSeconds(.1f);

        sprite.color = Color.white;
    }

}
