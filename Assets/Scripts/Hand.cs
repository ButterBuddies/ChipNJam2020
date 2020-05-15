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

    private void Display() //this should make the hand of cards display on the screen, probably to be interactable
    {

    }

    private void Add(Card card) //this should add a card to the hand
    {
        cards.Add(card);
    }
    
}
