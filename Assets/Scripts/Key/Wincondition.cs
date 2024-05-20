using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wincondition : Singleton<Wincondition>
{
    public bool winCondition = false;   
    [SerializeField] GameObject goal;
    [SerializeField] GameObject itemFatherToPick;
    private void Start()
    {
        goal.SetActive(false);
    }
    private void Update()
    {
        if (itemFatherToPick.transform.childCount == 0)
        {
            winCondition = true;
        }
        if(winCondition) { goal.SetActive(true); }
    }
    
}
