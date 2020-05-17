using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EditorManager : MonoBehaviour
{
    Deck deck;
    public GameObject deckPanel;
    // Start is called before the first frame update
    void Start()
    {
        deck = FindObjectOfType<Deck>();
        deck.CleanUp();
        if (deck.addedCards.Count > 0)
        {
            foreach (GameObject obj in deck.addedCards)
            {
                deck.cardsInDeck.Add(obj);
            }
        }
        OpenPack();
        deck.MakeDeck(deckPanel.transform);
    }

    public void NextLevel()
    {
        Debug.Log("editor manager tryed to load Level" + deck.levelNumber);
        deck.levelNumber++;
        SceneManager.LoadScene("Level" + deck.levelNumber);
    }

    public void OpenPack()
    {
        for (int i = 0; i < 4; i++)
        {
            deck.EditDeck(deck.listOfCardPrefabs[Random.Range(4, 8)], true);
        }
    }
}
