using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This overrides the Realtime Transform and keeps the Path board environment on the board
public class BoardTransformPath : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(-191.4065f, 1.147578f, -48.80081f);
        this.transform.rotation = new Quaternion(0, 0, 0, 0);
        this.transform.localScale = new Vector3(0.06191844f, 11.56781f, 0.05800293f);
    }
}
