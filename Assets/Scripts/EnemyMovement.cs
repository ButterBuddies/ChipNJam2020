using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{

    GameObject house;
    Spawner spawner;
    Vector2 direction;
    bool coRoutineActive = false;
    public float tempMoveSpeed = 0;
    public float maxMoveSpeed = 1;
    public float moveSpeedMultiplier = 1;
    public int attackDamage = 5;
    public float attackSpeed = 2;
    public float health = 5;
    public int scorePoints = 0;
    private Health objectToAttack;
    RawImage enemyImage;
    Color defaultColor;
    private bool toggle;

    private void Awake()
    {
        house = GameObject.FindGameObjectWithTag("Patio");
        spawner = FindObjectOfType<Spawner>();
        direction = house.transform.position - spawner.transform.position;
        direction.Normalize();
        tempMoveSpeed = maxMoveSpeed;
        enemyImage = gameObject.GetComponent<RawImage>();
        defaultColor = enemyImage.color;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(direction * Time.deltaTime * (tempMoveSpeed*moveSpeedMultiplier));
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
                DecrementHealth(objectToAttack.GetComponent<Flower>().damageAmount);
            yield return new WaitForSeconds(attackSpeed);
        }
        tempMoveSpeed = maxMoveSpeed;
    }

    public void DecrementHealth(int amount)
    {
        health -= amount;
        //StartCoroutine("FlashHurt");
        Invoke("FlashHurtOn", 0.1f);
        if (health <= 0)
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.IncrementScore(scorePoints);
            Destroy(gameObject);
        }
    }

    public void FlashHurtOn()
    {
        enemyImage.color = Color.red;
        Invoke("FlashHurtOff", 0.1f);

    }

    public void FlashHurtOff()
    {
        enemyImage.color = defaultColor;
    }

    //IEnumerator FlashHurt()
    //{
    //    enemyImage.color = Color.red;
    //    yield return new WaitForSeconds(0.1f);
    //    enemyImage.color = defaultColor;
    //    yield break;
    //}
}
