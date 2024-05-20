using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingObject : Singleton<PoolingObject>
{
    public GameObject monsterCollection;
    private List<GameObject> knightPooled = new List<GameObject>();
    public GameObject knightPrefabs;
    public int numberOfKnight = 10;
    
    void Start()
    {
        for (int j = 0; j < numberOfKnight; j++)
        {
            GameObject objBot = Instantiate(knightPrefabs,monsterCollection.transform);
            objBot.SetActive(false);
            knightPooled.Add(objBot);
        }
    }
    public GameObject GetPooledObjectOfKnight()
    {
        for(int i = 0; i < knightPooled.Count; i++)
        {
            if (!knightPooled[i].activeInHierarchy)
            {
                return knightPooled[i];
            }            
        }
        return null;
    }
}
