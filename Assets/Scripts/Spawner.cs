using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<EnemyMovement> attackerPrefabList;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 2f;

    public int numTermites = 0;
    public int numBeetles = 0;
    public int numBeavers = 0;
    public int numBears = 0;

    public int spawnerWidth = 6;
    public bool doneSpawning = false;

    public Stack<EnemyMovement> attackerSpawnList;
    GameObject house;

    public void Awake()
    {
        //attackerPrefabList = new List<EnemyMovement>();
        attackerSpawnList = new Stack<EnemyMovement>();
        house = GameObject.FindGameObjectWithTag("Patio");
        //GenerateSpawnList();
    }

    //IEnumerator Start()
    //{
    //    //while (spawn)
    //    //{
    //    //    if (!house.activeSelf || attackerSpawnList.Count == 0)
    //    //    {
    //    //        yield break;
    //    //    }
    //    //    else
    //    //    {
    //    //        yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
    //    //        SpawnAttacker();
    //    //    }
    //    //}
    //}

    public void Reset()
    {
        doneSpawning = false;
        numTermites = 10;
        numBeetles = 1;
        numBeavers = 1;
        numBears = 1;
        GenerateSpawnList();
    }

    public void SpawnAttacker()
    {
        Debug.Log("got in spawn atcker");
        if (attackerSpawnList.Count == 0)
        {
            doneSpawning = true;
            return;
        }

        float spawnPosX = Random.Range(transform.position.x - spawnerWidth, transform.position.x + spawnerWidth);

        Instantiate(attackerSpawnList.Pop(), new Vector3(spawnPosX, transform.position.y, 0), transform.rotation, transform);
    }

    public void GenerateSpawnList()
    {

        while(numTermites != 0 || numBeetles !=0 || numBeavers !=0 || numBears !=0)
        {
            int randomNum = Random.Range(0, 4);

            if(randomNum == 0 && numTermites != 0)
            {
                numTermites--;
                attackerSpawnList.Push(attackerPrefabList[0]);
            }
            if (randomNum == 1 && numBeetles != 0)
            {
                numBeetles--;
                attackerSpawnList.Push(attackerPrefabList[1]);
            }
            if (randomNum == 2 && numBeavers != 0)
            {
                numBeavers--;
                attackerSpawnList.Push(attackerPrefabList[2]);
            }
            if (randomNum == 3 && numBears != 0)
            {
                numBears--;
                attackerSpawnList.Push(attackerPrefabList[3]);
            }
        }
    }

    private EnemyMovement RandomAttacker()
    {
        int randomNumber = Random.Range(0, 100);
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

    
}
