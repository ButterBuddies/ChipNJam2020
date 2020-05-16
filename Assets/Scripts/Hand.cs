using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hand : MonoBehaviour
{
    private List<Card> cards = new List<Card>();
    public GameObject handPanel;
    public GameObject cardPrefab;

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
        foreach (Transform child in handPanel.transform) //clear out the old hand //prob not very efficient :(
        {
            Destroy(child.gameObject);
        }

        if (!handPanel.activeInHierarchy)
        {
            handPanel.SetActive(true);
        }

        foreach (Card card in cards)
        {
            //Debug.Log(card.myName);
            GameObject cardObj = Instantiate(cardPrefab);
            cardObj.SetActive(true);
            cardObj.transform.parent = handPanel.transform;
            cardObj.transform.localScale = new Vector3(1, 1, 1);
            cardObj.GetComponentInChildren<Text>().text = card.myName;
            cardObj.GetComponent<Button>().onClick.SetPersistentListenerState(0, UnityEngine.Events.UnityEventCallState.Off);
            cardObj.GetComponent<Button>().onClick.AddListener(delegate { card.Play(); });
        }
    }

    public void Add(Card card) //this should add a card to the hand
    {
        cards.Add(card);
    }
    
}
