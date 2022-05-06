using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//This updates the text in the playable environment User Interface that displays the number of active goblins in the scene
public class CountEnemiesInScene : MonoBehaviour
{
    public GameObject[] activeGoblins;
    private int count;

    // Update is called once per frame
    void Update()
    {
        activeGoblins = GameObject.FindGameObjectsWithTag("Goblin");
        count = activeGoblins.Length;
        this.GetComponent<TextMeshProUGUI>().text = count.ToString();
    }
}
