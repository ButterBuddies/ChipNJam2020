using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPhase : MonoBehaviour, IGamePhase
{
    public void Enter()
    {
        Debug.Log("Entered enemy phase");
        
    }

    public void Execute()
    {
        Debug.Log("Executed enemy phase");
    }

    public void Exit()
    {
        Debug.Log("Exited enemy phase");
    }
}
