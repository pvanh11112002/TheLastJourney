using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CanvasMainMenu : UICanvas
{
    public void PlayButton()
    {
        MainMenuUIManager.Instance.OpenUI<CanvasGamePlay>();
        GameManager.Instance.currentState = GameState.Play;
        SceneManager.LoadScene(DataManager.Instance.userData.currentLevel, LoadSceneMode.Additive);
        
        Close(0);
        
    }
    public void SettingButton()
    {
        MainMenuUIManager.Instance.OpenUI<CanvasSetting>();
    }
}
