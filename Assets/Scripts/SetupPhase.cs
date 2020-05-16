using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupPhase : MonoBehaviour, IGamePhase
{
    private int numCardsToDraw = 7;
    public GameObject finishPhaseBtn;

    public void Enter()
    {
        finishPhaseBtn.SetActive(true);
        //Debug.Log("Entered setup phase");
        //deal player 7 cards
        for (int i = 0; i < numCardsToDraw; i++)
        {
            GamePhaseManager.Instance.player.DrawCard();
        }
        GamePhaseManager.Instance.player.ShowHand("Build");
    }

    public void Execute()
    {
        //Debug.Log("Executed setup phase");
    }

    public void Exit()
    {
        Debug.Log("Exited setup phase");
        finishPhaseBtn.SetActive(false);
    }

}
