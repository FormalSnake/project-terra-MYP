using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isOccupied;

    public Color vacantColor;
    public Color occupiedColor;

    private SpriteRenderer rend;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isOccupied == true)
        {
            rend.color = occupiedColor;
        }
        else
        {
            rend.color = vacantColor;
        }
    }
}
