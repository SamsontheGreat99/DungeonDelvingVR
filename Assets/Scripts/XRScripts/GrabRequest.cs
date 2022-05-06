using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabRequest : MonoBehaviour
{
    private RealtimeTransform realTimeTransform;
    private XRGrabInteractable grabInteractable;
    // Start is called before the first frame update
    void Start()
    {
        realTimeTransform = GetComponent<RealtimeTransform>();
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(grabInteractable.isSelected)
        {
            realTimeTransform.RequestOwnership();
        }
        //if someone else has ownership, we cannot move the object
        else if(realTimeTransform.ownerID != 0)
        {
            realTimeTransform.ClearOwnership();
        }
    }
}
