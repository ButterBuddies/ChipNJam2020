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

    public Card(string newName)
    {
        myName = newName;
    }

    public void Play()
    {
        if (!played)
        {
            string scene = SceneManager.GetActiveScene().name;
            if (scene == "SarahsScene")
            {
                switch (myName)
                {
                    case "PorchFlower":
                        if (placedPiece != null)
                        {
                        }
                        return;

                    case null:
                        Debug.Log("Invalid card type");
                        return;
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

}
