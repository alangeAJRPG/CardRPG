using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDecorator : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text costText;
    public TMP_Text rangeText;
    public TMP_Text rulesText;
    public TMP_Text atkText;
    public TMP_Text defText;

    [Space] public Image frameRend;
    public Image cardArt;
    public Color death;
    public Color holy;
    public Color nature;
    public Color arcane;
    [Header("Font Options")]
    public Color deathFont;
    public Color holyFont;
    public Color natureFont;
    public Color arcaneFont;
    
    public void LoadCardInfo(CardInfo info)
    {
        nameText.text = info.cardName;
        costText.text = info.cost.manaCost.ToString();
        rangeText.text = info.range.ToString();
        rulesText.text = info.rulesText;
        atkText.text = info.attack.ToString();
        defText.text = info.defense.ToString();
        cardArt.sprite = info.cardArt != null ? info.cardArt : null;
        
        ApplyColorFrame(info.order);
        ApplyFontColor(info.order);
    }
    
    private void ApplyColorFrame(Orders order)
    {
        switch (order)
        {
            case (Orders.Death):
                frameRend.color = death;
                break;
            case (Orders.Holy):
                frameRend.color = holy;
                break;
            case (Orders.Nature):
                frameRend.color = nature;
                break;
            case (Orders.Arcane):
                frameRend.color = arcane;
                break;
        }
    }

    private void ApplyFontColor(Orders order)
    {
        Color fontColor = Color.white;
        switch (order)
        {
            case (Orders.Death):
                fontColor = deathFont;
                break;
            case (Orders.Holy):
                fontColor = holyFont;
                break;
            case (Orders.Nature):
                fontColor = natureFont;
                break;
            case (Orders.Arcane):
                fontColor = arcaneFont;
                break;
        }
        nameText.color = fontColor;
        costText.color = fontColor;
        atkText.color = fontColor;
        defText.color = fontColor;
        rangeText.color = fontColor;
        rulesText.color = fontColor;
    }
}
