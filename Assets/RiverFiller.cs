using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class RiverFiller : MonoBehaviour
{
    public Tilemap tilemap;
    public Color beforeColor;
    public Color afterColor;
    //public float divisor;
    private GameManager gm;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        //light2D.color = Color.Lerp(nightColor, dayColor, Mathf.PingPong(Time.time, dayLength));
        //if(gm.air >= 50)
        //{
            Color alpha = afterColor;
            alpha.a = gm.air;
            tilemap.color = alpha;
            Debug.Log(gm.air);
        //}
    }
}
