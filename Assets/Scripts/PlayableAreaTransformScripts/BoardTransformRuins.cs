using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This overrides the Realtime Transform and keeps the Ruins board environment on the board

public class BoardTransformRuins : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(-191.4145f, 1.157741f, -48.8042f);
        this.transform.rotation = new Quaternion(0, 0, 0, 0);
        this.transform.localScale = new Vector3(0.06232727f, 11.64419f, 0.05838592f);
    }
}
