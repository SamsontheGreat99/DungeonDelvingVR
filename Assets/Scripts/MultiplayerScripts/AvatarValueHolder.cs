using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarValueHolder : MonoBehaviour
{
    public string name;
    public int initiativeValue;

    // Start is called before the first frame update
    void Start()
    {
        name = this.GetComponent<AvatarAttributesSync>().playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
