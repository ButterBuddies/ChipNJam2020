using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHealth : MonoBehaviour
{
    Health patioHealth;
    Slider slider;

    private void Awake()
    {
        patioHealth = gameObject.GetComponentInParent<Health>();
        slider = GetComponent<Slider>();
        slider.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = patioHealth.health;
    }
}
