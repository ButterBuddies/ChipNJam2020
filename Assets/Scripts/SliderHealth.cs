using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHealth : MonoBehaviour
{
    Health health;
    Slider slider;

    private void Awake()
    {
        health = gameObject.GetComponentInParent<Health>();
        slider = GetComponent<Slider>();
        slider.maxValue = health.health;
        slider.value = health.health;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health.health;
    }
}
