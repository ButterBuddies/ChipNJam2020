using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinkler : MonoBehaviour
{

    List<EnemyMovement> enemyList;
    EnemyMovement collider;
    public float attackSpeed = 1;
    public int attackDamage = 5;

    IEnumerator Attack()
    {
        EnemyMovement enemy = collider;
        while (enemy.health > 0)
        {
            if (enemy == null)
                yield break;
            enemy.DecrementHealth(attackDamage);
            yield return new WaitForSeconds(attackSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collider = collision.gameObject.GetComponent<EnemyMovement>();
        if (collider != null)
            StartCoroutine("Attack");
                //collider.DecrementHealth(attackDamage);
    }
}
