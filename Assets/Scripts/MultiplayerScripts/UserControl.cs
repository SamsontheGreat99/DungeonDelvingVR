using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

//This script requests ownership of each child object in a prefab/ instance
public class UserControl : MonoBehaviour
{
    private RealtimeView realtimeView;
    private RealtimeTransform realtimeTransform;
    private int id;

    private void Start()
    {
        realtimeView = this.GetComponent<RealtimeView>();
        realtimeTransform = this.transform.GetComponentInChildren<RealtimeTransform>();
        realtimeView.RequestOwnership();
        realtimeTransform.RequestOwnership();
        Debug.Log(realtimeTransform.isOwnedLocallySelf);
    }
}
