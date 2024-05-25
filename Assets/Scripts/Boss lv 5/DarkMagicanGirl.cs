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
        if (winGame != null)
        {
            winGame.SetActive(true);
        }
    }
    public void MagicAttack()
    {
        SoundManager.Instance.Play("Magic Attack");
    }
}
