using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    [SerializeField] Transform[] gateToSpawnMons;
    [SerializeField] float elapsedTime;
    [SerializeField] int monsHasSpawn = 0;
    void Update()
    {
        if (monsHasSpawn >= PoolingObject.Instance.numberOfKnight)
        {
            return;
        }    
        elapsedTime += Time.deltaTime;
        if(elapsedTime > 5)
        {
            for (int i = 0; i < gateToSpawnMons.Length; i++)
            {
                GameObject knight = PoolingObject.Instance.GetPooledObjectOfKnight();
                if (knight != null)
                {
                    knight.transform.position = gateToSpawnMons[i].position;
                    //knight.transform.rotation = knight.rotation;
                    knight.SetActive(true);
                }
                monsHasSpawn++;
            }
            elapsedTime = 0;
        }    
    }
}
