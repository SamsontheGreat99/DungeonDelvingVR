using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//This script manages how the player inventory displays on the player UI

public class PlayerInventoryUI : MonoBehaviour
{
    public InventoryObject inventory;

    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BETWEEN_ITEM;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    // Start is called before the first frame update

    private void FindInventory()
    {
        inventory = GameObject.FindGameObjectWithTag("PlayerCharacter").GetComponent<PlayerControls>().inventory;
    }
    //Finds the inventory and creates the display for it
    void Start()
    {
        if(inventory == null)
        {
            FindInventory();
        }
        CreateDisplay();
    }

    // Update is called once per frame

    //Same as Start
    void Update()
    {
        if(inventory == null)
        {
            FindInventory();
        }
        UpdateDisplay();
    }

    //This updates the display by seeing if you have the inventory slot in your inventory and adding it to the display if it isn't there
    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].item.Name;
            }
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, new Quaternion(0, 0, 0, 0), transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].item.Name;
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }

    //This creates the display for the inventory item
    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, new Quaternion(0,0,0,0), transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].item.Name;
            itemsDisplayed.Add(inventory.Container[i], obj);
        }
    }

    //This sends the position that the display is supposed to be
    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), Y_START + (-Y_SPACE_BETWEEN_ITEM * (i / NUMBER_OF_COLUMN)), 0f);
    }
}
