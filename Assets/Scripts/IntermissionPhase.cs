using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IntermissionPhase : MonoBehaviour, IGamePhase
{
    private int numCardsToDraw = 1;
    public GameObject finishPhaseBtn;

    public void Enter()
    {
        finishPhaseBtn.SetActive(true);
        Debug.Log("Entered build/intermission phase");
        for (int i = 0; i < numCardsToDraw; i++)
        {
            GamePhaseManager.Instance.player.DrawCard();
        }
        GamePhaseManager.Instance.player.ShowHand();
    }

    public void Execute()
    {
        Debug.Log("Executed intermission phase");
    }

    public void Exit()
    {
        Debug.Log("Exited intermission phase");
        finishPhaseBtn.SetActive(false);
    }
}
