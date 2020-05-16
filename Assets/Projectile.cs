using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Transform enemyTransform;
    public int movespeed = 5;

    public void SetEnemy(Transform passedTransform)
    {
        enemyTransform = passedTransform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(enemyTransform.position * Time.deltaTime * movespeed);
    }
}
