using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script doesn't work, but it is supposed to find the players in the scene and teleport them to the target position, and then back to the tavern

public class TeleportPlayers : MonoBehaviour
{
    public GameObject PlayableAreaTP;
    public Transform TavernTP;
    private List<GameObject> players;

    private bool teleBool = false;

    private void Start()
    {
        TavernTP = GameObject.FindGameObjectWithTag("TavernTP").transform;
        players = GetPlayersInScene.activePlayers;

    }
    private void Update()
    {
        players = GetPlayersInScene.activePlayers;
    }
    public void TeleportPlayersToAndFromBoard()
    {
        if (!teleBool)
        {
            StartCoroutine(ToBoard());
        }
        else
        {
            StartCoroutine(ToRoom());
        }
    }

    IEnumerator ToBoard()
    {
        Debug.Log("ToBoard");

        PlayableAreaTP = GameObject.FindGameObjectWithTag("PlayableAreaTP");
        Debug.Log(PlayableAreaTP);

        PlayableAreaTP.GetComponent<PlayerTPScript>().TPTOME();

        yield return new WaitForSeconds(1f);
    }

    IEnumerator ToRoom()
    {
        Debug.Log("ToRoom");

        foreach (GameObject player in players)
        {
            player.transform.position = TavernTP.position;
            player.GetComponent<PlayerControls>().state = PlayerControls.PlayerState.InRoom;
        }


        yield return new WaitForSeconds(1f);
    }
}


