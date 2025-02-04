using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization; 

public class JSONCardReader : MonoBehaviour
{
    public TextAsset textJSON;
    
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

    private void LoadMasterList()
    {
        MasterList.AddRange(fromJsonList.DeathCards.ToList());
        MasterList.AddRange(fromJsonList.HolyCards.ToList());
        MasterList.AddRange(fromJsonList.NatureCards.ToList());
        MasterList.AddRange(fromJsonList.ArcaneCards.ToList());

        DeathList.AddRange(fromJsonList.DeathCards.ToList());
        HolyList.AddRange(fromJsonList.HolyCards.ToList());
        NatureList.AddRange(fromJsonList.NatureCards.ToList());
        ArcaneList.AddRange(fromJsonList.ArcaneCards.ToList());
    }
}