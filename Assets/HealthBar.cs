using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField]
    public float current = 1.0f;

    [SerializeField]
    private Image HealthImage;

    private void Start()
    {

    }


    private void Update()
    {

    }

    internal void SetHealth(float current)
    {
        HealthImage.fillAmount = current;
    }
}