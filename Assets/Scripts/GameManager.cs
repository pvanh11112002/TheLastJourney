using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum GameState
{
    Play, Pause
}
public class GameManager : Singleton<GameManager>
{
    public GameState currentState;
    void Start()
    {
        currentState = GameState.Pause;
        MainMenuUIManager.Instance.OpenUI<CanvasMainMenu>();
    }  

}
