using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using TMPro;

//This script creates the castle portal locally and then creates it on the server, it also handles destroying it

public class CastlePortal : MonoBehaviour
{
    private Realtime realtime;
    private Realtime.InstantiateOptions options;
    private bool trash = false;
    public GameObject portal;
    public TextMeshProUGUI portalText;
    // Start is called before the first frame update
    void Start()
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
    public void TPPortalSpawn()
    {
        if (!trash)
        {
            portal = Realtime.Instantiate("CastlePortal", options);
            portalText.text = "Close Portal";
            trash = true;
        }
        else
        {
            Realtime.Destroy(portal);
            portalText.text = "Open Portal";
            trash = false;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
