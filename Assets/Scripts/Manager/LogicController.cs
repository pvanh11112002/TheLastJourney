using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicController : Singleton<LogicController>
{
    public void PlayerIsDead()
    {
        GameManager.Instance.currentState = GameState.Pause;
        MainMenuUIManager.Instance.CloseAll();
        MainMenuUIManager.Instance.OpenUI<CanvasFail>();
    }
}
