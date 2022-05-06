using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Dice Object", menuName = "Inventory System/Items/Dice")]

public class DiceObject : ItemObject
{
    //This defines the characteristics of a Dice Object
    public int sides;
    public string displayName;
    private void Awake()
    {
        type = ItemType.Dice;
    }
}
