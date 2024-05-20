using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodTower : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            MainMenuUIManager.Instance.CloseAll();
            MainMenuUIManager.Instance.OpenUI<CanvasVictory>();
        }    
        
    }
}
