using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


//This code is commented out because it did not work

public class PlayerInitativesUI : MonoBehaviour
{
    public InitiativeInventory initiativeInventory;

    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BETWEEN_ITEM;


    public Dictionary<string, int> itemsDisplayed = new Dictionary<string, int>();

    //public void UpdateDisplay()
    //{
    //    initiativeInventory.Container.Sort()
    //    for (int i = 0; i < initiativeInventory.Container.Count; i++)
    //    {
    //        if (initiativeInventory.Container[i].VALUE)
    //    }
    //}

    //public void CreateDisplay()
    //{
    //    for (int i = 0; i < initiativeInventory.Container.Count; i++)
    //    {
    //        itemsDisplayed.Add(initiativeInventory.Container[i].NAME, initiativeInventory.Container[i].VALUE);
    //    }
    //    for (int i = 0; i < itemsDisplayed.Count; i++)
    //    {
    //        var obj = Instantiate(initiativeInventory.Container[i].prefab, Vector3.zero, new Quaternion(0, 0, 0, 0), transform);
    //        obj.GetComponent<RectTransform>().localPosition
    //    }
    //}
}
