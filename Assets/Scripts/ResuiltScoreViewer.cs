using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResuiltScoreViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;

    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        textMeshProUGUI.text = "Result score :" + PlayerPrefs.GetInt("Score");
    }
}
