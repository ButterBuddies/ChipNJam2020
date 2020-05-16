using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Card : MonoBehaviour
{
    public enum TypesOfCards {Action, Build}; //represents a card type
    public TypesOfCards myType;
    public GameObject placedPiece;
    //sprite or image for the card
    public bool played;
    private bool discarded;
    public string myName;

    public Card(string newName)
    {
        myName = newName;
    }

    public void Play()
    {
        if (!played)
        {

            switch (myName)
            {
                case "PorchFlower":
                    if (placedPiece != null)
                    {
                        GameObject wep = FindObjectOfType<WeaponCollection>().gameObject;
                        Instantiate(placedPiece, wep.transform);
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
        }

    }

}
