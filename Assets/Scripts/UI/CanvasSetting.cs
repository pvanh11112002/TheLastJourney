using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasSetting : UICanvas
{
    public void MainMenuButton()
    {
        if(SceneManager.GetSceneByBuildIndex(DataManager.Instance.userData.currentLevel).isLoaded)
        {
            SceneManager.UnloadSceneAsync(DataManager.Instance.userData.currentLevel);
        }    
        
        GameManager.Instance.currentState = GameState.Pause;
        MainMenuUIManager.Instance.OpenUI<CanvasMainMenu>();
        MainMenuUIManager.Instance.CloseDirectly<CanvasGamePlay>();
        MainMenuUIManager.Instance.CloseDirectly<CanvasSetting>();
    }
    public void ContinueButton()
    {
        GameManager.Instance.currentState = GameState.Play;
        MainMenuUIManager.Instance.CloseDirectly<CanvasSetting>();
    }    

}
