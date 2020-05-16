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
        StartCoroutine("FlashHurt");
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator FlashHurt()
    {
        foreach(Image i in images)
            i.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        foreach (Image i in images)
            i.color = defaultColor;
        yield break;
    }
}
