using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private List<GameObject> cards = new List<GameObject>();
    private int maxNumOfCards = 30;
    public List<GameObject> listOfCardPrefabs = new List<GameObject>();
    public GameObject deckPanel;

    private void Start()
    { //just adding a bunch of cards for now, will setup a initialize deck later
        //cards.Add(new Card("a"));
        //cards.Add(new Card("b"));
        //cards.Add(new Card("c"));
        //cards.Add(new Card("d"));
        //cards.Add(new Card("e"));
        //cards.Add(new Card("f"));
        //cards.Add(new Card("g"));
        //cards.Add(new Card("h"));
        //cards.Add(new Card("i"));
        //cards.Add(new Card("j"));
        MakeRandomDeck();
    }

    public void MakeRandomDeck()
    {
        
        for (int i = 0; i < maxNumOfCards; i++)
        {
            GameObject newCard = Instantiate(listOfCardPrefabs[Random.Range(0, listOfCardPrefabs.Count)]);
            cards.Add(newCard);
            newCard.SetActive(true);
            newCard.transform.parent = deckPanel.transform;
            newCard.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void Shuffle() //should shuffle the deck of cards (randomly re order)
    {
        
    }

    public GameObject GetNextCard()
    {
        GameObject nextCard = cards[0];
        cards.Remove(nextCard);
        return nextCard;
    }
    
}
