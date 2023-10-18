using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AttackType
{
    CircleFire,
    SingleFireToCenterPosition
}
public class BossWeapon : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    public void StartFiring(AttackType type)
    {
        StartCoroutine(type.ToString());
    }
    
    public void StopFiring(AttackType type)
    {
        StopCoroutine(type.ToString());
    }

    private IEnumerator CircleFire()
    {
        float attackRate = .5f;
        int count = 30;
        float intValueAngle = 360 / count;
        float weightAngle = 0;

        while (true)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject clone = Instantiate(prefab, transform.position, Quaternion.identity);

                float angle = weightAngle + intValueAngle * i;

                float y = Mathf.Sin(angle * Mathf.PI / 180f);
                float x = Mathf.Cos(angle * Mathf.PI / 180f);

                clone.GetComponent<Movement2D>().MoveTo(new Vector3(x, y));
            }

            weightAngle++;

            yield return new WaitForSeconds(attackRate);
        }
    }

    private IEnumerator SingleFireToCenterPosition()
    {
        Vector3 targetPos = Vector3.zero;
        float attackRate = .1f;

        while (true)
        {
            GameObject clone = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;

            Vector3 dir  = targetPos - clone.transform.position;
            dir.Normalize();

            clone.GetComponent<Movement2D>().MoveTo(dir);

            yield return new WaitForSeconds(attackRate);
        }
    }
}
