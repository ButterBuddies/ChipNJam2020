using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squish : MonoBehaviour
{
    public GameObject[] squishGraphics;

    public void SquishedDeath()
    {
        GameObject pickedGraphic = squishGraphics[Random.Range(0, 2)];
        pickedGraphic.SetActive(true);
        AudioSource m = pickedGraphic.GetComponent<AudioSource>();
        m.PlayOneShot(m.clip);
        pickedGraphic.transform.SetParent(null);
        gameObject.SetActive(false);
    }

    public void SquishDamage()
    {

        GetComponent<EnemyMovement>().health -= 5;
        if (GetComponent<EnemyMovement>().health <= 0)
        {
            SquishedDeath();
        }
        else
        {
            GameObject pickedGraphic = squishGraphics[Random.Range(0, 2)];
            AudioSource m = pickedGraphic.GetComponent<AudioSource>();
            m.PlayOneShot(m.clip);
        }
    }
}
