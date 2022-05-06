using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Weapon Object", menuName = "Inventory System/Items/Weapon")]
public class WeaponObject : ItemObject
{
    //This class defines an object as a weapon
    public float Damage;
    public string displayName;
    private void Awake()
    {
        type = ItemType.Weapon;
    }
}
