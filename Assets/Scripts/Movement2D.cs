using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Vector3 moveDir = Vector3.zero;

    private void Update()
    {
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 dir)
    {
        moveDir = dir.normalized;
    }
}
