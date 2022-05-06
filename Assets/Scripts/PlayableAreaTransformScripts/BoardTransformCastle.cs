using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This overrides the Realtime Transform and keeps the Castle board environment on the board

public class BoardTransformCastle : MonoBehaviour
{
    void Update()
    {
        this.transform.position = new Vector3(-191.4145f, 1.140803f, -48.80081f);
        this.transform.rotation = new Quaternion(0, 0, 0, 0);
        this.transform.localScale = new Vector3(0.01924673f, 0.0225844f, 0.02739036f);
    }
}
