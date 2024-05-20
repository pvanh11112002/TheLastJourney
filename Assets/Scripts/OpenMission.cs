using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMission : MonoBehaviour
{
    [SerializeField] GameObject discription;
    [SerializeField] GameObject status;
    [SerializeField] GameObject fakeStatus;
    private void Start()
    {
        fakeStatus.SetActive(true);
        status.SetActive(false);
    }
    private void Update()
    {
        if(Wincondition.Instance.winCondition)
        {
            status.SetActive(true);
            fakeStatus.SetActive(false) ;
        }
    }
    public void Mission()
    {
        if(!discription.activeSelf)
        {
            discription.SetActive(true);
        }
        else if(discription.activeSelf)
        {
            discription.SetActive(false);
        }
    }
}
