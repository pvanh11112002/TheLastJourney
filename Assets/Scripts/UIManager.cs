﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;

public class UIManager : Singleton<UIManager>
{
    public GameObject damageTextPrefabs;
    public GameObject healthTextPrefabs;
    public Canvas gameCanvas;

    
    private void Awake()
    {
        gameCanvas= FindObjectOfType<Canvas>();

        
    }
    private void OnEnable()
    {
        CharacterEvents.characterDamaged += CharacterTookDamage;
        CharacterEvents.characterHealed += CharacterHealed;
    }
    private void OnDisable()
    {
        CharacterEvents.characterDamaged -= CharacterTookDamage;
        CharacterEvents.characterHealed -= CharacterHealed;
    }
    public void CharacterTookDamage(GameObject character, int damageReceived)
    {
        // Khi obj chủ thể get hit, cta muốn có chữ nhảy ra trên đầu nơi vật thể đứng
        // tạo ra biến spawnPos, đây là lấy vị trí của nhân vật (vì nhân vật đang làm tâm của camera)
        //WorldToScreenPoints nhận vào giá trị là một vector 3 và trả về 1 vector 3, ở đây là chuyển từ hệ tọa độ trong thế giới game thành hệ tọa độ trên màn hình 
        Vector3 spawnPos = Camera.main.WorldToScreenPoint(character.transform.position);
        // tạo ra 1 bản sao của vật thể được truyền vào, Instantiate truyền vào các giá trị bao gồm
        // original: vật thể muốn tạo ra bản copy
        // position: vị trí của obj mới
        // rotation: hướng quay của vật thể mới, trong bài này .identity = no rotations
        // parent: căn nguyên sẽ được gắn cho vật thể mới copy này
        TMP_Text tmpText = Instantiate(damageTextPrefabs, spawnPos, Quaternion.identity, gameCanvas.transform).GetComponent<TMP_Text>();
        // set cho giá trị của text đấy thành dame nhận vào
        tmpText.text = damageReceived.ToString();
    }   
    public void CharacterHealed(GameObject character, int healthRestored)
    {
        // như trên, i sỳ
        Vector3 spawnPos = Camera.main.WorldToScreenPoint(character.transform.position);
        TMP_Text tmpText = Instantiate(healthTextPrefabs, spawnPos, Quaternion.identity, gameCanvas.transform).GetComponent<TMP_Text>();
        tmpText.text = healthRestored.ToString();
    }
    //public void OnEscape(InputAction.CallbackContext context)
    //{
    //    if(context.started)
    //    {
    //        #if (UNITY_EDITOR || DEVELOPMENT_BUILD)
    //            Debug.Log(this.name + " : " + this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
    //        #endif

    //        #if (UNITY_EDITOR)
    //                UnityEditor.EditorApplication.isPlaying= false;
    //        #elif (UNITY_STANDALONE)
    //                Application.Quit();
    //        #elif (UNITY_WEBGL)
    //                SceneManager.LoadScene("QuitScene");
    //        #endif
    //    }
    //}

    // Mo canvas
    //public T OpenUI<T>() where T : UICanvas
    //{
    //    T canvas = GetUI<T>();
    //    canvas.SetUp();
    //    canvas.Open();
    //    return canvas;
    //}
    //// Dong canvas
    //public void CloseUI<T>(float time) where T : UICanvas
    //{
    //    if(isLoaded<T>())
    //    {
    //        canvasActives[typeof(T)].Close(time);
    //    }    
    //}
    //// Dong canvas luon
    //public void CloseDirectly<T>() where T : UICanvas
    //{
    //    if (isLoaded<T>())
    //    {
    //        canvasActives[typeof(T)].CloseDirectly();
    //    }
    //}
    //// Kiem tra xem canvas co duoc tai chua
    //public bool isLoaded<T>() where T : UICanvas
    //{
    //    return canvasActives.ContainsKey(typeof(T)) && canvasActives[typeof(T)] != null;
    //}
    //// Kiem tra xem canvas active chua
    //public bool isOpened<T>() where T : UICanvas
    //{
    //    return isLoaded<T>() && canvasActives[typeof(T)].gameObject.activeSelf;
    //}
    //// Lay Canvas
    //public T GetUI<T>() where T : UICanvas
    //{
    //    if(!isLoaded<T>())
    //    {
    //        T prefab = GetUIPrefabs<T>();
    //        T canvas = Instantiate(prefab, parent);
    //        canvasActives[typeof(T)] = canvas;
    //    }    
    //    return canvasActives[typeof(T)] as T;
    //}   
    //private T GetUIPrefabs<T>() where T : UICanvas
    //{
        
    //    return canvasPrefabs[typeof(T)] as T;
    //}    
    //public void CloseAll()
    //{
    //    foreach (var canvas in canvasActives)
    //    {
    //        if(canvas.Value != null && canvas.Value.gameObject.activeSelf)
    //        {
    //            canvas.Value.Close(0);
    //        }    
    //    }    
    //}    

}
