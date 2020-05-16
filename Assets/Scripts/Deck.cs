using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private List<GameObject> cardsInDeck = new List<GameObject>();
    private List<GameObject> discardDeck = new List<GameObject>();
    private int maxNumOfCards = 30;
    public List<GameObject> listOfCardPrefabs = new List<GameObject>();
    public List<int> numberOfEach = new List<int>();
    public GameObject deckPanel;

    public GameObject selectedCard;

    private void Awake()
    {
        Deck[] obj = FindObjectsOfType<Deck>();
        if (obj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

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
       // MakeRandomDeck();
    }

    public void MakeRandomDeck()
    {
        
        for (int i = 0; i < maxNumOfCards; i++)
        {
            GameObject newCard = Instantiate(listOfCardPrefabs[Random.Range(0, listOfCardPrefabs.Count)]);
            cardsInDeck.Add(newCard);
            newCard.SetActive(true);
            newCard.transform.SetParent(deckPanel.transform);
            newCard.transform.localScale = new Vector3(1, 1, 1);
        }
    }

   public void MakeDeck(Transform transform)
    {
        for(int i = 0; i < listOfCardPrefabs.Count - 1; i++)
        {
            for (int j = 0; j < numberOfEach[i]; j++)
            {
                GameObject newCard = Instantiate(listOfCardPrefabs[i]);
                cardsInDeck.Add(newCard);
                newCard.SetActive(true);
                newCard.transform.SetParent(transform);
                newCard.transform.localScale = new Vector3(1, 1, 1);
            }          
        }
    }

    public void Shuffle() //should shuffle the deck of cards (randomly re order)
    {
        if (discardDeck.Count != 0)
        {
            foreach (GameObject obj in discardDeck)
            {
                cardsInDeck.Add(obj);
            }
        }
        discardDeck = new List<GameObject>();
        for(int i= 0; i < cardsInDeck.Count-1; i++)
        {
            int randomIndex = Random.Range(i, cardsInDeck.Count);
            GameObject tempObj = cardsInDeck[randomIndex];
            cardsInDeck[randomIndex] = cardsInDeck[i];
            cardsInDeck[i] = tempObj;
        }
        
    }
    
    public void CleanUp()
    {
        cardsInDeck = new List<GameObject>();
        discardDeck = new List<GameObject>(); 
    }

    public void EditDeck(bool add)
    {
        if (selectedCard != null)
        {
            Debug.Log(listOfCardPrefabs.IndexOf(selectedCard));
            int index = listOfCardPrefabs.IndexOf(selectedCard);
            int number = 0;
            if (add)
            {
                if (numberOfEach[index] < 4)
                {
                    number = 1;
                    Instantiate(selectedCard, selectedCard.transform.parent);
                }
                else
                {
                    Debug.Log("Too many of this card in deck");
                }
                selectedCard.GetComponent<Card>().Select();
            }
            else if (numberOfEach[index] > 0)
            {
                number = -1;
                selectedCard.SetActive(false);
            }
            else
            {
                Debug.Log("No type of this card in deck");
                selectedCard.SetActive(false);
            }
            numberOfEach[index] += number;
        }
        else
        {
            Debug.Log("No card selected");
        }
   

    }

    public GameObject GetNextCard()
    {
        GameObject nextCard = cardsInDeck[0];
        discardDeck.Add(cardsInDeck[0]);
        cardsInDeck.Remove(nextCard);
        return nextCard;
    }
    
}
