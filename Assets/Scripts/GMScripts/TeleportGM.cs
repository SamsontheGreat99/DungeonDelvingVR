using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportGM : MonoBehaviour
{
    public GameObject GM;
    public Transform TavernTP;
    public Transform PlayableAreaTP;

    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GMCharacter");
        TavernTP = GameObject.FindGameObjectWithTag("TavernTP").transform;
    }

    public void TeleportGMToAndFromBoard()
    {
        if (GM.GetComponent<GMControls>().state == GMControls.PlayerState.InRoom)
        {
            Debug.Log("ToBoard");
            PlayableAreaTP = GameObject.FindGameObjectWithTag("GMTP").transform;

            if(PlayableAreaTP != null)
            {
                GM.transform.position = PlayableAreaTP.position;
                GM.GetComponent<GMControls>().state = GMControls.PlayerState.OnBoard;
            }
           
            //StartCoroutine("ToBoard");
        }
        else if (GM.GetComponent<GMControls>().state == GMControls.PlayerState.OnBoard)
        {
            StartCoroutine("ToRoom");
        }
    }
    IEnumerator ToBoard()
    {
        Debug.Log("ToBoard");

        PlayableAreaTP = GameObject.FindGameObjectWithTag("GMTP").transform;

        GM.transform.position = PlayableAreaTP.localPosition;
        GM.GetComponent<GMControls>().state = GMControls.PlayerState.OnBoard;



        yield return new WaitForSeconds(1f);
    }

    IEnumerator ToRoom()
    {
        Debug.Log("ToRoom");

        GM.transform.position = TavernTP.position;
        GM.GetComponent<GMControls>().state = GMControls.PlayerState.InRoom;



        yield return new WaitForSeconds(1f);
    }
}
