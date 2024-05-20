using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show : MonoBehaviour
{
    public int currentLevel;
    
    void Update()
    {
        currentLevel = DataManager.Instance.userData.currentLevel;
    }
}
