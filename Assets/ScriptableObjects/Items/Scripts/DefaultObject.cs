using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Default")]
public class DefaultObject : ItemObject
{
    //This sets the type of the default objectr
   public void Awake()
    {
        type = ItemType.Default;
    }
}
