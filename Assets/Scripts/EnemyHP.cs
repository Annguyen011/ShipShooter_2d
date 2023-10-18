using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public float MaxHealth => maxHealth;
    public float CurHealth => curHealth;

    [SerializeField] private float maxHealth = 4f;
    private float curHealth;
    private Enemy enemy;
    private SpriteRenderer sprite;

    protected void Awake()
    {
        curHealth = maxHealth;
        enemy = GetComponent<Enemy>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float dmg)
    {
        curHealth -= dmg;

        StartCoroutine("HitColorAnimation");

        if(curHealth < 0)
        {
            enemy.OnDie();
        }


    }

    private IEnumerator HitColorAnimation()
    {
        sprite.color = Color.red;

        yield return new WaitForSeconds(.1f);

        sprite.color = Color.white;
    }

}
