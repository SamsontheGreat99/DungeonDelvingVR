using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreateInitiative : MonoBehaviour
{
    //This script needs work
    //I need to send the initiative value from the local player to the network player owned locally and use that number and nickname to display the initiative, will probably be able to order it too

    //public GameObject[] players = GetPlayersInScene.activePlayers;
    public List<GameObject> players = GetPlayersInScene.activePlayers;
    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BETWEEN_ITEM;

    [SerializeField]
    public static Dictionary<string, int> initiative = new Dictionary<string, int>();

    public void DisplayInitialInitiative()
    {
        for(int i = 0; i < initiative.Keys.Count; i++)
        {
            var obj = Instantiate(Resources.Load("InitiativeUI")) as GameObject;
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
           // obj.GetComponent<TextMeshProUGUI>().text = 

        }

    }
    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), Y_START + (-Y_SPACE_BETWEEN_ITEM * (i / NUMBER_OF_COLUMN)), 0f);
    }
}
