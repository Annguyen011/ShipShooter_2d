using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawner : MonoBehaviour
{
    [SerializeField] private StageData stageData;
    [SerializeField] private GameObject alertLinePrefab;
    [SerializeField] private GameObject JunkPrefab;
    [SerializeField] private float minSpawnTime = 1f;
    [SerializeField] private float maxSpawnTime = 4f;

    private void Start()
    {
        StartCoroutine("SpawnJunk");
    }

    private IEnumerator SpawnJunk()
    {
        while (true)
        {
            float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);

            GameObject alertLineClone = Instantiate(alertLinePrefab, new Vector3(positionX, 0), Quaternion.identity);

            yield return new WaitForSeconds(1);

            Destroy(alertLineClone );

            Vector3 junkPos = new Vector3(positionX, stageData.LimitMax.y + 1);
            Instantiate(JunkPrefab, junkPos, Quaternion.identity);

            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
