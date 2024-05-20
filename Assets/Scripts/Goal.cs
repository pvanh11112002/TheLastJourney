using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Goal");
            DataManager.Instance.LevelUp();
            SceneManager.UnloadSceneAsync(DataManager.Instance.userData.currentLevel - 1);
            SceneManager.LoadScene(DataManager.Instance.userData.currentLevel, LoadSceneMode.Additive);
        }
    }
}
