using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnome : MonoBehaviour
{
    int attackSpeed;

    IEnumerator Start()
    {
        while(true)
        {


            yield return new WaitForSeconds(attackSpeed);
        }
    }
}
