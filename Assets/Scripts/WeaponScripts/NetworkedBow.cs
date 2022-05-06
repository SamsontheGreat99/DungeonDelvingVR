using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkedBow : MonoBehaviour
{
    public GameObject target;
 
    void Update()
    {
        this.transform.localPosition = target.transform.position;
        this.transform.localRotation = target.transform.rotation;
        this.transform.localScale = new Vector3(35,35,35);
    }
}
