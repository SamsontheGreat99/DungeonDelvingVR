using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This overrides the Realtime Transform and keeps the House board environment on the board

public class BoardTransformHouse : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(-191.4095f, 1.142554f, -48.80812f);
        this.transform.rotation = new Quaternion(0, 0, 0, 0);
        this.transform.localScale = new Vector3(0.06155644f, 11.50018f, 0.05766381f);
    }
}
