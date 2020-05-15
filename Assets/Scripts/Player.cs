using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Hand hand;
    private Deck deck;

    private void Start()
    {
        hand = GetComponent<Hand>();
        deck = GameObject.FindGameObjectWithTag("DeckOfCards").GetComponent<Deck>();

    }

    public void DrawCard()
    {
        hand.Add(deck.GetNextCard());
    }

    public void ShowHand()
    {
        hand.Display();
    }
}
