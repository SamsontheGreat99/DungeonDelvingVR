using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

//This script overrides the realtime transform values and updates them based on the target model for the goblin
public class NetworkedGoblin : MonoBehaviour
{
    public GameObject target;
    private Realtime realtime;

    private void Start()
    {
        realtime = GameObject.FindGameObjectWithTag("Realtime").GetComponent<Realtime>();
    }

    private void Update()
    {
   
        this.transform.localPosition = target.transform.position;
        this.transform.localRotation = target.transform.rotation;
        this.transform.localScale = new Vector3(0.8384338f, 1f, 0.6154058f);

    }

    //void LateUpdate()
    //{
    //    if (target == null)
    //    {
    //        Realtime.Destroy(this.gameObject);
    //    }
    //}

}
