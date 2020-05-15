using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject attackerPrefab;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 5f;

    public int spawnerWidth = 6;
    bool spawn = true;

    private void SpawnAttacker()
    {
        float spawnPosX = Random.Range(transform.position.x - spawnerWidth, transform.position.x + spawnerWidth);
        Instantiate(attackerPrefab, new Vector3(spawnPosX, transform.position.y, 0), transform.rotation, transform);
    }

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }
}
