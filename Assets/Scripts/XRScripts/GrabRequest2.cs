using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabRequest2 : MonoBehaviour
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
        else if(!grabInteractable.isSelected)
        {
            realTimeTransform.ClearOwnership();
        }
        //if someone else has the object, then stop requesting ownership
        else
        {
            realTimeTransform.ClearOwnership();
        }  

    }
}
