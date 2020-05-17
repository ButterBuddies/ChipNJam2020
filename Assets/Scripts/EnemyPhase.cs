using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPhase : MonoBehaviour, IGamePhase
{
    private Spawner spawner;
    public AudioClip music;

    public void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
    }

    public void Enter()
    {
        Debug.Log("Entered enemy phase");
        GamePhaseManager.Instance.player.ShowHand("Action");
        spawner.Reset();
        InvokeRepeating("SpawnRequest", 1, .1f);
        GamePhaseManager.Instance.musicPlayer.clip = music;
        GamePhaseManager.Instance.musicPlayer.Play();
    }

    private void SpawnRequest()
    {
        spawner.SpawnAttacker();
    }

    public void Execute()
    {
        //Debug.Log("Executed enemy phase");
        if (spawner.doneSpawning)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length <= 0)
                GamePhaseManager.Instance.StartBuildPhase();
        }
    }

    public void Exit()
    {
        CancelInvoke();
        Debug.Log("Exited enemy phase");
        
    }
}
