using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Control Play Music for each scene and win condition
public class Wincondition : Singleton<Wincondition>
{
    public bool winCondition = false;   
    [SerializeField] GameObject goal;
    [SerializeField] GameObject itemFatherToPick;
    private void Start()
    {
        SoundManager.Instance.StopAll();
        goal.SetActive(false);
        switch(DataManager.Instance.userData.currentLevel)
        {
            case 1:
                SoundManager.Instance.Play("Mornach Lounge");
                break;
            case 2:
                SoundManager.Instance.Play("Fog Forrest");
                break;
            case 3:
                SoundManager.Instance.Play("Silent Cave");
                break;
            case 4:
                SoundManager.Instance.Play("Mysterious Swamp");
                break;
            case 5:
                SoundManager.Instance.Play("Void Tower");
                break;

        }    
        
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
