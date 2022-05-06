using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkedShield : MonoBehaviour
{
    public GameObject target;
    

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = target.transform.position;
        this.transform.localRotation = target.transform.rotation;
        this.transform.localScale = new Vector3(15,15,15);
    }
}
