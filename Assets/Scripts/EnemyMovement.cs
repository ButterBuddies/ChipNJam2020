using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    GameObject house;
    Spawner spawner;
    Vector2 direction;
    bool coRoutineActive = false;
    public float tempMoveSpeed = 0;
    public float maxMoveSpeed = 1;
    public int attackDamage = 5;
    public float attackSpeed = 2;

    private void Awake()
    {
        house = GameObject.FindGameObjectWithTag("House");
        spawner = FindObjectOfType<Spawner>();
        direction = house.transform.position - spawner.transform.position;
        direction.Normalize();
        tempMoveSpeed = maxMoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(house.transform.position.y - gameObject.transform.position.y < 0.5f && house.activeSelf && !coRoutineActive)
        {
            StartCoroutine("Attack");
            coRoutineActive = true;
        }
        else
        {
            transform.Translate(direction * Time.deltaTime * tempMoveSpeed);
        }
    }

    IEnumerator Attack()
    {
        Debug.Log("Starting Co-routine");
        Health deckHealth = house.GetComponent<Health>();
        tempMoveSpeed = 0;

        while (deckHealth.health > 0)
        {
            yield return new WaitForSeconds(attackSpeed);
            if (deckHealth == null)
                yield break;
            deckHealth.DecrementHealth(attackDamage);
        }
        tempMoveSpeed = maxMoveSpeed;
    }
}
