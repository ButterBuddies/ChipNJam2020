using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePhaseManager : MonoBehaviour
{   //maybe make this class static

    private StateMachine stateMachine;
    private SetupPhase setupPhase;
    private EnemyPhase enemyPhase;
    private IntermissionPhase intermissionPhase;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        setupPhase = GetComponent<SetupPhase>();
        enemyPhase = GetComponent<EnemyPhase>();
        intermissionPhase = GetComponent<IntermissionPhase>();

        stateMachine.nextPhase = setupPhase; //set the default phase
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.UpdateCurrentPhase();
    }
}
