using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasVictory : UICanvas
{
    public void MainMenuButton()
    {
        Close(0);
        MainMenuUIManager.Instance.OpenUI<CanvasMainMenu>();
    }
}
