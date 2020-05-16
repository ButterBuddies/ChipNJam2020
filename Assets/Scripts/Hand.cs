using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hand : MonoBehaviour
{
    private List<GameObject> cards = new List<GameObject>();
    public GameObject handPanel;
    public GameObject cardPrefab;

    private void Discard(GameObject card) //this should remove/discard a card from the hand
    {
        cards.Remove(card);
        //Destroy(card.gameObject);
    }

    private void Play(Card card) //this should play a card from the hand
    {
        card.Play();
    }

    public void Display(string phaseType) //this should make the hand of cards display on the screen, probably to be interactable
    {

        if (!handPanel.activeInHierarchy)
        {
            handPanel.SetActive(true);
        }

        foreach (GameObject card in cards)
        {
            Card cardComponent = card.GetComponent<Card>();
            if (cardComponent.played)
            {
                //Discard(card);
                card.SetActive(false);
                continue;
            }

            if (phaseType == "") //display all cards
                card.SetActive(true);
            else if (phaseType == "Build")
            {
                if (cardComponent.myType == Card.TypesOfCards.Build)
                    cardComponent.GreyedOut(false);
                else
                    cardComponent.GreyedOut(true);
            }
            else if (phaseType == "Action")
            {
                if (cardComponent.myType == Card.TypesOfCards.Action)
                    cardComponent.GreyedOut(false);
                else
                    cardComponent.GreyedOut(true);
            }
        }
    }

    public void Add(GameObject newCard) //this should add a card to the hand
    {
        cards.Add(newCard);
        newCard.SetActive(true);
        newCard.transform.parent = handPanel.transform;
        newCard.transform.localScale = new Vector3(1, 1, 1);
    }
    
}
