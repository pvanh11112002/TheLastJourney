using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasFail : UICanvas
{
    public void MainMenuButton()
    {
        Close(0);
        SceneManager.UnloadSceneAsync(DataManager.Instance.userData.currentLevel);
        MainMenuUIManager.Instance.OpenUI<CanvasMainMenu>();
    }
}
