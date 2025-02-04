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
    public Color death;
    public Color holy;
    public Color nature;
    public Color arcane;
    
    public void LoadCardInfo(CardInfo info)
    {
        nameText.text = info.cardName;
        costText.text = info.cost.manaCost.ToString();
        rangeText.text = info.range.ToString();
        rulesText.text = info.rulesText;
        atkText.text = info.attack.ToString();
        defText.text = info.defense.ToString();
        ApplyColorFrame(info.order);
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
}
