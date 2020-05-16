using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePhaseManager : MonoBehaviour
{
    private StateMachine stateMachine;
    private SetupPhase setupPhase;
    private EnemyPhase enemyPhase;
    private IntermissionPhase intermissionPhase;

    public Player player;

    private static GamePhaseManager _instance;
    public static GamePhaseManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GamePhaseManager>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("GamePhaseManager");
                    _instance = container.AddComponent<GamePhaseManager>();
                }
            }

            return _instance;
        }
    }

    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        setupPhase = GetComponent<SetupPhase>();
        enemyPhase = GetComponent<EnemyPhase>();
        intermissionPhase = GetComponent<IntermissionPhase>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        stateMachine.nextPhase = setupPhase; //set the default phase
    }

    void Update()
    {
        stateMachine.UpdateCurrentPhase();
    }
}

