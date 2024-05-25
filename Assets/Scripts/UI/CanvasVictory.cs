using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasVictory : UICanvas
{
    public float countdownDuration = 5f;
    [SerializeField] TextMeshProUGUI countdownText;
    private float currentTime;
    private void Start()
    {
        currentTime = countdownDuration;
        SoundManager.Instance.StopAll();
        
    }
    private void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateCountdownText();
        }
        else
        {
            DataManager.Instance.ResetData();
            Application.Quit();
            Debug.Log("Thời gian đếm ngược đã kết thúc!");
        }
    }

    private void UpdateCountdownText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
