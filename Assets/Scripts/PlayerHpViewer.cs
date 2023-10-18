using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpViewer : MonoBehaviour
{
    [SerializeField] private PlayerHP playerHP;
    [SerializeField] private Slider sliderHp;

    private void Awake()
    {
        sliderHp = GetComponent<Slider>();
    }

    private void Update()
    {
        sliderHp.value = playerHP.CurHealth / playerHP.MaxHealth;
    }
}
