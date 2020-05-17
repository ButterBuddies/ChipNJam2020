using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public enum TypesOfCards {Action, Build}; //represents a card type
    public TypesOfCards myType;
    public GameObject placedPiece;
    //sprite or image for the card
    public bool played;
    private bool discarded;
    public string myName;
    bool selected = false;
    private GameObject theMainCanvas;

    public void Start()
    {
        theMainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
    }

    public Card(string newName)
    {
        myName = newName;
    }

    public void Play()
    {
        if (!played)
        {
            string scene = SceneManager.GetActiveScene().name;
            if (FindObjectOfType<GamePhaseManager>() != null) { 
                switch (myName)
                {
                    case "Sprinkler":
                        if (placedPiece != null)
                        {
                            GameObject obj = Instantiate(placedPiece);
                            obj.transform.parent = theMainCanvas.transform;
                            obj.transform.localScale = new Vector3(1, 1, 1);
                        }
                        break;
                    case "Lawn Fertilizer":
                        EnemyMovement[] enemyMoves = FindObjectsOfType<EnemyMovement>();
                        foreach (EnemyMovement em in enemyMoves)
                        {
                            em.moveSpeedMultiplier = 0.8f;
                        }
                        FindObjectOfType<Spawner>().globalMoveSpeedMultiplier = 0.8f;
                        break;

                    case "LiquidNitrogen":
                        StartCoroutine("Freeze");
                        break;

                    case "Incecticide":
                        Sprinkler[] sprinklers = FindObjectsOfType<Sprinkler>();
                        if (sprinklers.Length > 0)
                        {
                            foreach (Sprinkler s in sprinklers)
                            {
                                s.damageMultiplier = 2;
                            }
                        }
                        FindObjectOfType<GamePhaseManager>().damageMultiplier = 2;
                        break;

                    case "PorchFlower":
                        if (placedPiece != null)
                        {
                            GameObject obj = Instantiate(placedPiece);
                            obj.transform.parent = theMainCanvas.transform;
                            obj.transform.localScale = new Vector3(1, 1, 1);
                        }
                        break;

                    case "2x4":
                        GameObject.FindGameObjectWithTag("Patio").GetComponent<Health>().health += 25;
                        break;

                    case null:
                        Debug.Log("Invalid card type");
                        break;
                }
                Debug.Log(myName + " card got played");
                played = true;
                gameObject.SetActive(false);
                //should remove this card from the player hand, now that it has been used?
            }else if(scene == "CardDeckBuilding")
            {
                Select();
            }
        }
    }

    public void Select()
    {
        selected = !selected;
        if (selected)
        {
            FindObjectOfType<Deck>().selectedCard = this.gameObject;
        }
        else
        {
            FindObjectOfType<Deck>().selectedCard = null;
        }
    }

    public void GreyedOut(bool greyed)
    {
        GetComponent<Button>().interactable = !greyed;
    }

    IEnumerator Freeze()
    {
        EnemyMovement[] enemyMoves = FindObjectsOfType<EnemyMovement>();
        foreach (EnemyMovement em in enemyMoves)
        {
            em.moveSpeedMultiplier = 0f;
        }
        yield return new WaitForSeconds(5f);
        foreach (EnemyMovement em in enemyMoves)
        {
            em.moveSpeedMultiplier = 0.8f;
        }
    }


}
