using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoom : MonoBehaviour
{
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private AudioClip boomAudio;
    private float boomDelay = .5f;

    private Animator animator;
    private AudioSource audioSource;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        StartCoroutine("MovetoCenter");
    }

    IEnumerator MovetoCenter()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = Vector3.zero;
        float curTime = 0;
        float perTime = 0;

        while (perTime < 1)
        {
            curTime += Time.deltaTime;
            perTime = curTime / boomDelay;

            transform.position = Vector3.Lerp(startPos, endPos, curve.Evaluate(perTime));

            yield return null;
        }

        animator.SetTrigger("onBoom");

        audioSource.PlayOneShot(boomAudio);
    }

    public void OnBoom()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] junks = GameObject.FindGameObjectsWithTag("Meteorite");

        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<Enemy>().OnDie();
        }

        foreach (GameObject item in junks)
        {
            item.GetComponent<Junk>().OnDie();
        }

        if (GameObject.FindGameObjectWithTag("Boss"))
        {
            BossHP boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossHP>();

            boss?.TakeDamage(10f);
        }



        Destroy(gameObject);

    }
}
