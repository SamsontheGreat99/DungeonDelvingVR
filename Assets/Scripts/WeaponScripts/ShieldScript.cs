using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class ShieldScript : MonoBehaviour
{
    public GameObject interactableShieldPrefab;
    private GameObject SHIELD;
    private GameObject RealtimeShield;
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

    public void CreateOrDestroyShield()
    {
        if (!hasBeenCreated)
        {
            CreateShield();
        }
        else
        {
            DestroyShield();
        }
    }

    private void CreateShield()
    {
        SHIELD = Instantiate(interactableShieldPrefab);
        SHIELD.transform.localScale = new Vector3(15, 15, 15);
        SHIELD.transform.position = this.transform.position;
        hasBeenCreated = true;
        RealtimeShield = CreateRealtimeShield(SHIELD);
    }
    private void DestroyShield()
    {
        Destroy(SHIELD);
        Realtime.Destroy(RealtimeShield);
        hasBeenCreated = false;
    }

    private GameObject CreateRealtimeShield(GameObject target)
    {
        GameObject shield = Realtime.Instantiate("NetworkedShield", options);
        shield.GetComponent<NetworkedShield>().target = target;
        return shield;
    }
}
