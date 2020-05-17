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
    public int levelNumber = 1;
    AudioSource audio;
    private SideDeck sideDeck;

    public GameObject selectedCard;

    private void Awake()
    {
        sideDeck = FindObjectOfType<SideDeck>();
        //Deck[] obj = FindObjectsOfType<Deck>();
        //if (obj.Length > 1)
        //{
        //    Destroy(this.gameObject);
        //}

        //DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    { //just adding a bunch of cards for now, will setup a initialize deck later
      // MakeRandomDeck();
        audio = GetComponent<AudioSource>();
    }

    public void MakeRandomDeck(Transform transform)
    {
        
        for (int i = 0; i < maxNumOfCards; i++)
        {
            GameObject newCard = Instantiate(listOfCardPrefabs[Random.Range(0, listOfCardPrefabs.Count)]);
            cardsInDeck.Add(newCard);
            newCard.SetActive(true);
            newCard.transform.SetParent(transform);
            newCard.transform.localScale = new Vector3(1, 1, 1);
        }
    }

   public void MakeDeck(Transform transform)
    {   //make deck based on the side deck numbers
        //im going to regret this code in the morn tomorrow
        numberOfEach[0] = sideDeck.numSprinklers;
        numberOfEach[1] = sideDeck.numPorchFlower;
        numberOfEach[2] = sideDeck.num2x4;
        numberOfEach[3] = sideDeck.numBuffout;
        numberOfEach[4] = sideDeck.numLawnF;
        numberOfEach[5] = sideDeck.numPlantFood;
        numberOfEach[6] = sideDeck.numInce;
        numberOfEach[7] = sideDeck.numLiqNitro;
        numberOfEach[8] = sideDeck.numGMO;


        for (int i = 0; i < listOfCardPrefabs.Count; i++)
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
        /*
        cardsInDeck = new List<GameObject>();
        discardDeck = new List<GameObject>(); 
        */
    }

    public void EditDeck(bool add)
    {
        if (selectedCard != null)
        {
            //int index = listOfCardPrefabs.IndexOf(selectedCard);
            int index=0;
            bool searching = true;
            int i = 0;
            string cardName = selectedCard.GetComponent<Card>().myName;
            while (searching)
            {
                if (i < listOfCardPrefabs.Count)
                {
                    if (listOfCardPrefabs[i].GetComponent<Card>().myName == cardName)
                    {
                        searching = false;
                        index = i;
                    }
                    else
                    {
                        i++;
                    }
                }
                else
                {
                    Debug.Log("card was not found");
                    searching = false;
                    return;
                }
            }
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

    public void PlayNoise()
    {
        audio.PlayOneShot(audio.clip);
    }
    
}
