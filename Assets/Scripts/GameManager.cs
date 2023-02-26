using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// TODO: Add prices to the structures, and give limited stock that refills every 30 seconds.
// TODO: Add more context.
// TODO: Detail the process journal more.

public class GameManager : MonoBehaviour
{
    public int gold;
    public int electricity;
    public int air;
    public TextMeshProUGUI goldDisplay;
    public TextMeshProUGUI electricityDisplay;
    public TextMeshProUGUI airDisplay;
    public string goldPrefix;
    public string elecPrefix;
    public string airPrefix;

    private Building buildingToPlace;
    public GameObject grid;
    public Color positiveColor = Color.white;
    public Color negativeColor = Color.red;
    public Color positiveColorElec = Color.white;
    public Color negativeColorElec = Color.red;
    public Color positiveColorAir = Color.white;
    public Color negativeColorAir = Color.red;

    public CustomCursor customCursor;

    public Tile[] tiles;


    private void Update()
    {
        goldDisplay.text = gold.ToString() + goldPrefix;
        electricityDisplay.text = electricity.ToString() + elecPrefix;
        airDisplay.text = air.ToString() + airPrefix;

        if (Input.GetMouseButtonDown(0) && buildingToPlace != null)
        {
            Tile nearestTile = null;
            float shortestDistance = float.MaxValue;
            foreach(Tile tile in tiles)
            {
                float dist = Vector2.Distance(tile.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (dist < shortestDistance)
                {
                    shortestDistance = dist;
                    nearestTile = tile;
                }
            }
            if (nearestTile.isOccupied == false)
            {
                Instantiate(buildingToPlace, nearestTile.transform.position, Quaternion.identity);
                buildingToPlace = null;
                nearestTile.isOccupied = true;
                grid.SetActive(false);
                customCursor.gameObject.SetActive(false);
                Cursor.visible = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (gold <= 0)
        {
            goldDisplay.color = negativeColor;
        }
        else if (gold > 0)
        {
            goldDisplay.color = positiveColor;
        }
        if (electricity <= 0)
        {
            electricityDisplay.color = negativeColorElec;
        }
        else if (electricity > 0)
        {
            electricityDisplay.color = positiveColorElec;
        }
        if (air <= 0)
        {
            airDisplay.color = negativeColorAir;
        }
        else if (air > 0)
        {
            airDisplay.color = positiveColorAir;
        }
    }

    public void BuyBuilding(Building building)
    {
        if (gold >= building.cost)
        {
            customCursor.gameObject.SetActive(true);
            customCursor.GetComponent<SpriteRenderer>().sprite = building.GetComponent<SpriteRenderer>().sprite;
            Cursor.visible = false;

            gold -= building.cost;
            buildingToPlace = building;
            grid.SetActive(true);
        }
    }
}
