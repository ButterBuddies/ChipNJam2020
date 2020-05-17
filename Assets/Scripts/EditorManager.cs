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
        deck.MakeDeck(deckPanel.transform);
    }

    public void NextLevel()
    {
        Debug.Log("editor manager tryed to load Level" + deck.levelNumber);
        deck.levelNumber++;
        SceneManager.LoadScene("Level" + deck.levelNumber);
    }
}
