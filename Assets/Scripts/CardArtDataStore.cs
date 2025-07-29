using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Card Art Data", menuName = "Cards/Card Art Data")]
public class CardArtDataStore : ScriptableObject
{
    public List<CardArt> cardArtList;

    [Button]
    public void RefreshList()
    {
        foreach (var card in JSONCardReader.MasterList)
        {
            if(cardArtList.FirstOrDefault(n => n.cardName == card.cardName) == null)
            {
                cardArtList.Add(new CardArt(card.cardName));
            }
        }
    }
}

[System.Serializable]
public class CardArt
{
    public string cardName;
    [FormerlySerializedAs("image")] public Sprite cardImage;

    public CardArt(string in_cardName)
    {
        cardName = in_cardName;
    }
}