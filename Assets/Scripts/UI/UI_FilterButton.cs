using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_FilterButton : MonoBehaviour
{
    public Image uiImage;
    public Color defaultColor;
    public Color selectedColor;

    public void Start()
    {
        uiImage.color = defaultColor;
    }

    public void ToggleSelected()
    {
        if (uiImage.color == defaultColor)
        {
            uiImage.color = selectedColor;
        }
        else
        {
            uiImage.color = defaultColor;
        }
    }
}
