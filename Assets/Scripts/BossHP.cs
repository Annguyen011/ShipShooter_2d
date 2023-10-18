using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    public float MaxHealth => maxHealth;
    public float CurHealth => curHealth;

    [SerializeField] private float maxHealth = 4f;
    private float curHealth;
    private Boss boss;
    private SpriteRenderer sprite;

    protected void Awake()
    {
        curHealth = maxHealth;
        boss = GetComponent<Boss>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float dmg)
    {
        curHealth -= dmg;

        StartCoroutine("HitColorAnimation");

        if (curHealth <= 0)
        {
            boss.OnDie();
        }


    }

    private IEnumerator HitColorAnimation()
    {
        sprite.color = Color.red;

        yield return new WaitForSeconds(.1f);

        sprite.color = Color.white;
    }
}
