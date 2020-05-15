using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermissionPhase : MonoBehaviour, IGamePhase
{
    public void Enter()
    {
        Debug.Log("Entered intermission phase");
    }

    public void Execute()
    {
        Debug.Log("Executed intermission phase");
    }

    public void Exit()
    {
        Debug.Log("Exited intermission phase");
    }
}
