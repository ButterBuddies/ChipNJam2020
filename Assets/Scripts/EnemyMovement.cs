using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject housePos;
    [SerializeField] Transform enemySpawnPos;

    Vector2 direction;
    int moveSpeed = 1;
    int attackDamage = 20;
    GameObject colliderObject;

    private void Awake()
    {
        direction = housePos.transform.position - enemySpawnPos.position;
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        if(housePos.transform.position.y - gameObject.transform.position.y < 1f && housePos.active)
        {
            StartCoroutine("Attack");
        }
        else
        {
            transform.Translate(direction * Time.deltaTime * moveSpeed);
        }
    }

    IEnumerator Attack()
    {
        DeckHealth deckHealth = housePos.GetComponent<DeckHealth>();
        moveSpeed = 0;
        while (deckHealth.health > 0)
        {
            yield return new WaitForSeconds(4f);
            deckHealth.DecrementHealth(attackDamage);
        }
        moveSpeed = 1;
    }
}
