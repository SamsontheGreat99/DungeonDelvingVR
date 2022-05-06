using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

//This script handles the portal that opens in the tavern

public class TPTHATHOPEFULLYWORKS : MonoBehaviour
{
    public GameObject PlayableAreaTP;

    void Update()
    {
        //overriding realtime transform with these hardcoded values
        //this.transform.position = new Vector3(-185.76f,-0.324860f,-48.43687f);
        //this.transform.rotation = new Quaternion(0, 90, 0, 0);
        //this.transform.localScale = new Vector3(155.4265f, 77.71323f, 77.71325f);
        //Finds the playable area tp that is active and sets it as the target
        PlayableAreaTP = GameObject.FindGameObjectWithTag("PlayableAreaTP");
    }

    //teleports the player on trigger enter
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerCharacter")
        {
            other.gameObject.transform.position = PlayableAreaTP.transform.position;
            Debug.Log(PlayableAreaTP.transform.position);
        }
    }
}
