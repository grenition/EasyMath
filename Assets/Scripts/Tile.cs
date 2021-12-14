using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [SerializeField] private Text textInfo;
    [SerializeField] private Image image;

    public string Text
    {
        get => textInfo.text;
        set
        {
            if (textInfo == null)
                return;
            textInfo.text = value;
        }
    }

    public Color ColorTile
    {
        get => image.color;
        set
        {
            if (image.color == null)
                return;

            image.color = value;
        }
    }
}
