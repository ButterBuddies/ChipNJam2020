using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<EnemyMovement> attackerPrefabList;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 2f;

    public int spawnerWidth = 6;
    bool spawn = true;

    GameObject house;

    private void Awake()
    {
        house = GameObject.FindGameObjectWithTag("House");
    }

    private void SpawnAttacker()
    {
        float spawnPosX = Random.Range(transform.position.x - spawnerWidth, transform.position.x + spawnerWidth);
        Instantiate(ChooseAttacker(), new Vector3(spawnPosX, transform.position.y, 0), transform.rotation, transform);
    }

    private EnemyMovement ChooseAttacker()
    {
        int randomNumber = Random.Range(0, 100);
        Debug.Log(randomNumber);
        if(randomNumber < 1)
        {
            return attackerPrefabList[3];
        }
        else if(randomNumber <= 7)
        {
            return attackerPrefabList[2];
        }
        else if (randomNumber <= 15)
        {
            return attackerPrefabList[1];
        }
        else
        {
            return attackerPrefabList[0];
        }
    }

    IEnumerator Start()
    {

        while (spawn)
        {
            if (!house.activeSelf)
            {
                Debug.Log("Break");
                yield break;
            }
            else
            {
                yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
                SpawnAttacker();
            }
        }
    }
}
