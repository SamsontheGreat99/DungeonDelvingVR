using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Normal.Realtime;

//This script creates and destroys the sword interactable

//Still needs to create the realtime instance with it

public class SwordScript : MonoBehaviour
{
    public GameObject interactableSwordPrefab;
    bool hasBeenInstantiated = false;
    private GameObject SWORD;
    private GameObject realtimeSword;

    private Realtime.InstantiateOptions options;
    private Realtime realtime;

    private void Start()
    {
        realtime = GameObject.FindGameObjectWithTag("Realtime").GetComponent<Realtime>();
        options = new Realtime.InstantiateOptions
        {
            ownedByClient = true,
            preventOwnershipTakeover = true,
            useInstance = realtime,
            destroyWhenLastClientLeaves = true
        };
    }
    public void CreateOrDestroySword()
    {
        if (!hasBeenInstantiated)
        {
            CreateSword();
        }
        else
        {
            DestroySword();
        }
    }
    
    private void CreateSword()
    {
        SWORD = Instantiate(interactableSwordPrefab);
        SWORD.transform.localScale = new Vector3(9, 20, 20);
        SWORD.transform.position = this.transform.position;
        hasBeenInstantiated = true;
        realtimeSword = CreateRealtimeSword(SWORD);
    }
    private void DestroySword()
    {
        Destroy(SWORD);
        Destroy(realtimeSword);
        hasBeenInstantiated = false;
    }
    //Creates a realtime instance of the sword
    private GameObject CreateRealtimeSword(GameObject target)
    {
        GameObject sword = Realtime.Instantiate("NetworkedSword", options);
        sword.GetComponent<NetworkedSword>().target = target;
        return sword;
    }



}
