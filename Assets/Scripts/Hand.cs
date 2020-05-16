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

    public void Display() //this should make the hand of cards display on the screen, probably to be interactable
    {
        //foreach (Transform child in handPanel.transform) //clear out the old hand //prob not very efficient :(
        //{
        //    Destroy(child.gameObject);
        //}

        if (!handPanel.activeInHierarchy)
        {
            handPanel.SetActive(true);
        }

        //foreach (GameObject card in cards)
        //{
        //    if (card.GetComponent<Card>().played)
        //    {
        //        Discard(card);
        //    }

        //    //GameObject cardObj = Instantiate(cardPrefab);
        //    //cardObj.SetActive(true);
        //    //cardObj.transform.parent = handPanel.transform;
        //    //cardObj.transform.localScale = new Vector3(1, 1, 1);
        //    ////cardObj.GetComponentInChildren<Text>().text = card.myName;
        //    //cardObj.GetComponent<Button>().onClick.SetPersistentListenerState(0, UnityEngine.Events.UnityEventCallState.Off);
        //    //cardObj.GetComponent<Button>().onClick.AddListener(delegate { card.Play(); });
        //}
    }

    public void Add(GameObject newCard) //this should add a card to the hand
    {
        cards.Add(newCard);
        newCard.SetActive(true);
        newCard.transform.parent = handPanel.transform;
        newCard.transform.localScale = new Vector3(1, 1, 1);
    }
    
}
