using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BossState
{
    MoveToAppearPoint,
    Phase01,
    Phase02,
    Phase03,

}
public class Boss : MonoBehaviour
{
    [SerializeField] private float appearPoint = 2.5f;
    private BossState bossState = BossState.MoveToAppearPoint;
    [SerializeField] private string victory;
    [SerializeField] private StageData stageData;

    private BossHP hP;
    private Movement2D movement;
    private BossWeapon bossWeapon;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        hP = GetComponent<BossHP>();
        bossWeapon = GetComponent<BossWeapon>();
        movement = GetComponent<Movement2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeState(BossState state)
    {
        StopCoroutine(bossState.ToString());

        bossState = state;

        StartCoroutine(bossState.ToString());

    }

    private IEnumerator MoveToAppearPoint()
    {
        movement.MoveTo(Vector3.down);

        while (true)
        {
            if (transform.position.y <= appearPoint)
            {
                movement.MoveTo(Vector3.zero);

                ChangeState(BossState.Phase01);
            }
            yield return null;
        }
    }

    private IEnumerator Phase01()
    {
        bossWeapon.StartFiring(AttackType.CircleFire);

        while (true)
        {
            if (hP.CurHealth <= hP.MaxHealth * .7f)
            {
                bossWeapon.StopFiring(AttackType.CircleFire);

                ChangeState(BossState.Phase02);
            }

            yield return null;
        }
    }

    private IEnumerator Phase02()
    {
        bossWeapon.StartFiring(AttackType.SingleFireToCenterPosition);

        Vector3 dir = Vector3.right;
        movement.MoveTo(dir);

        while (true)
        {
            if (transform.position.x <= stageData.LimitMin.x || transform.position.x >= stageData.LimitMax.x)
            {
                dir *= -1;
                movement.MoveTo(dir);
            }
            if (hP.CurHealth <= hP.MaxHealth * .3f)
            {
                bossWeapon.StopFiring(AttackType.SingleFireToCenterPosition);

                ChangeState(BossState.Phase03);
            }
            yield return null;
        }
    }

    private IEnumerator Phase03()
    {
        bossWeapon.StartFiring(AttackType.SingleFireToCenterPosition);
        bossWeapon.StartFiring(AttackType.CircleFire);
        Vector3 dir = Vector3.right;
        movement.MoveTo(dir);

        while (true)
        {

            if (transform.position.x <= stageData.LimitMin.x || transform.position.x >= stageData.LimitMax.x)
            {
                dir *= -1;
                movement.MoveTo(dir);
            }

            yield return null;
        }
    }

    public void OnDie()
    {
        spriteRenderer.enabled = false;

        Invoke(nameof(ChangeScene), .2f);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(victory);

    }
}
