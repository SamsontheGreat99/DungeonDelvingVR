using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I don't think this works
public class GetPlayersInScene : MonoBehaviour
{
    [SerializeField]
    public static List<GameObject> activePlayers;

    private void Start()
    {
        activePlayers = new List<GameObject>();
    }
    // Update is called once per frame
    public static void AddToActivePlayerList(GameObject go)
    {
        Debug.Log(go);
        activePlayers.Add(go);
        foreach(GameObject p in activePlayers)
        {
            Debug.Log(p);
        }
        Debug.Log(activePlayers.Count);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "PlayerCharacter")
    //    {
    //        AddToActivePlayerList(other.gameObject);
    //    }
    //}
}
