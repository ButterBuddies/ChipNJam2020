using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    enum type {Action, Build}; //represents a card type
    //sprite or image for the card
    private bool played;
    private bool discarded;

    public void Play()
    {
        Debug.Log("card got played!!??!?!?!");
    }

}
