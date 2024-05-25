using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public enum ItemType
    {
        Type1, Type2, Type3, Type4, Type5, Type6,
    }    
    public ItemType itemType;
    public int amount;
}
