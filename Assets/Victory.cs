using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    private GameManager gm;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if(gm.air >= 100 || Input.GetKeyDown(KeyCode.J))
        {
            SceneManager.LoadScene("VictoryScene");
        }
    }
}
