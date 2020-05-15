using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckHealth : MonoBehaviour
{

    public int health = 100;


    public void DecrementHealth(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

}
