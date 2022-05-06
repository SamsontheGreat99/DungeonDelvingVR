using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class InstantiateThis : MonoBehaviour
{
    [System.Obsolete]
    private void Awake()
    {
        Realtime.Instantiate("Environments/CastleEnvironment", destroyWhenOwnerOrLastClientLeaves: true);

    }
}
