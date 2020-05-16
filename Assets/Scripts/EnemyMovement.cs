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
    public float health = 5;
    private Health objectToAttack;

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
        transform.Translate(direction * Time.deltaTime * tempMoveSpeed);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        objectToAttack = collision.gameObject.GetComponent<Health>();
        if(objectToAttack != null)
            StartCoroutine("Attack");
    }

    IEnumerator Attack()
    {
        
        tempMoveSpeed = 0;

        while (objectToAttack.health > 0 && objectToAttack != null)
        {
            objectToAttack.DecrementHealth(attackDamage);
            if (objectToAttack.GetComponent<Flower>())
                DecrementHealth(5);
            yield return new WaitForSeconds(attackSpeed);
        }
        tempMoveSpeed = maxMoveSpeed;
    }

    public void DecrementHealth(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
            //IncrementScore
        }
    }
}
