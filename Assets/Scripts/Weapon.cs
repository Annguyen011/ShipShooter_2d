using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float attackRate = .1f;
    [SerializeField] private AudioClip shootAudio;

    private int attackLevel = 1;
    private int maxattackLevel = 3;
    public int AttackLevel
    {
        set => attackLevel = Mathf.Clamp(value, 1, maxattackLevel);
        get => attackLevel;
    }

    private AudioSource audioSource;

    public int BoomCount { get; internal set; }
    [SerializeField] GameObject boomPrefab;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        BoomCount = 3;
    }

    public void StartFiring()
    {
        StartCoroutine("TryAttack");
    }

    public void StopFiring()
    {
        StopCoroutine("TryAttack");
    }

    public void StartBoom()
    {
        if(BoomCount > 0)
        {
            BoomCount--;
            Instantiate(boomPrefab, transform.position, Quaternion.identity);
        }
    }

    IEnumerator TryAttack()
    {
        while (true)
        {
            AttackByLevel();

            audioSource.PlayOneShot(shootAudio);

            yield return new WaitForSeconds(attackRate);
        }
    }

    private void AttackByLevel()
    {
        GameObject cloneProjectile = null;

        switch (attackLevel)
        {
            case 1:
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);

                break;

            case 2:
                Instantiate(projectilePrefab, transform.position + Vector3.left * .2f, Quaternion.identity);
                Instantiate(projectilePrefab, transform.position + Vector3.right * .2f, Quaternion.identity);

                break;

            case 3:
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);

                cloneProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(-.2f, 1, 0));

                cloneProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(.2f, 1, 0));
                break;
        }
    }
}
