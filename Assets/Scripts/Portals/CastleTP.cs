using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleTP : MonoBehaviour
{
    //This Script is for the Portal that will be opened in the castle

    public GameObject tavernTP;

    void Update()
    {
        // overriding the realtime transform and keeping it in the place we want it
        //this.transform.position = new Vector3(-219.4588f, 32.15f, -65.778f);
        //this.transform.rotation = new Quaternion(0, 180, 0, 0);
        //this.transform.localScale = new Vector3(128.3605f, 64.18024f, 64.18027f);

        // finding the tavern teleport spot
        tavernTP = GameObject.FindGameObjectWithTag("TavernTP");
    }
    private void OnTriggerEnter(Collider other)
    {
        //finding the players and teleporting them back to the tavern
        if (other.gameObject.tag == "PlayerCharacter")
        {
            other.gameObject.transform.position = tavernTP.transform.position;
            Debug.Log(tavernTP.transform.position);
        }
    }
}
