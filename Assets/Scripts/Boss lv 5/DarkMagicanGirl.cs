using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class DarkMagicanGirl : Singleton<DarkMagicanGirl>
{
    public GameObject winGame;
    private void Start()
    {
        winGame.SetActive(false);
    }
    private void OnDestroy()
    {
        winGame.SetActive(true);
    }
}
