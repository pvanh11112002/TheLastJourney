using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasGamePlay : UICanvas
{
    
    public void SettingButton()
    {
        GameManager.Instance.currentState = GameState.Pause;
        MainMenuUIManager.Instance.OpenUI<CanvasSetting>();
    }
}
