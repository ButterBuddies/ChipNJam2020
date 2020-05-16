using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
