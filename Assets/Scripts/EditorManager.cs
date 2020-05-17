﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonCall(bool add)
    {
        deck.EditDeck(add);
    }

    public void NextLevel()
    {
        deck.levelNumber++;
        SceneManager.LoadScene(deck.levelNumber);
    }
}
