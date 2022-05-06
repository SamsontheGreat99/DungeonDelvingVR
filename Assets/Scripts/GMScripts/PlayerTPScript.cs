using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script defines a function that teleports the players to whatever object the function is called on is attached to
public class PlayerTPScript : MonoBehaviour
{
    void Start()
    {
        GameObject.FindGameObjectWithTag("PlayerCharacter").transform.position = new Vector3(3.13f,1.48f,-5.182f);
    }
    public void TPTOME()
    {
        GameObject.FindGameObjectWithTag("PlayerCharacter").transform.position = this.transform.position;
        Debug.Log("TPTOMEEEEEE");
    }
}
