using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This overrides the Realtime Transform and keeps the Ruins playable environment in the right spot

public class PATransformRuins : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(-219.16f, 32.32f, -50.66f);
        this.transform.rotation = new Quaternion(0, 0, 0, 0);
        this.transform.localScale = new Vector3(3.616426f, 675.6328f, 3.387735f);
    }
}
