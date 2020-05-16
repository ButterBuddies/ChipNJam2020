using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{

    private IGamePhase currentPhase;
    public IGamePhase nextPhase;

    public void UpdateCurrentPhase()
    {
        if (currentPhase != null)
        {
            if (nextPhase == null) //there is no next phase yet, so just execute(update) the current phase
            {
                currentPhase.Execute();
            }
            else //there is a next phase, so we need change the phase
            {
                ChangePhase(nextPhase);
            }
        }
        else
        {
            ChangePhase(nextPhase);
        }
    }

    private void ChangePhase(IGamePhase newPhase)
    {
        if (newPhase == null)
        {
            Debug.Log("newState is Null");
            return;
        }

        if (currentPhase != null)
        {   //only exit the current phase if it exists
            currentPhase.Exit();
        }

        //now we can change the phase to the new phase, we exitted that old one, and now we enter the new one
        currentPhase = newPhase;
        currentPhase.Enter();
        nextPhase = null;
    }
}


