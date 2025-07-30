using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization; 

public class JSONCardReader : MonoBehaviour
{
    public TextAsset textJSON;
    public CardArtDataStore artData;
    
    public static readonly List<CardInfo> MasterList = new List<CardInfo>();
    public static readonly List<CardInfo> DeathList = new List<CardInfo>();
    public static readonly List<CardInfo> HolyList = new List<CardInfo>();
    public static readonly List<CardInfo> NatureList = new List<CardInfo>();
    public static readonly List<CardInfo> ArcaneList = new List<CardInfo>();

    [System.Serializable]
    public class CardList
    {
        public CardInfo[] DeathCards;
        public CardInfo[] HolyCards;
        public CardInfo[] NatureCards;
        public CardInfo[] ArcaneCards;
    }

    private static CardList fromJsonList = new CardList(); 

    private void Awake()
    {
        fromJsonList = JsonUtility.FromJson<CardList>(textJSON.text);
        LoadMasterList();
    }

    public static List<CardInfo> GetCardListFromIDs(List<CARD_IDS> deckList)
    {
        List<CardInfo> result = new List<CardInfo>();
        
        foreach (var id in deckList)
        {
            result.Add(MasterList.FirstOrDefault(card => card.cardID == (int)id));
        }

        return result;
    }
    
    private void LoadMasterList()
    {
        FetchCardArt();
        
        MasterList.AddRange(fromJsonList.DeathCards.ToList());
        MasterList.AddRange(fromJsonList.HolyCards.ToList());
        MasterList.AddRange(fromJsonList.NatureCards.ToList());
        MasterList.AddRange(fromJsonList.ArcaneCards.ToList());

        DeathList.AddRange(fromJsonList.DeathCards.ToList());
        HolyList.AddRange(fromJsonList.HolyCards.ToList());
        NatureList.AddRange(fromJsonList.NatureCards.ToList());
        ArcaneList.AddRange(fromJsonList.ArcaneCards.ToList());
        
    }

    private void FetchCardArt()
    {
        for (int i = 0; i < fromJsonList.DeathCards.Length; i++)
        {
            CardArt s = artData.cardArtList.FirstOrDefault(art => art.cardName == fromJsonList.DeathCards[i].cardName);

            if (s != null)
            {
                fromJsonList.DeathCards[i].cardArt = s.cardImage;
            }
        }
        
        for (int i = 0; i < fromJsonList.HolyCards.Length; i++)
        {
            CardArt s = artData.cardArtList.FirstOrDefault(art => art.cardName == fromJsonList.HolyCards[i].cardName);

            if (s != null)
            {
                fromJsonList.HolyCards[i].cardArt = s.cardImage;
            }
        }
        
        for (int i = 0; i < fromJsonList.NatureCards.Length; i++)
        {
            CardArt s = artData.cardArtList.FirstOrDefault(art => art.cardName == fromJsonList.NatureCards[i].cardName);

            if (s != null)
            {
                fromJsonList.NatureCards[i].cardArt = s.cardImage;
            }
        }
        
        for (int i = 0; i < fromJsonList.ArcaneCards.Length; i++)
        {
            CardArt s = artData.cardArtList.FirstOrDefault(art => art.cardName == fromJsonList.ArcaneCards[i].cardName);

            if (s != null)
            {
                fromJsonList.ArcaneCards[i].cardArt = s.cardImage;
            }
        }
    }
}