using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private List<Card> cards = new List<Card>();

    private void Start()
    { //just adding a bunch of cards for now, will setup a initialize deck later
        cards.Add(new Card("a"));
        cards.Add(new Card("b"));
        cards.Add(new Card("c"));
        cards.Add(new Card("d"));
        cards.Add(new Card("e"));
        cards.Add(new Card("f"));
        cards.Add(new Card("g"));
        cards.Add(new Card("h"));
        cards.Add(new Card("i"));
        cards.Add(new Card("j"));
    }

    public void Shuffle() //should shuffle the deck of cards (randomly re order)
    {
        
    }

    public Card GetNextCard()
    {
        Card nextCard = cards[0];
        cards.Remove(nextCard);
        return nextCard;
    }
    
}
