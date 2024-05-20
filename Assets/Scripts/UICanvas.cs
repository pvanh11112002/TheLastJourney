using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    [SerializeField] bool isDestroyOnClose = false;
    // Goi truoc khi canvas duoc active
    public virtual void SetUp()
    {
        RectTransform rect = GetComponent<RectTransform>();
        float ratio = (float)Screen.width / (float)Screen.height;
        if(ratio > 2.1f)
        {
            Vector2 lefBottom = rect.offsetMin;
            Vector2 rightTop = rect.offsetMax;

            lefBottom.y = 0f;
            rightTop.y = -100f;

            rect.offsetMin = lefBottom;
            rect.offsetMax = rightTop;
        }    
    }
    // Goi sau khi canvas duoc active
    public virtual void Open()
    {
        gameObject.SetActive(true);
    }
    
    public virtual void Close(float time)
    {
        Invoke(nameof(CloseDirectly), time);
    }
    public virtual void CloseDirectly()
    {
        if(isDestroyOnClose)
        {
            Destroy(gameObject);
        }    
        else
        {
            gameObject.SetActive(false);
        }
        
    }
}
