using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class BowScript : MonoBehaviour
{
    public GameObject interactableBowPrefab;
    private GameObject BOW;
    private GameObject RealtimeBow;
    private bool hasBeenCreated = false;

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

    public void CreateOrDestroyBow()
    {
        if (!hasBeenCreated)
        {
            CreateBow();
        }
        else
        {
            DestroyBow();
        }
    }

    private void CreateBow()
    {
        BOW = Instantiate(interactableBowPrefab);
        BOW.transform.localScale = new Vector3(35,35,35);
        BOW.transform.position = this.transform.position;
        hasBeenCreated = true;
        RealtimeBow = CreateRealtimeBow(BOW);
    }
    private void DestroyBow()
    {
        Destroy(BOW);
        Realtime.Destroy(RealtimeBow);
        hasBeenCreated = false;
    }

    private GameObject CreateRealtimeBow(GameObject target)
    {
        GameObject bow = Realtime.Instantiate("NetworkedBow", options);
        bow.GetComponent<NetworkedBow>().target = target;
        return bow;
    }
}
