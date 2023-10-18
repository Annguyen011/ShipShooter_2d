using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector2 moveDir;

    private Material material;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    private void LateUpdate()
    {
        material.mainTextureOffset += moveDir * speed * Time.deltaTime;
    }
}
