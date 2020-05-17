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
        GameObject nextcard = deck.GetNextCard();
        if (nextcard != null)
        {
            hand.Add(nextcard);
        }
        else
        {
            Debug.Log("there's no card");
        }
    }

    public void ShowHand(string phaseType)
    {
        hand.Display(phaseType);
    }
}
