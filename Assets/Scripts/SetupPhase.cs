using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupPhase : MonoBehaviour, IGamePhase
{
    public void Enter()
    {
        Debug.Log("Entered setup phase");
    }

    public void Execute()
    {
        Debug.Log("Executed setup phase");
    }

    public void Exit()
    {
        Debug.Log("Exited setup phase");
    }

}
