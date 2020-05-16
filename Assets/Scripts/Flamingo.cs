using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamingo : MonoBehaviour
{

    EnemyMovement objectToAttack;
    int attackDamage = 2;
    float attackSpeed = 1f;

    IEnumerator Attack()
    {
        EnemyMovement enemy = objectToAttack;
        while (enemy.health > 0)
        {
            if (enemy == null)
                yield break;
            enemy.DecrementHealth(attackDamage);
            if (enemy.GetComponent<Flower>())
                enemy.DecrementHealth(attackDamage);
            yield return new WaitForSeconds(attackSpeed);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        objectToAttack = collision.gameObject.GetComponent<EnemyMovement>();
        if(objectToAttack != null)
            StartCoroutine("Attack");
    }
}
