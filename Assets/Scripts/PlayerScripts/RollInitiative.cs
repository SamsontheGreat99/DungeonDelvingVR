using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Normal.Realtime;

//This is how the Roll initiative button displays the player initiative

public class RollInitiative : MonoBehaviour
{
    public InitiativeInventory initiative;

    public int value;
    public string name;
    public GameObject[] avatars;

    public void Initiative()
    {
        avatars = GameObject.FindGameObjectsWithTag("Avatar");
        foreach (GameObject avatar in avatars)
        {
            if (avatar.GetComponent<RealtimeTransform>().isOwnedLocallyInHierarchy)
            {
                name = avatar.GetComponent<AvatarAttributesSync>().playerNameText.text;
            }
        }
        value = Random.Range(1, 21);

        //initiative = Resources.Load("Player Initiatives Object") as InitiativeInventory;
        initiative = GameObject.FindGameObjectWithTag("PlayerInitiativeObject").GetComponent<RollInitiative>().initiative;

        initiative.AddPlayer(name, value);
    }


    //public int initiative;
    //public GameObject[] avatars;

    //public void Initiative()
    //{
    //    initiative = Random.Range(1, 21);
    //    this.gameObject.transform.GetComponentInChildren<TextMeshProUGUI>().text = initiative.ToString();
    //    avatars = GameObject.FindGameObjectsWithTag("Avatar");

        
    //}
    
    //void Update()
    //{
    //    foreach (GameObject avatar in avatars)
    //    {
    //        if (avatar.GetComponent<RealtimeTransform>().isOwnedLocallyInHierarchy)
    //        {
    //            avatar.GetComponent<AvatarValueHolder>().initiativeValue = initiative;
    //        }
    //    }
    //}


}

    //public static int initiativeValue;
    //public void Initiative()
    //{
    //    initiativeValue = Random.Range(1, 21);
    //    this.gameObject.transform.GetComponentInChildren<TextMeshProUGUI>().text = initiativeValue.ToString();
    //    //KeyValuePair<string, int>()
    //    CreateInitiative.initiative.Add(this.gameObject.name, initiativeValue);
    //}