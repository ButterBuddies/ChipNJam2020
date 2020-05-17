using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SideDeck : MonoBehaviour
{
    public static SideDeck instance;

    private Text cardsCountText;
    public int countCards;
    public int maxDeckSize = 30;

    public int numSprinklers;
    public int numLawnF;
    public int numLiqNitro;
    public int numInce;
    public int numPorchFlower;
    public int numPlantFood;
    public int numGMO;
    public int num2x4;
    public int numBuffout;

    void Update()
    {
        if (cardsCountText != null )
        {
            cardsCountText.text = "Build your deck! \t Cards " + countCards + "/" + maxDeckSize;
        }
    }

    private void Start()
    {
        Debug.Log("in start of side deck");
    }

    public void OnLevelWasLoaded(int level)
    {
        Debug.Log("level was loaded");
        string scene = SceneManager.GetActiveScene().name;
        if (scene.Contains("CardDeckBuilding"))
        {
            cardsCountText = GameObject.FindGameObjectWithTag("CountText").GetComponent<Text>();
            Invoke("ClearCardCounts", 1f);
            countCards = 0;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        //Debug.Log("in Awake of side deck");
        //ClearCardCounts();
        string scene = SceneManager.GetActiveScene().name;
        if (scene.Contains("CardDeckBuilding"))
            cardsCountText = GameObject.FindGameObjectWithTag("CountText").GetComponent<Text>();
    }

    public void RemoveCardCount(string cardName)
    {
        switch (cardName)
        {
            case "Sprinkler":
                numSprinklers--;
                break;
            case "LawnFertilizer":
                numLawnF--;
                break;
            case "LiquidNitrogen":
                numLiqNitro--;
                break;
            case "Incecticide":
                numInce--;
                break;
            case "PorchFlower":
                numPorchFlower--;
                break;
            case "PlantFood":
                numPlantFood--;
                break;
            case "GMO":
                numGMO--;
                break;
            case "2x4":
                num2x4--;
                break;
            case "Buffout":
                numBuffout--;
                break;
            case null:
                Debug.Log("Invalid card type");
                break;
        }
    }

    public void AddCardCount(string cardName)
    {
        switch (cardName)
        {
            case "Sprinkler":
                numSprinklers++;
                break;
            case "LawnFertilizer":
                numLawnF++;
                break;
            case "LiquidNitrogen":
                numLiqNitro++;
                break;
            case "Incecticide":
                numInce++;
                break;
            case "PorchFlower":
                numPorchFlower++;
                break;
            case "PlantFood":
                numPlantFood++;
                break;
            case "GMO":
                numGMO++;
                break;
            case "2x4":
                num2x4++;
                break;
            case "Buffout":
                numBuffout++;
                break;
            case null:
                Debug.Log("Invalid card type");
                break;
        }
    }

    public void ClearCardCounts()
    {
        numSprinklers = 0;
        numLawnF = 0;
        numLiqNitro = 0;
        numInce = 0;
        numPorchFlower = 0;
        numPlantFood = 0;
        numGMO = 0;
        num2x4 = 0;
        numBuffout = 0;
    }
}
