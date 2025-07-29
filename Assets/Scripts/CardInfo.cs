using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum CardType
{
    Champion,
    Minion,
    Spell,
    Armament
}

public enum Orders
{
    Death,
    Holy,
    Nature,
    Arcane
}

[Serializable]
public class CardInfo
{
    public string cardName = "";
    public Orders order;
    public CardType type = CardType.Champion;
    public CostData cost;
    public int attack;
    public int defense;
    public int range;

    public string rulesText;

    public Sprite cardArt;
}

[Serializable]
public struct CostData
{
    public int manaCost;
    public int sacrificeCost;
    public int lifeCost;
}

[Serializable]
public struct CardFilterOptions
{
    public bool NoFilter => (ordersIncluded.Count == 0) && (typesIncluded.Count == 0);
    public List<Orders> ordersIncluded;
    public List<CardType> typesIncluded;

    public CardFilterOptions(List<Orders> orders, List<CardType> types)
    {
        ordersIncluded = orders;
        typesIncluded = types;
    }

    public void AddRemoveOrder(Orders order)
    {
        if (ordersIncluded.Contains(order))
        {
            ordersIncluded.RemoveAll(x => x == order);
        }
        else
        {
            ordersIncluded.Add(order);
        }
    }

    public void AddRemoveType(CardType type)
    {
        if (typesIncluded.Contains(type))
        {
            typesIncluded.RemoveAll(x => x == type);
        }
        else
        {
            typesIncluded.Add(type);
        }
    }
}
