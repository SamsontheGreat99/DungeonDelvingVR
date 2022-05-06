using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This overrides the Realtime Transform and keeps the Castle playable environment in the right spot

public class PATransformCastle : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(-219.46f, 32.5f, -51.45f);
        this.transform.rotation = new Quaternion(0, 0, 0, 0);
        this.transform.localScale = new Vector3(1.1927f, 1f, 1.624944f);
    }
}
