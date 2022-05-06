using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class PlayerAssignment : MonoBehaviour
{
    public static PlayerClass CLASS;
    public GameObject roomTPAnchor;
    public GameObject AvatarPrefab;
    public GameObject realtime;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGERED");
        if (other.gameObject.tag == "XRRIG" /*&& other.gameObject.GetComponent<XRPlayerController>().hasBeenAssigned == false*/)
        {

            GameObject playerClass = other.transform.GetChild(0).GetChild(0).gameObject;

            if(this.gameObject.tag == "FighterSelection")
            {
                realtime.GetComponent<RealtimeAvatarManager>().localAvatarPrefab = AvatarPrefab;
                other.gameObject.AddComponent<AvatarAttributesSync>();
                //other.gameObject.GetComponent<RealtimeAvatarManager>().localAvatarPrefab =AvatarPrefab;
                //Debug.Log("TRIGGEREDBUTASAFIGHTER");
                CLASS = PlayerClass.Fighter;
                playerClass.AddComponent<FighterClass>();
            }
            else if(this.gameObject.tag == "BarbarianSelection")
            {
                realtime.GetComponent<RealtimeAvatarManager>().localAvatarPrefab = AvatarPrefab;
                other.gameObject.AddComponent<AvatarAttributesSync>();
                CLASS = PlayerClass.Barbarian;
                playerClass.AddComponent<BarbarianClass>();
            }
            else if (this.gameObject.tag == "PaladinSelection")
            {
                realtime.GetComponent<RealtimeAvatarManager>().localAvatarPrefab = AvatarPrefab;
                other.gameObject.AddComponent<AvatarAttributesSync>();
                CLASS = PlayerClass.Paladin;
                playerClass.AddComponent<PaladinClass>();
            }
            else if (this.gameObject.tag == "RangerSelection")
            {
                realtime.GetComponent<RealtimeAvatarManager>().localAvatarPrefab = AvatarPrefab;
                other.gameObject.AddComponent<AvatarAttributesSync>();
                CLASS = PlayerClass.Ranger;
                playerClass.AddComponent<RangerClass>();
            }

            other.gameObject.AddComponent<PlayerControls>();
            other.gameObject.GetComponent<XRPlayerController>().hasBeenAssigned = true;
            other.gameObject.transform.position = roomTPAnchor.transform.position;
            //other.gameObject.transform.localScale = new Vector3(65, 65, 65);
            other.gameObject.GetComponent<XRPlayerController>().speed = 5;
            other.gameObject.tag = "PlayerCharacter";
            //GetPlayersInScene.AddToActivePlayerList(other.gameObject);
        }
    }
}
public enum PlayerClass
{
    Fighter,
    Barbarian,
    Paladin,
    Ranger
}
