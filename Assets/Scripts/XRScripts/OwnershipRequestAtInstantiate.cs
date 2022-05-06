using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class OwnershipRequestAtInstantiate : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<RealtimeView>().RequestOwnership();
        this.GetComponent<RealtimeTransform>().RequestOwnership();
    }
    void Update()
    {
        //this.GetComponent<RealtimeView>().RequestOwnership();
        //this.GetComponent<RealtimeTransform>().RequestOwnership();
    }
}
