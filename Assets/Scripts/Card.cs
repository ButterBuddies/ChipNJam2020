﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    enum type {Action, Build}; //represents a card type
    //sprite or image for the card
    private bool played;
    private bool discarded;
    public string myName;

    public Card(string newName)
    {
        myName = newName;
    }

    public void Play()
    {
        Debug.Log(myName + " card got played!!??!");
        //should remove this card from the player hand, now that it has been used?
        
    }

}