using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class MultiplayerComponent : MonoBehaviour
{
    [SerializeField] private Realtime realtime;

    void Awake()
    {
        realtime = GameObject.FindGameObjectWithTag("Realtime").GetComponent<Realtime>();
    }
}
