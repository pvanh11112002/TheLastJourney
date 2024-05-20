using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDiscription : MonoBehaviour
{
    [SerializeField] GameObject discription;
    public void Description()
    {
        if (!discription.activeSelf)
        {
            discription.SetActive(true);
        }
        else if (discription.activeSelf)
        {
            discription.SetActive(false);
        }
    }
}
