using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//These are the types of items you can have
public enum ItemType
{
    Default,
    Sword,
    Weapon,
    Armor,
    Money,
    Dice,
    Bow,
    Shield
}

public abstract class ItemObject : ScriptableObject
{
    //This is the generice definition for all item objects made
    public GameObject prefab;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;
    public string realtimePrefab;
    public string Name;
}
