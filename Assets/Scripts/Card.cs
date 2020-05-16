using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public enum TypesOfCards {Action, Build}; //represents a card type
    public TypesOfCards myType; 
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
        Debug.Log(myName + " card got played");
        played = true;
        gameObject.SetActive(false);
        //should remove this card from the player hand, now that it has been used?

    }

}
