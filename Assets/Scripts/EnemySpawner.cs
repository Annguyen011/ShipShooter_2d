using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private StageData stageData;
    [SerializeField] private GameObject prefab;
    [SerializeField] private float spawnTimer;
    [SerializeField] private float maxEnemyCount;
    [SerializeField] private GameObject textBoss;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject bossHpUi;
    private void Awake()
    {
        StartCoroutine("SpawnEnemy");
    }

    private void Start()
    {
        textBoss.SetActive(false);
        boss.SetActive(false);
        bossHpUi.SetActive(false);
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            float positionX = UnityEngine.Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);

            Instantiate(prefab, new Vector3(positionX, stageData.LimitMax.y + 1), Quaternion.identity);

            maxEnemyCount--;
            if (maxEnemyCount ==0) 
            {
                StartCoroutine("SpawnBoss");

                StopCoroutine("SpawnEnemy");
            }

            yield return new WaitForSeconds(spawnTimer);
        }
    }

    private IEnumerator SpawnBoss()
    {
        textBoss.SetActive(true);

        yield return new WaitForSeconds(.2f);

        textBoss.SetActive(false);

        bossHpUi.SetActive(true);
        boss.gameObject.SetActive(true);

        boss.GetComponent<Boss>().ChangeState(BossState.MoveToAppearPoint);
    }
}

