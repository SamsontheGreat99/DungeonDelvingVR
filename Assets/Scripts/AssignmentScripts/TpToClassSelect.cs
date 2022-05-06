using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script teleports the players to the room to select their classes
public class TpToClassSelect : MonoBehaviour
{
    public GameObject roomTp;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "XRRIG")
        {
            other.gameObject.transform.position = roomTp.transform.position;
            other.gameObject.GetComponent<XRPlayerController>().speed = 5;
        }
    }
}
