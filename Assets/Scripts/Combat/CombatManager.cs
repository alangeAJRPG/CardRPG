using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class CombatManager : MonoBehaviour
{
    public CardListDecorator handDecorator;
    public List<CardInfo> hand;
    public CombatDeck deck;

    public void Start()
    {
        deck.InitializeDeck();
        //handDecorator.ApplyCustomList(deck.CurrentDeck);
    }
    
    [Button]
    public void Draw()
    {
        hand.AddRange(deck.Draw(1));
        handDecorator.ApplyCustomList(hand);
    }

    [Button]
    public void Shuffle()
    {
        deck.Shuffle();
    }
}


[System.Serializable]
public class CombatDeck
{
    public List<CARD_IDS> deckList ;
    private List<CardInfo> _startingDeck = new List<CardInfo>();
    private List<CardInfo> _currentDeck = new List<CardInfo>();

    public List<CardInfo> CurrentDeck => _currentDeck;

    public void InitializeDeck()
    {
        _startingDeck.Clear();
        _startingDeck.AddRange(JSONCardReader.GetCardListFromIDs(deckList));
        _currentDeck.Clear();
        _currentDeck.AddRange(_startingDeck);
    }

    public List<CardInfo> Draw(int x)
    {
        List<CardInfo> drawnCards = new List<CardInfo>();

        for (int i = 0; i < x; i++)
        {
            if (_currentDeck.Count > 0)
            {
                drawnCards.Add(_currentDeck[0]);
                _currentDeck.RemoveAt(0);
            }
        }

        return drawnCards;  
    }

    public void Shuffle()
    {
        _currentDeck.Shuffle();
    }
}