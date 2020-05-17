using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePhaseManager : MonoBehaviour
{
    private StateMachine stateMachine;
    private SetupPhase setupPhase;
    private EnemyPhase enemyPhase;
    private IntermissionPhase buildPhase;

    bool end = false;

    public int waveCount = 2;
    private int currentWave = 0;

    public int damageMultiplier = 1;

    public Player player;
    private Health patioHealth;

    private static GamePhaseManager _instance;
    public GameObject winScreen;
    public AudioSource musicPlayer;
    public AudioClip winMusic;
    public AudioClip loseMusic;

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
        buildPhase = GetComponent<IntermissionPhase>();

        patioHealth = GameObject.FindGameObjectWithTag("Patio").GetComponent<Health>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        stateMachine.nextPhase = setupPhase; //set the default phase
        musicPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        stateMachine.UpdateCurrentPhase();
        CheckPatioHP();
    }

    void CheckPatioHP()
    {
        if (!end)
        {
            if (patioHealth.health <= 0)
            {
                LostLevel();
                end = true;
            }
        }
    }

    public void StartEnemyPhase() //can pass in number of waves maybe? as an int
    {
        currentWave++;
        stateMachine.nextPhase = enemyPhase;
        //to finished enemy phase for now, use a timer, but in future it will be based on remaining units alive
        //Invoke("StartBuildPhase", 10);
    }

    public void StartBuildPhase()
    {
        if (currentWave >= waveCount)
        {
            WonLevel();
        }
        else
        {
            stateMachine.nextPhase = buildPhase;

        }

    }

    public void WonLevel()
    {
        //we won the game! Got through all the waves alive
        //load the win sequnce or scene or whatever
        Debug.Log("Won the game! Survived all " + currentWave + " waves!");
        winScreen.SetActive(true);
        musicPlayer.PlayOneShot(winMusic);
    }

    public void LostLevel()
    {
        //should be based on deck HP == 0?
        Debug.Log("lost the game! Survived up to wave " + currentWave);
        musicPlayer.PlayOneShot(loseMusic);
    }

    public void NextPhase()
    {
        SceneManager.LoadScene("CardDeckBuilding");
    }
}

