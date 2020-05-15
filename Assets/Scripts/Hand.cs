using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private List<Card> cards = new List<Card>();

    private void Discard(Card card) //this should remove/discard a card from the hand
    {
        cards.Remove(card);
    }

    private void Play(Card card) //this should play a card from the hand
    {
        card.Play();
    }

    public void Display() //this should make the hand of cards display on the screen, probably to be interactable
    {
        foreach (Card card in cards)
        {
            Debug.Log(card.myName);
        }
    }

    public void Add(Card card) //this should add a card to the hand
    {
        cards.Add(card);
    }
    
}
