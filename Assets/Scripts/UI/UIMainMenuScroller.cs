using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenuScroller : MonoBehaviour
{
    [SerializeField] private RawImage img;
    [SerializeField] private float x = 0.01f;
    private void Update()
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2(x, 0) * Time.deltaTime, img.uvRect.size);
    }
}
