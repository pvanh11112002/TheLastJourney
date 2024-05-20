using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIManager : Singleton<MainMenuUIManager>
{
    Dictionary<System.Type, UICanvas> canvasActives = new Dictionary<System.Type, UICanvas>();
    Dictionary<System.Type, UICanvas> canvasPrefabs = new Dictionary<System.Type, UICanvas>();
    [SerializeField] Transform parent;
    private void Start()
    {
        UICanvas[] prefabs = Resources.LoadAll<UICanvas>("UI/");
        for (int i = 0; i < prefabs.Length; i++)
        {
            canvasPrefabs.Add(prefabs[i].GetType(), prefabs[i]);
        }
    }
    //Mo canvas
    public T OpenUI<T>() where T : UICanvas
    {
        T canvas = GetUI<T>();
        canvas.SetUp();
        canvas.Open();
        return canvas;
    }
    // Dong canvas
    public void CloseUI<T>(float time) where T : UICanvas
    {
        if (isLoaded<T>())
        {
            canvasActives[typeof(T)].Close(time);
        }
    }
    // Dong canvas luon
    public void CloseDirectly<T>() where T : UICanvas
    {
        if (isLoaded<T>())
        {
            canvasActives[typeof(T)].CloseDirectly();
        }
    }
    // Kiem tra xem canvas co duoc tai chua
    public bool isLoaded<T>() where T : UICanvas
    {
        return canvasActives.ContainsKey(typeof(T)) && canvasActives[typeof(T)] != null;
    }
    // Kiem tra xem canvas active chua
    public bool isOpened<T>() where T : UICanvas
    {
        return isLoaded<T>() && canvasActives[typeof(T)].gameObject.activeSelf;
    }
    // Lay Canvas
    public T GetUI<T>() where T : UICanvas
    {
        if (!isLoaded<T>())
        {
            T prefab = GetUIPrefabs<T>();
            T canvas = Instantiate(prefab, parent);
            canvasActives[typeof(T)] = canvas;
        }
        return canvasActives[typeof(T)] as T;
    }
    private T GetUIPrefabs<T>() where T : UICanvas
    {

        return canvasPrefabs[typeof(T)] as T;
    }
    public void CloseAll()
    {
        foreach (var canvas in canvasActives)
        {
            if (canvas.Value != null && canvas.Value.gameObject.activeSelf)
            {
                canvas.Value.Close(0);
            }
        }
    }
}
