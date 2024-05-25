using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBoxCoollider : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            GameManager.Instance.currentState = GameState.Pause;
            MainMenuUIManager.Instance.CloseAll();
            MainMenuUIManager.Instance.OpenUI<CanvasFail>();
        }
        
    }
}
