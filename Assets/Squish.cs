using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squish : MonoBehaviour
{
    public GameObject[] squishGraphics;

    public void Squished()
    {
        GameObject pickedGraphic = squishGraphics[Random.Range(0, 2)];
        pickedGraphic.SetActive(true);
        AudioSource m = pickedGraphic.GetComponent<AudioSource>();
        m.PlayOneShot(m.clip);
        pickedGraphic.transform.SetParent(null);
        gameObject.SetActive(false);
    }
}
