using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;


//This class assigns a player as the Game Master, gives them the scripts they will need to be the game master, and teleports them to the tavern
public class GMAssignment : MonoBehaviour
{
    //This makes sure only one person can be GM
    public bool hasAssigned = false;
    public GameObject roomTPAnchor;

    public GameObject AvatarPrefab;
    public GameObject realtime;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "XRRIG" && other.gameObject.GetComponent<XRPlayerController>().hasBeenAssigned == false && hasAssigned == false)
        {

            realtime.GetComponent<RealtimeAvatarManager>().localAvatarPrefab = AvatarPrefab;
            other.gameObject.AddComponent<AvatarAttributesSync>();
            other.gameObject.AddComponent<GMControls>();
            other.gameObject.GetComponent<XRPlayerController>().hasBeenAssigned = true;
            hasAssigned = true;
        }
        other.gameObject.tag = "GMCharacter";
        other.gameObject.transform.position = roomTPAnchor.transform.position;
    }
}
