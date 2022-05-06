using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NetworkedDice : MonoBehaviour
{
    public GameObject target;
    public TextMeshProUGUI[] networkNumbers;
    public TextMeshProUGUI[] localNumbers;
   
    void Update()
    {
        this.transform.position = target.transform.position;
        this.transform.rotation = target.transform.rotation;
        this.GetComponent<MeshRenderer>().material = target.GetComponent<MeshRenderer>().material;
        networkNumbers = this.GetComponentsInChildren<TextMeshProUGUI>();
        localNumbers = target.GetComponentsInChildren<TextMeshProUGUI>();

        for(int i = 0; i < networkNumbers.Length; i++)
        {
            networkNumbers[i].text = localNumbers[i].text;
        }
    }
}
