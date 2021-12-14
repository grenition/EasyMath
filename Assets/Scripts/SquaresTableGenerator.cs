using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquaresTableGenerator : MonoBehaviour
{
    [SerializeField] private Tile tilePrefab;

    [SerializeField] private Color defaultColor;
    [SerializeField] private Color sideColor;

    private void Start()
    {
        GenerateTiles();
    }
    private void GenerateTiles()
    {
        if (tilePrefab == null)
            return;
        float curValue = 0f;
        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                Tile generated = Instantiate(tilePrefab, transform);
                if (j == 0 && i == 0) generated.Text = string.Empty;
                else if (j == 0) generated.Text = (i - 1).ToString();
                else if (i == 0) generated.Text = (j - 1).ToString();
                else
                {
                    generated.Text = (curValue * curValue).ToString();
                    curValue++;
                }
            }
        }
    }
}
