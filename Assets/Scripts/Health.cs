using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public int health;
    List<Image> images;
    Color defaultColor;

    public void Awake()
    {
        images = new List<Image>(gameObject.GetComponents<Image>());
        defaultColor = images[0].color;
    }

    public void DecrementHealth(int damage)
    {
        health -= damage;
        Invoke("FlashHurtOn", 0.1f);
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void FlashHurtOn()
    {
        foreach (Image i in images)
            i.color = Color.red;
        Invoke("FlashHurtOff", 0.1f);

    }

    public void FlashHurtOff()
    {
        foreach (Image i in images)
            i.color = defaultColor;
    }
}
